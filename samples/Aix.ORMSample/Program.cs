using Aix.ORM.DBConnectionManager;
using Aix.ORMSample.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.ORMSample
{
    /// <summary>
    /// OMR使用规范 所有表都有主键。新增、修改、删除通过对象形式操作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.ThreadPool.SetMinThreads(100, 100);
            var hostBuilder = new HostBuilder()
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

            RunConsoleAsync(hostBuilder).Wait(); //重写的目的是为了拿到ServiceProvide放入全局变量
            //hostBuilder.RunConsoleAsync().Wait();
            Console.WriteLine("服务已退出");
        }

        public static Task RunConsoleAsync(IHostBuilder hostBuilder, CancellationToken cancellationToken = default)
        {
            var host = hostBuilder.UseConsoleLifetime().Build();
            //ServiceLocator.Instance = host.Services;
            return host.RunAsync(cancellationToken);
        }
    }


}
