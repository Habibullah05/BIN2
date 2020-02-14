using ClientBIN.Abstractions;
using ClientBIN.Models;
using ClientBIN.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBIN.Extensions
{
    public static class FileService 
    {
        public static IServiceCollection AddFileService(this IServiceCollection services, Action<MyOptions> options)
        {
            services.AddScoped<IServer, Server>();
            services.Configure(options);
            return services;
        }
        public static IServiceCollection AddFilePath(this IServiceCollection services, Action<MyOptions> options)
        {  
            services.Configure<MyOptions>(options);   
            return services;
        }
       }
}
