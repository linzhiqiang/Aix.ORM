using Aix.ORM.Common;
using Aix.ORM.Repository;
using Aix.ORMSample.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Repository
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DBOption option) : base(option.Master)
        {

        }

        public Task<List<UserInfo>> QueryAsync()
        {
            string sql = @"select user_id
      ,user_name
      ,status
      ,type
      ,create_time,update_time from user_info";
            return base.QueryAsync<UserInfo>(sql, null);
        }

        public Task<PagedList<UserInfo>> PageQuery(PageView pageView)
        {
            var column = " user_id  , user_name   , status  , type , create_time, update_time ";
            var table = " user_info ";

            var sqlCondition = new StringBuilder();
            sqlCondition.Append(" AND status=1");

            string sqlOrder = " ORDER BY  user_id  ASC ";

            return base.PagedQueryAsync<UserInfo>(pageView, column, table, sqlCondition.ToString(), null, "user_id", sqlOrder);
        }
    }


}
