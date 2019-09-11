using Aix.ORMSample.Entity;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.ORMSample
{
    public class StartHostService : IHostedService
    {
        private UserRepository _userRepository;
        public StartHostService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                //  await WithException(TestInsert);
                await WithException(TestDelete);
                // await WithException(TestUpdate);
                WithException(PageQuery);
                // await WithException(TestTrans);

                //for (int i = 0; i < 100; i++)
                //{
                //    WithException(AService);
                //}
                // await TestUpdate();
            });



            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
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
            using (var scope = _userRepository.BeginTransScope())
            {
                await _userRepository.InsertAsync(user);
                await _userRepository.InsertAsync(user);
                scope.Commit();
            }

        }

        async Task TestDelete()
        {
            var user = new UserInfo { UserId = 15 };
            await _userRepository.DeleteAsync(user);
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
