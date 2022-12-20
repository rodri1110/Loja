using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Loja.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = GetConfiguration();
            LogConfigure(configuration);

            try
            {
                Log.Information("Iniciando o WebAPI");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro fatal.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void LogConfigure(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .CreateLogger();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{ambiente}.json")
                .Build();
            return configuration;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
