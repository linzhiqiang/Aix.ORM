using Aix.ORM;
using Aix.ORM.Common;
using Aix.ORMSample.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORMSample.Repository
{
    public class RelicRepository : BaseRepository
    {
        public RelicRepository(DBOption option) : base(option.Master)
        {

        }

        public Task<RelicItem> GetRelicItem(int relicId)
        {
            return GetByPkAsync<RelicItem>(new RelicItem { Id = relicId });
        }

        public async Task<bool> ExistsRelicItem(int relicId)
        {
            string sql = "SELECT 1 FROM relic_item WHERE id=@Id";
            return await ExecuteScalarAsync<bool>(sql, new { Id = relicId });

            //string sql = "SELECT 1 FROM relic_item WHERE id=@Id";
            //return await GetAsync<bool>(sql, new { Id = relicId });
        }

        public Task<List<RelicItem>> QueryRelicItemByIds(List<int> relicIds)
        {
            var column = GetAllColumns<RelicItem>();
            string sql = $"SELECT {column} FROM relic_item WHERE id in @Ids"; //内部已经处理了参数为空或者count=0
            return QueryAsync<RelicItem>(sql, new { Ids = relicIds });
        }

        public async Task<PagedList<RelicItem>> PageQuery(PageView pageView)
        {
            var column = GetAllColumns<RelicItem>();
            var table = GetTableName<RelicItem>();

            var sqlCondition = new StringBuilder();
            sqlCondition.Append(" AND (status=1 OR (`status` = 2 and  show_after_time < CURRENT_TIME) ) ");

            string sqlOrder = " ORDER BY  id  ASC ";

            return await base.PagedQueryAsync<RelicItem>(pageView, column, table, sqlCondition.ToString(), null, "id", sqlOrder);
        }


        public Task<List<RelicItemPics>> QueryRelicItemPics(int relicId)
        {
            var column = GetAllColumns<RelicItemPics>();
            string sql = $"select {column} from relic_item_pics where relic_id=@RelicId order by sequence  desc, id asc  ";
            return QueryAsync<RelicItemPics>(sql, new { RelicId = relicId });
        }

        public Task<List<RelicItemMedia>> QueryRelicItemMedia(int relicId)
        {
            var column = GetAllColumns<RelicItemMedia>();
            string sql = $"select {column} from relic_item_media where relic_id=@RelicId  order by id asc ";
            return QueryAsync<RelicItemMedia>(sql, new { RelicId = relicId });
        }

        public Task<List<RelicTag>> QueryRelicTag(int relicId)
        {
            var column = GetAllColumns<RelicTag>();
            string sql = $"select {column} from relic_tag where relic_id=@RelicId order by sequence ,id   ";
            return QueryAsync<RelicTag>(sql, new { RelicId = relicId });
        }

       
    }
}
