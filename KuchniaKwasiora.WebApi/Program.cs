using KuchniaKwasiora.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;

namespace KuchniaKwasiora.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var connectionString = GetConnectionString();

            var dbContext = new AppDbContext(connectionString, useConsoleLogger: true);

            using (dbContext)
            {
                var x = dbContext.Users.FirstOrDefault();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        private static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config["ConnectionStrings:Default"];
        }
    }
}
