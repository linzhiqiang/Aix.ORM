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
               //await WithException(TestInsert);
                // await WithException(Test);
                await WithException(AService);

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
                Status = 1,
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

        async Task TestUpdate()
        {
            var user = new UserInfo {  UserId=1, Status=2};
            await _userRepository.UpdateAsync(user);
        }

        async Task AService()
        {
            using (var scope = _userRepository.BeginTransScope())
            {
                var list = await _userRepository.QueryAsync();

                var user = new UserInfo { UserId = 1, Status = null,UpdateTime = DateTime.Now };
                await _userRepository.UpdateAsync(user);
                Test();

                user = new UserInfo { UserId = 1, Status = 33, UpdateTime = DateTime.Now };
                await _userRepository.UpdateAsync(user);
                scope.Commit();
            }
        }
        async Task Test()
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
