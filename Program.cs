using Enterprise.AuthorizationServer.DataLayers;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.Constants.NetStandard;
using Enterprise.Utility.Database.Functions;
using Enterprise.Utility.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Enterprise.Utility.Database
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Application Database Utility Starting...");

                var serviceCollection = new ServiceCollection();

                ConfigureServices(serviceCollection);

                var provider = serviceCollection.BuildServiceProvider();

                var loggerFactory = provider
                    .GetService<ILoggerFactory>()
                    .AddConsole(LogLevel.Debug);

                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogInformation("All Application Configuration Completed...");
                logger.LogInformation("Application Started...");

                // CleanUp Values
                provider.GetService<ICleanUpDB>().CleanUpAllValues();

                // Seed Values
                provider.GetService<ISeedDB>().SeedAllValues();

                logger.LogInformation("All Execution Completed. Press Any Key To Exit...");
                Console.ReadLine();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            Console.WriteLine("Configuring JSON Configuration...");
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            Console.WriteLine("Configuration JSON Completed");

            Console.WriteLine("Configuring Dependecies Injection...");
            //setup our DI
            serviceCollection
                .AddLogging()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString(ConfigurationNames.AuthorizationConnection));
                })
                .AddDbContext<ConfigurationDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString(ConfigurationNames.ConfigurationConnection));
                })
                .AddScoped<ISeedDB, SeedDB>()
                .AddScoped<ICleanUpDB, CleanUpDB>();

            Console.WriteLine("Configure Dependecies Injection Completed");
        }
    }
}
