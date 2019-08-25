using Aix.ORM.Common;
using Aix.ORM.DBConnectionManager;
using Aix.ORM.SQLBuilder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace Aix.ORM.Repository
{
    public partial class AbstractRepository
    {
        public async Task<long> InsertAsync(BaseEntity entity)
        {
            using (ConnectionManager mgr = GetConnection())
            {
                string sql = SQLBuilderHelper.GetInsertSql(entity, this.GetORMDBType());
                return await mgr.Connection.QuerySingleAsync<long>(sql, entity, mgr.Transaction, null, CommandType.Text);
            }
        }

        public async Task<int> ReplaceIntoAsync(BaseEntity entity)
        {
            //using (ConnectionManager mgr = GetConnection())
            {
                string sql = SQLBuilderHelper.GetReplaceInsertSQL(entity, this.GetORMDBType());
                return await ExcuteAsync(sql, entity);
            }
        }

        public async Task<int> BatchInsertAsync<T>(List<T> list) where T : BaseEntity
        {
            if (list != null && list.Count > 0)
            {
                string sql = SQLBuilderHelper.GetInsertSql(list.First(), this.GetORMDBType());
                return await ExcuteAsync(sql, list);
            }
            return 0;
        }

        public async Task<int> UpdateAsync(BaseEntity model)
        {
            Task<int> ret;
            string sql = SQLBuilderHelper.GetUpdateSql(model, this.GetORMDBType());
            ret = ExcuteAsync(sql, model);
            return await ret;
        }
        public Task<int> UpdateAllFieldAsync(BaseEntity model)
        {
            model.FullUpdate = true;
            return UpdateAsync(model);
        }

        public async Task<int> BatchUpdateAsync<T>(List<T> list) where T : BaseEntity
        {
            if (list != null && list.Count > 0)
            {
                string sql = SQLBuilderHelper.GetUpdateSql(list.First(), this.GetORMDBType());
                return await ExcuteAsync(sql, list);
            }
            return 0;
        }


        public async Task<int> DeleteAsync(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetDeleteByPkSql(model, this.GetORMDBType());
            return await this.ExcuteAsync(sql, model);
        }

        public async Task<T> GetByPkAsync<T>(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetByPkSql(model, this.GetORMDBType());
            return await this.GetAsync<T>(sql, model);
        }

        protected async Task<int> ExcuteAsync(string sql, object paras)
        {
            return await ExcuteAsync(sql, null, paras);
        }

        protected async Task<int> ExcuteAsync(string sql, int? timeOut, object paras)
        {
            using (ConnectionManager mgr = GetConnection())
            {
                return await mgr.Connection.ExecuteAsync(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
            }
        }

        protected async Task<T> GetAsync<T>(string sql, object paras)
        {
            var result = await QueryAsync<T>(sql, paras);
            return result.FirstOrDefault();
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object paras)
        {
            return await QueryAsync<T>(sql, null, paras);
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, int? timeOut, object paras)
        {
            using (ConnectionManager mgr = GetConnection())
            {
                var list = await mgr.Connection.QueryAsync<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                return list.ToList();
            }
        }

        protected async Task<int> SPExcuteAsync(string spName, object paras)
        {
            using (ConnectionManager mgr = GetConnection())
            {
                return await mgr.Connection.ExecuteAsync(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
            }
        }

        protected async Task<T> SPGetAsync<T>(string spName, object paras)
        {
            var list = await SPQueryAsync<T>(spName, paras);
            return list.FirstOrDefault();
        }

        protected async Task<List<T>> SPQueryAsync<T>(string spName, object paras)
        {
            using (ConnectionManager mgr = GetConnection())
            {
                var list = await mgr.Connection.QueryAsync<T>(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
                return list.ToList();
            }
        }
    }
}
