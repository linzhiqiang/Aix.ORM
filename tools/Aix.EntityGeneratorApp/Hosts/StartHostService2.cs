using Aix.EntityGenerator;
using Aix.EntityGenerator.Builder;
using Aix.EntityGenerator.Utils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.EntityGeneratorApp.Hosts
{
    public class StartHostService2 : IHostedService
    {
        ILogger<StartHostService2> _logger;
        GeneratorOptions _generatorOptions;
        BuilderFactory _builderFactory;

        public StartHostService2(ILogger<StartHostService2> logger, GeneratorOptions generatorOptions
            , BuilderFactory builderFactory)
        {
            _logger = logger;
            _generatorOptions = generatorOptions;
            _builderFactory = builderFactory;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                await Task.Delay(500);
                Start();
            });
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        void Start()
        {
            string namesapce = _generatorOptions.NameSapce;
            if (string.IsNullOrEmpty(namesapce))
            {
                Console.WriteLine("请在配置文件中配置命名空间，如：<add key =\"namesapce\" value=\"My.ORMTest\"/>");
                return;
            }

            string type = "2";

            IEntityBuilder builder = _builderFactory.GetEntityBuilder(type);
            Console.WriteLine();
            ConsoleEx.WriteLine(ConsoleColor.DarkMagenta, "开始生成......");
            Console.WriteLine();
            WithException(() =>
            {
                int index = 0;
                foreach (var item in _generatorOptions.Databases)
                {
                    index++;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"数据库{index}：{item.ConnectionStrings}");
                    builder.Builder(item.DBtype, item.ConnectionStrings);
                    Console.WriteLine();
                    Console.ResetColor();
                }

            });
            Console.WriteLine();
            ConsoleEx.WriteLine(ConsoleColor.DarkMagenta, "生成成功......");

            Console.WriteLine();
            Console.WriteLine();

            Environment.Exit(0);
        }


        static void WithException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
