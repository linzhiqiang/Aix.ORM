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
        public UserRepository(IServiceProvider provider, DBOption option) : base(provider, option.Master)
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

        public async Task<PagedList<UserInfo>> PageQuery(PageView pageView)
        {
            var column = " user_id  , user_name   , status  , type , create_time, update_time ";
            var table = " user_info ";

            var sqlCondition = new StringBuilder();
           // sqlCondition.Append(" AND status=1");

            string sqlOrder = " ORDER BY  user_id  ASC ";

            return await base.PagedQueryAsync<UserInfo>(pageView, column, table, sqlCondition.ToString(), null, "user_id", sqlOrder);
        }

        public async Task<List<DictInfo>> QueryDictInfoByParentCodeAsync(string parentCode)
        {
            await Task.Delay(1000);
            string sql = @"SELECT a.`dict_id`,a.`dict_code`,a.`dict_name`,a.`parent_code`,a.`dict_value`,a.`dict_type`
	                        ,a.`dynamic_sql`,a.`sequence`,a.`remark`,a.`create_time`,ifnull(b.childCount,0) as child_count
                        FROM `dict_info` a 
                        left join 
                        (select count(1) as childCount,parent_code from dict_info group by parent_code) b 
                        on a.dict_code = b.parent_code 
                         where a.`parent_code`=@ParentCode order by a.sequence desc";
            return await base.QueryAsync<DictInfo>(sql, new { ParentCode = parentCode });
        }

    }


}
