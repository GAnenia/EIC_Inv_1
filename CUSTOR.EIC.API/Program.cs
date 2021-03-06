using System;
using System.IO;
using CUSTOR.EICOnline.DAL.EntityLayer;
using EICOnline.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EICOnline.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                    databaseInitializer.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogCritical(LoggingEvents.INIT_DATABASE, ex, LoggingEvents.INIT_DATABASE.Name);
                }
            }

            host.Run();
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }
    }
}