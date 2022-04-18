using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using ProductShop.Models;
using ProductShop.Data;
using ProductShop.DataBase;

namespace ProductShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context =
                    services.GetRequiredService<ProductShopContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger =
                    services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[]
        args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
