using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CartAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CartAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>();
                    builder.UseKestrel(opt =>
                    {
                        opt.Limits.MaxRequestBodySize = null;
                    });
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                    builder.UseSetting("detailErrors", "true");
                    builder.UseUrls("http://0.0.0.0:5001");
                });
    }
}
