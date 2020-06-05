using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Aix.EntityGeneratorApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            Console.WriteLine("服务已退出");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configurationBuilder =>
            {
            })
           .ConfigureAppConfiguration((hostBulderContext, configurationBuilder) =>
           {
               //配置环境变量 ASPNETCORE _ENVIRONMENT: Development/Staging/Production(默认值) 
               //以下加载配置文件的方式，是系统的默认行为，如果改变配置文件路径 需要自己加载，否则没必要了
               //var environmentName = hostBulderContext.HostingEnvironment.EnvironmentName;
               //configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
               // configurationBuilder.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);// 覆盖前面的相同内容
           })
            .ConfigureLogging((hostBulderContext, loggingBuilder) =>
            {
                loggingBuilder.SetMinimumLevel(LogLevel.Information);
                //系统也默认加载了默认的log
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
            })
            .ConfigureServices(Startup.ConfigureServices);

    }
}
