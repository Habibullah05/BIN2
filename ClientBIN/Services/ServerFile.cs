using ClientBIN.Abstractions;
using ClientBIN.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBIN.Repository;
using CsvHelper;
using System.Globalization;
using System.Timers;
using System.Threading;

namespace ClientBIN.Service
{
    public class Server : IServer
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly string _path;
        private readonly FileName _fileName;
        private readonly MyAppContextDb _contextDb;
        private readonly System.Timers.Timer _timer;
        private readonly string _dayOfWeek;
        private bool isSave = false;
        public Server(MyAppContextDb contextDb, IOptions<MyOptions> options)
        {
            _contextDb = contextDb;
            _fileName = options.Value.FileName;
            _path = options.Value.Path;
            _url = options.Value.ServerUrl;
            _dayOfWeek = options.Value.DayOfWeek;
            BIN.Delimiter = options.Value.Delimiter;
            _httpClient = new HttpClient();
            _timer = new System.Timers.Timer();
        }

        public async Task TimerStart()
        {
            _timer.Elapsed +=   OnCheckDayOfWeek;
            _timer.Interval = (3600 * 6) * 1000;
            _timer.Start();
        }



        private async void OnCheckDayOfWeek(object sender, ElapsedEventArgs e)
        {
            string tmp = DateTime.Now.DayOfWeek.ToString();
            if (tmp.ToLower() == _dayOfWeek)
            {
                if (isSave == false) await SetFileFromServer();
            }
            else
                isSave = false;

        }

        public async Task<IEnumerable<BIN>> GetBINs()
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                var elements = _contextDb.BINs.Count();

                if (elements > 0)
                    return _contextDb.BINs;
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async Task<IEnumerable<BIN>> GetBINs(long pan)
        {

            await semaphoreSlim.WaitAsync();
            try
            {

                var elements = _contextDb.BINs.Count();

                if (elements > 0)
                    return _contextDb.BINs.Where(b => b.START_BIN <= pan && pan <= b.END_BIN);

                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        private async Task SetFileFromServer()
        {

            try
            {

                var response = await _httpClient.GetAsync(_url);
                var stream = await response.Content.ReadAsStreamAsync();
                string fileName = _fileName.FileNamePrefix + _fileName.Filter1 + DateTime.Now.ToString("yyyyMMdd") + _fileName.Filter2 + _fileName.Extension;
                string fullPath = (Path.Combine(_path, fileName));
                using (var sr = System.IO.File.Create(fullPath))
                {
                    stream.CopyTo(sr);
                }
                await ReadFromFile(fullPath);
                isSave = true;

            }
            catch (Exception ex)
            {

                isSave = false;
            }



        }

        private async Task ReadFromFile(string path)
        {
            List<BIN> toReturn = new List<BIN>();
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    csv.Configuration.Delimiter = BIN.Delimiter;
                    while (await csv.ReadAsync()) toReturn.Add(csv.GetRecord<BIN>());
                }
            }
            await AddBINToDb(toReturn);
        }

        private async Task AddBINToDb(List<BIN> bINs)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                await _contextDb.BINs.AddRangeAsync(bINs);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

    }
}
