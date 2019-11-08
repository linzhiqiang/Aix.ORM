using Aix.ORMSample.Entity;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Aix.ORMSample.Service;

namespace Aix.ORMSample
{
    public class StartHostService : IHostedService
    {
        private ILogger<StartHostService> _logger;
        private UserRepository _userRepository;
        private RelicRepository _relicRepository;
        private UserOpusService _userOpusService;
        RelicService _relicService;
        private UserService _userService;
        public StartHostService(ILogger<StartHostService> logger
            , UserRepository userRepository
            , RelicRepository relicRepository

            , UserOpusService userOpusService
            , RelicService relicService
            , UserService userService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _relicRepository = relicRepository;


            _userOpusService = userOpusService;
            _relicService = relicService;
            _userService = userService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                await WithException(_userService.Test);

                //await WithException(_relicService.BuildSearchJson);
                //下载半边鱼的音频文件
                //await WithException(_userOpusService.Load); 

                //  await WithException(TestInsert);
                // await WithException(TestDelete);

                // await WithException(TestUpdate);
                // WithException(PageQuery);
                // await WithException(TestTrans);

                //for (int i = 0; i < 100; i++)
                //{
                //    WithException(AService);
                //}
                // await TestUpdate();

                // await WithException(ProcessImport);
            });



            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        //async Task ProcessImport()
        //{
        //    TempImport preItem = null;
        //    var list = await _relicRepository.QueryAsync();
        //    preItem = list.FirstOrDefault();
        //    foreach (var item in list)
        //    {
        //        if (string.IsNullOrWhiteSpace(item.ProductId))
        //        {
        //            item.ProductId = preItem.ProductId;
        //        }
        //        item.ProductId = item.ProductId.Replace(" ", "");
        //        item.ProductId = item.ProductId.Replace("\r", "");
        //        item.ProductId = item.ProductId.Replace("\n", "");
        //        preItem = item;
        //    }

        //    foreach (var item in list)
        //    {
        //        //await _relicRepository.UpdateAsync(item);
        //    }

        //    var saveList = new List<TempImportData>();

        //    foreach (var item in list)
        //    {
        //        var productIds = Split(item.ProductId);
        //        foreach (var pId in productIds)
        //        {
        //            var temp = new TempImportData
        //            {
        //                RelicId = int.Parse(item.RelicId),
        //                ProductId = int.Parse(pId)
        //            };
        //            if (!saveList.Exists(x => x.RelicId == temp.RelicId && x.ProductId == temp.ProductId))
        //            {
        //                saveList.Add(temp);
        //            }
        //        }
        //    }

        //    foreach (var item in saveList)
        //    {
        //        await _relicRepository.InsertAsync(item);
        //    }

        //}

        private List<string> Split(string msg)
        {
            var list = new List<string>();
            var temp = "";
            for (int i = 0; i < msg.Length; i++)
            {
                temp += msg[i];
                if ((i + 1) % 7 == 0)
                {
                    list.Add(temp);
                    temp = "";
                }
            }
            return list;
        }

        async Task TestInsert()
        {
            var user = new UserInfo
            {
                UserName = "林志强",
                Status = true,
                Type = 1,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            for (int i = 0; i < 100 * 10000; i++)
            {
                using (var scope = _userRepository.BeginTransScope())
                {
                    await _userRepository.InsertAsync(user);
                    scope.Commit();
                }
                _logger.LogInformation($"新增：{i}");
            }


        }

        async Task TestDelete()
        {
            var user = new UserInfo { UserId = 15 };
            await _userRepository.DeleteByPkAsync(user);
        }

        async Task TestUpdate()
        {
            var user = new UserInfo { UserId = 2, Status = true };
            await _userRepository.UpdateAsync(user);
        }
        async Task PageQuery()
        {

            var users = await _userRepository.PageQuery(new ORM.Common.PageView { PageIndex = 0, PageSize = 5 });
            var userInfo = await _userRepository.GetByPkAsync<UserInfo>(new UserInfo { UserId = 15 });
        }



        async Task TestTrans()
        {
            using (var scope = _userRepository.BeginTransScope())
            {
                var list = await _userRepository.QueryAsync();

                var user = new UserInfo { UserId = 2, Status = true, UpdateTime = DateTime.Now };
                await _userRepository.UpdateAsync(user);
                AsyncNewContext();

                user = new UserInfo { UserId = 2, Status = false, UpdateTime = DateTime.Now };
                await _userRepository.UpdateAsync(user);
                scope.Commit();
            }
        }
        async Task AsyncNewContext()
        {
            _userRepository.OpenNewContext();
            // await Task.Delay(2000);
            var list = await _userRepository.QueryAsync();
        }

        static async Task WithException(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
