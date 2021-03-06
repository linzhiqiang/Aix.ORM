﻿using Aix.ORMSample.Common;
using Aix.ORMSample.Entity;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Aix.ORMSample.Service
{
    public class UserService
    {
        private ILogger<UserService> _logger;
        private UserRepository _userRepository;

        public UserService(ILogger<UserService> logger, UserRepository userRepository)
        {
            _logger = logger;
            //_userRepository = ServiceLocator.Instance.GetService<UserRepository>();
            _userRepository = userRepository;

        }
        public async Task Test()
        {
            for (int i = 0; i < 1; i++)
            {
                Task.Run(() => Test1());
            }

        }
        public async Task Test1()
        {
            Console.WriteLine("begin " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            for (int i = 0; i < 1 * 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var users = await _userRepository.PageQuery(new ORM.Common.PageView { PageIndex = 1, PageSize = 5 });
                    var rowCount = 0;

                    //rowCount = await _userRepository.UpdateAsync(new UserInfo
                    //{
                    //    UserId = 33,
                    //    Type = 100,
                    //    UpdateTime = DateTime.Now
                    //});

                    //rowCount = await _userRepository.DeleteByPkAsync(new UserInfo { UserId = 36 });
                    //rowCount = await _userRepository.DeleteByPropertyAsync(x => x.UserId, new UserInfo { UserId = 114 });

                    //rowCount = await _userRepository.DeleteByPropertyAsync(x => x.UserId, new UserInfo { UserId = 114 });

                    //rowCount = await _userRepository.DeleteByPropertyAsync(x => x.UserName, x => x.Status, new UserInfo { UserName = "林志强2", Status = true });
                });
            }

            Console.WriteLine("end " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));

        }

    }

    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           
        }
    }

    public class MyLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }


}
