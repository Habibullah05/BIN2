using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientBIN.Abstractions;
using ClientBIN.Models;
using ClientBIN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace ClientBIN.Controllers
{
    public class ClientSideController : Controller
    {
        readonly IServer _server;
        public ClientSideController(IServer server)
        {
            
            _server = server;
            _server.TimerStart();
        }
        [HttpGet]
        public async Task<IActionResult> Table()
        {
            await _server.TimerStart();
            IEnumerable<BIN> bs = await _server.GetBINs();
            return View(bs);
        }
        [HttpPost]
        public async Task<IActionResult> Table(long pan)
        {
            IEnumerable<BIN> bs = await _server.GetBINs();
            return View(bs);
        }

    }
}
