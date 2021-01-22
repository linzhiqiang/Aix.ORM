using Aix.EntityGenerator;
using Aix.EntityGenerator.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.EntityGeneratorApp.Hosts
{
    public class StartHostService : IHostedService
    {
        ILogger<StartHostService> _logger;
        GeneratorOptions _generatorOptions;
        BuilderFactory _builderFactory;

        public StartHostService(ILogger<StartHostService> logger, GeneratorOptions generatorOptions
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
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("************请选择操作：*****************");
                Console.WriteLine("1：基本实体");
                Console.WriteLine("2：ORM实体");
                Console.WriteLine("q：退出");
                Console.WriteLine("*****************************************");
                Console.WriteLine();
                string type = Console.ReadLine();

                IEntityBuilder builder = _builderFactory.GetEntityBuilder(type);
                if (builder != null)
                {
                }
                else if (type == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("怎么选择了一个空的操作呢，请继续......");
                    continue;
                }
                Console.WriteLine("开始生成......");
                Console.WriteLine();
                WithException(() =>
                {
                    foreach (var item in _generatorOptions.Databases)
                    {
                        builder.Builder(item.DBtype, item.ConnectionStrings);
                    }

                });
                Console.WriteLine();
                Console.WriteLine("生成成功......");

                Console.WriteLine();
                Console.WriteLine();

               
            }
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
