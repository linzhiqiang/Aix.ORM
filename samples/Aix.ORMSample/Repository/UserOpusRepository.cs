using Aix.ORM.Common;
using Aix.ORMSample.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Repository
{
  public  class UserOpusRepository : BaseMySqlRepository
    {
        public UserOpusRepository(IServiceProvider provider, DBOption option) : base(provider, option.Master)
        {

        }

        public async Task<PagedList<UserOpus>> PageQuery(PageView pageView)
        {
            var column = @" opus_id,cover_url,voice_url,isload ";

            var table = " user_opus ";

            var sqlCondition = new StringBuilder();
             sqlCondition.Append(" AND isload=0 ");

            string sqlOrder = " ORDER BY  opus_id  ASC ";

            return await base.PagedQueryAsync<UserOpus>(pageView, column, table, sqlCondition.ToString(), null, "opus_id", sqlOrder);
        }

        public Task<int> UpdateIsLoad(long opusId, int isLoad)
        {
            string sql = "update user_opus set isload=@isload where opus_id=@opusId ";
            return base.ExcuteAsync(sql, new { opusId, isLoad });
        }
    }
}
