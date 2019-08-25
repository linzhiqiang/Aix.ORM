using Aix.ORM.Repository;
using Aix.ORMSample.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Repository
{
    public class UserRepository : MsSqlRepository
    {
        public UserRepository(DBOption option) : base(option.Master)
        {

        }

        public Task<List<UserInfo>> QueryAsync()
        {
            string sql = "select *from UserInfo";
            return base.QueryAsync<UserInfo>(sql, null);
        }
    }
}
