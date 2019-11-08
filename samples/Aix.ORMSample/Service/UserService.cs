using Aix.ORMSample.Entity;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Service
{
    public class UserService
    {
        private ILogger<UserService> _logger;
        private UserRepository _userRepository;

        public UserService(ILogger<UserService> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;

        }

        public async Task Test()
        {
            var rowCount = 0;

            rowCount = await _userRepository.UpdateAsync(new UserInfo { 
            UserId=33,
            Type=100,
            UpdateTime=DateTime.Now
            });

            rowCount = await _userRepository.DeleteByPkAsync(new UserInfo { UserId = 36 });
            rowCount = await _userRepository.DeleteByPropertyAsync(new UserInfo { UserId = 114 }, x => x.UserId);

            rowCount = await _userRepository.DeleteByPropertyAsync(new UserInfo { UserName = "林志强2", Status = true }, x => x.UserName, x => x.Status);

        }

    }
}
