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
using Aix.ORM.DTO;
using System.Linq.Expressions;

namespace Aix.ORM.Repository
{
    public partial class AbstractRepository
    {
        public async Task<long> InsertAsync(BaseEntity entity)
        {
            string sql = SQLBuilderHelper.GetInsertSql(entity, this.GetORMDBType());
            return await ExecuteAndTraceAsync(sql, entity, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    var result = await mgr.Connection.QuerySingleAsync<long>(sql, entity, mgr.Transaction, null, CommandType.Text);
                    return result;
                }
            });
        }

        public async Task<int> ReplaceIntoAsync(BaseEntity entity)
        {
            string sql = SQLBuilderHelper.GetReplaceInsertSQL(entity, this.GetORMDBType());
            return await ExcuteAsync(sql, entity);
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


        public async Task<int> DeleteByPkAsync(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetDeleteByPkSql(model, this.GetORMDBType());
            return await this.ExcuteAsync(sql, model);
        }

        public Task<int> DeleteByPropertyAsync<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertySelector, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.ExcuteAsync(sql, model);
        }

        public Task<int> DeleteByPropertyAsync<TModel, TProperty1, TProperty2>(Expression<Func<TModel, TProperty1>> propertySelector1, Expression<Func<TModel, TProperty2>> propertySelector2, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector1),
                    GetPropertyNameFromExpression(propertySelector2)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.ExcuteAsync(sql, model);
        }

        public Task<int> DeleteByPropertyAsync<TModel, TProperty1, TProperty2, TProperty3>(Expression<Func<TModel, TProperty1>> propertySelector1, Expression<Func<TModel, TProperty2>> propertySelector2, Expression<Func<TModel, TProperty3>> propertySelector3, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector1),
                    GetPropertyNameFromExpression(propertySelector2),
                    GetPropertyNameFromExpression(propertySelector3)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.ExcuteAsync(sql, model);
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
            return await ExecuteAndTraceAsync(sql, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return await mgr.Connection.ExecuteAsync(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                }
            });
        }

        protected async Task<T> GetAsync<T>(string sql, object paras)
        {
            //var result = await QueryAsync<T>(sql, paras);
            //return result.FirstOrDefault();

            return await QueryFirstOrDefaultAsync<T>(sql, null, paras);
        }

        protected Task<T> QueryFirstOrDefaultAsync<T>(string sql, object paras)
        {
            return QueryFirstOrDefaultAsync<T>(sql, null, paras);
        }

        protected Task<T> ExecuteScalarAsync<T>(string sql, object paras)
        {
            return ExecuteScalarAsync<T>(sql, null, paras);
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object paras)
        {
            return await QueryAsync<T>(sql, null, paras);
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, int? timeOut, object paras)
        {
            return await ExecuteAndTraceAsync(sql, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    var list = await mgr.Connection.QueryAsync<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                    return list.ToList();
                }
            });
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, int? timeOut, object paras)
        {
            return await ExecuteAndTraceAsync(sql, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return await mgr.Connection.QueryFirstOrDefaultAsync<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                }
            });
        }

        protected async Task<MultipleResut2<Result1, Result2>> QueryMultipleAsync<Result1, Result2>(string sql, int? timeOut, object paras)
        {
            return await ExecuteAndTraceAsync(sql, paras, async () =>
            {
                var ret = new MultipleResut2<Result1, Result2>();
                using (ConnectionManager mgr = GetConnection())
                {
                    using (var multiReader = await mgr.Connection.QueryMultipleAsync(sql, paras, mgr.Transaction, timeOut, CommandType.Text))
                    {
                        ret.R1 = (await multiReader.ReadAsync<Result1>()).ToList();
                        ret.R2 = (await multiReader.ReadAsync<Result2>()).ToList();
                    }
                }
                return ret;
            });
        }

        protected async Task<T> ExecuteScalarAsync<T>(string sql, int? timeOut, object paras)
        {
            return await ExecuteAndTraceAsync(sql, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return await mgr.Connection.ExecuteScalarAsync<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                }
            });
        }

        protected async Task<int> SPExcuteAsync(string spName, object paras)
        {
            return await ExecuteAndTraceAsync(spName, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return await mgr.Connection.ExecuteAsync(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
                }
            });
        }

        protected async Task<T> SPGetAsync<T>(string spName, object paras)
        {
            var list = await SPQueryAsync<T>(spName, paras);
            return list.FirstOrDefault();
        }

        protected async Task<List<T>> SPQueryAsync<T>(string spName, object paras)
        {
            return await ExecuteAndTraceAsync(spName, paras, async () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    var list = await mgr.Connection.QueryAsync<T>(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
                    return list.ToList();
                }
            });
        }
    }
}
