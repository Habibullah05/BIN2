using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientBIN.Abstractions;
using ClientBIN.Repository;
using ClientBIN.Service;
using ClientBIN.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClientBIN.Models;

namespace ClientBIN
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Service service = new ClientBIN.Service();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDbContext<MyAppContextDb>(options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });

            services.AddFileService(options =>
            {
                options.Path = Configuration.GetSection("PathFile").Value;
                options.FileName.FileNamePrefix = Configuration["FileName:FileNamePrefix"];
                options.FileName.Filter1 = Configuration["FileName:Filter1"];
                options.FileName.Filter2 = Configuration["FileName:Filter2"];
                options.FileName.Extension = Configuration["FileName:Extension"];
                options.ServerUrl = Configuration.GetSection("Url").Value; 
                options.DayOfWeek= Configuration.GetSection("DayOfWeek").Value;
                options.Delimiter = Configuration.GetSection("Delimiter").Value;

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ClientSide}/{action=Table}/{id?}");
            });
        }
    }
}
