using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FProject.Data.Context;
using FProject.Data.DataSeeding;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FProjectBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            IHostingEnvironment env = host.Services.GetService<IHostingEnvironment>();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    FProjectDbContext FProjectDbContext = services.GetRequiredService<FProjectDbContext>();
                    FProjectDbContext.Database.EnsureCreated();
                    //DataDbInitializer.Seed(ImdbContext);
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
