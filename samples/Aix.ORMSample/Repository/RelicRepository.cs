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

        public Task<List<TempImport>> QueryAsync()
        {
            string sql = @"select *  from temp_import order by  id ";
            return base.QueryAsync<TempImport>(sql, null);
        }
    }
}
