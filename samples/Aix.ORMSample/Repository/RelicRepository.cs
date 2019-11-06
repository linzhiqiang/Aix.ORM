using Aix.ORM.Common;
using Aix.ORMSample.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Repository
{
    public class RelicRepository : BaseRepository
    {
        public RelicRepository(DBOption option) : base(option.Master)
        {

        }

        public async Task<PagedList<RelicItem>> PageQuery(PageView pageView)
        {
            var column = @" * ";

            var table = " relic_item ";

            var sqlCondition = new StringBuilder();
            sqlCondition.Append(" AND (status=1 OR (`status` = 2 and  show_after_time < CURRENT_TIME) ) ");

            string sqlOrder = " ORDER BY  id  ASC ";

            return await base.PagedQueryAsync<RelicItem>(pageView, column, table, sqlCondition.ToString(), null, "id", sqlOrder);
        }


        public Task<List<RelicItemPics>> QueryRelicItemPics(int relicId)
        {
            string sql = "select * from relic_item_pics where relic_id=@RelicId order by sequence  desc, id asc  ";
            return QueryAsync<RelicItemPics>(sql, new { RelicId = relicId });
        }

        public Task<List<RelicItemMedia>> QueryRelicItemMedia(int relicId)
        {
            string sql = "select * from relic_item_media where relic_id=@RelicId  order by id asc ";
            return QueryAsync<RelicItemMedia>(sql, new { RelicId = relicId });
        }

        public Task<List<RelicTag>> QueryRelicTag(int relicId)
        {
            string sql = "select * from relic_tag where relic_id=@RelicId order by sequence ,id   ";
            return QueryAsync<RelicTag>(sql, new { RelicId = relicId });
        }


    }
}
