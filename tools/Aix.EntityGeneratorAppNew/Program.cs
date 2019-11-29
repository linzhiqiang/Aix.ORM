using Aix.EntityGenerator;
using Aix.EntityGeneratorNew;
using Aix.ORM.DBConnectionManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.EntityGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddEnvironmentVariables(prefix: "Demo_");
                })
                 .ConfigureAppConfiguration((hostContext, config) =>
                 {
                     config.AddJsonFile("config/appsettings.json", optional: true);
                     config.AddJsonFile($"config/appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);// 覆盖前面的相同内容

                  })
                .ConfigureLogging((context, factory) =>
                {
                    factory.AddConsole();
                    factory.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureServices(Startup.ConfigureServices);


            RunConsoleAsync(host).Wait();
            Console.WriteLine("服务已退出");
        }

        public static Task RunConsoleAsync(IHostBuilder hostBuilder, CancellationToken cancellationToken = default)
        {
            var host = hostBuilder.UseConsoleLifetime().Build();
            ServiceLocator.Instance = host.Services;
            return host.RunAsync(cancellationToken);
        }


    }
}
