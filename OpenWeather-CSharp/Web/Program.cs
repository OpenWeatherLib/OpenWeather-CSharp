using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Web
{
    /// <summary>
    /// Program
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args) => BuildWebHost(args).Run();

        /// <summary>
        /// BuildWebHost
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IWebHost</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    GetCustomConfigJsonFilenames(Path.Combine(Directory.GetCurrentDirectory()),
                            hostingContext.HostingEnvironment.EnvironmentName,
                            $"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json")
                        .ForEach(setting => config.AddJsonFile(setting));
                })
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSerilog()
                .UseStartup<Startup>()
                .Build();

        private static List<string> GetCustomConfigJsonFilenames(string path, string environmentName,
            params string[] exceptFilenames) => Directory
                .GetFiles(path, $"*{environmentName}.json")
                .Select(Path.GetFileName)
                .Where(fileName => !exceptFilenames.Contains(fileName, StringComparer.OrdinalIgnoreCase))
                .ToList();
    }
}
