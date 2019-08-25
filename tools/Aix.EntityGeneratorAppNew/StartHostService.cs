using Aix.EntityGenerator;
using Aix.EntityGenerator.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.EntityGeneratorApp
{
    public class StartHostService : IHostedService
    {
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

        static void Start()
        {
            //ORMConfig.Instance.SetORMDBType(ORMDBType.SqlServer);
            string namesapce = GeneratorOption.Instance.NameSapce;
            if (string.IsNullOrEmpty(namesapce))
            {
                Console.WriteLine("请在配置文件中配置命名空间，如：<add key =\"namesapce\" value=\"My.ORMTest\"/>");
                return;
            }
            while (true)
            {
                Console.WriteLine("请选择操作：");
                Console.WriteLine("1：基本实体");
                Console.WriteLine("2：ORM实体");
                string type = Console.ReadLine();
                Console.WriteLine("开始生成......");
                if (type == "1")
                {
                    IEntityBuilder builder = new DefaultBuilder();
                    WithException(() =>
                    {
                        builder.Builder(namesapce);
                    });
                }

                if (type == "2")
                {
                    IEntityBuilder builder = new ORMBuilder();
                    WithException(() =>
                    {
                        builder.Builder(namesapce);
                    });
                }
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
