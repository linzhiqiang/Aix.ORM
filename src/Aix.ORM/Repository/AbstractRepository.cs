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
using Aix.ORM.DbTransactionManager;
using Aix.ORM.DTO;
using System.Linq.Expressions;

namespace Aix.ORM.Repository
{
    public abstract partial class AbstractRepository
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected string ConnectionStrings { get; set; }

        public AbstractRepository(string connectionStrings)
        {
            this.ConnectionStrings = connectionStrings;
        }

        /// <summary>
        /// 获取所有列 逗号分隔 mysql用``,sqlserver用[]
        /// </summary>
        /// <param name="prefix">如A 最终sql语句就是A.Id，可为空</param>
        /// <returns></returns>
        public string GetAllColumns<T>(string prefix = "") where T : BaseEntity
        {
            return SQLBuilderHelper.GetAllColumns(typeof(T), this.GetORMDBType(), prefix);
        }

        public string GetTableName<T>() where T : BaseEntity
        {
            return SQLBuilderHelper.GetTableName(typeof(T));
        }

        /// <summary>
        /// 开启一个事务，
        /// using(var transScope=BeginTransScope())
        /// {...;
        /// transScope.Commit();
        /// }
        /// </summary>
        /// <param name="scopeOption"></param>
        /// <returns></returns>
        public IDBTransScope BeginTransScope(TransScopeOption scopeOption = TransScopeOption.Required)
        {
            return new DBTransScope(ConnectionStrings, this.GetORMDBType(), scopeOption);
        }

        //public void Commit(IDBTransScope transScope)
        //{
        //    transScope.Commit();
        //}

        /// <summary>
        /// 开启一个新的连接上下文 用于在正常逻辑中，异步执行一个任务（task.run）
        /// </summary>
        public void OpenNewContext()
        {
            ConnectionContext.Instance.OpenNewContext();
        }

        /// <summary>
        /// 如果主键是自增返回插入主键 否则返回0
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Insert(BaseEntity entity)
        {
            string sql = SQLBuilderHelper.GetInsertSql(entity, this.GetORMDBType());
            return ExecuteAndTrace(sql, entity, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.QuerySingle<long>(sql, entity, mgr.Transaction, null, CommandType.Text);
                }
            });

        }

        /// <summary>
        /// 返回影响行数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int ReplaceInto(BaseEntity entity)
        {
            int ret = 0;
            string sql = SQLBuilderHelper.GetReplaceInsertSQL(entity, this.GetORMDBType());
            ret = Excute(sql, entity);
            return ret;
        }

        /// <summary>
        /// 批量新增 （新增相同的列）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public int BatchInsert<T>(List<T> list) where T : BaseEntity
        {
            int ret = 0;
            if (list != null && list.Count > 0)
            {
                string sql = SQLBuilderHelper.GetInsertSql(list.First(), this.GetORMDBType());
                ret = Excute(sql, list);
            }
            return ret;
        }

        public int Update(BaseEntity model)
        {
            int ret = 0;
            string sql = SQLBuilderHelper.GetUpdateSql(model, this.GetORMDBType());
            ret = Excute(sql, model);
            return ret;
        }

        public int UpdateAllField(BaseEntity model)
        {
            model.FullUpdate = true;
            return Update(model);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public int BatchUpdate<T>(List<T> list) where T : BaseEntity
        {
            int ret = 0;
            if (list != null && list.Count > 0)
            {
                string sql = SQLBuilderHelper.GetUpdateSql(list.First(), this.GetORMDBType());
                ret = Excute(sql, list);
            }
            return ret;
        }

        public int DeleteByPk(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetDeleteByPkSql(model, this.GetORMDBType());
            return this.Excute(sql, model);
        }

        public int DeleteByProperty<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertySelector, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.Excute(sql, model);
        }

        public int DeleteByProperty<TModel, TProperty1, TProperty2>(Expression<Func<TModel, TProperty1>> propertySelector1, Expression<Func<TModel, TProperty2>> propertySelector2, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector1),
                    GetPropertyNameFromExpression(propertySelector2)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.Excute(sql, model);
        }

        public int DeleteByProperty<TModel, TProperty1, TProperty2, TProperty3>(Expression<Func<TModel, TProperty1>> propertySelector1, Expression<Func<TModel, TProperty2>> propertySelector2, Expression<Func<TModel, TProperty3>> propertySelector3, TModel model) where TModel : BaseEntity
        {
            var propertyNames = new List<string> {
                    GetPropertyNameFromExpression(propertySelector1),
                    GetPropertyNameFromExpression(propertySelector2),
                    GetPropertyNameFromExpression(propertySelector3)
             };
            string sql = SQLBuilderHelper.BuildDeleteSqlByProperty(model, propertyNames, this.GetORMDBType());

            return this.Excute(sql, model);
        }

        private string GetPropertyNameFromExpression(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null) throw new Exception($"表达式解析属性名称出错，不是MemberExpression类型");

            return memberExpression.Member.Name;
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public T GetByPk<T>(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetByPkSql(model, this.GetORMDBType());
            return this.Get<T>(sql, model);
        }

        protected int Excute(string sql, object paras)
        {
            return Excute(sql, paras, null);
        }

        protected int Excute(string sql, object paras, int? commandTimeout)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.Execute(sql, paras, mgr.Transaction, commandTimeout, CommandType.Text);
                }
            });
        }

        protected T Get<T>(string sql, object paras)
        {
            //return Query<T>(sql, paras).FirstOrDefault();
            return QueryFirstOrDefault<T>(sql, paras);
        }

        protected T QueryFirstOrDefault<T>(string sql, object paras)
        {
            //return Query<T>(sql, paras).FirstOrDefault();
            return QueryFirstOrDefault<T>(sql, paras, null);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">userid=1 and username='admin' 或者  userid=@userid and username=@username</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        protected T GetWithWhere<T>(string where, object paras = null) where T : BaseEntity
        {
            string sql = BuildQuerySql<T>(where);
            return Get<T>(sql, paras);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">userid=1 and username='admin' 或者  userid=@userid and username=@username</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        protected List<T> QueryWithWhere<T>(string where, object paras = null) where T : BaseEntity
        {
            string sql = BuildQuerySql<T>(where);
            return Query<T>(sql, paras);
        }

        private string BuildQuerySql<T>(string where) where T : BaseEntity
        {
            string sql = $"SELECT {GetAllColumns<T>() }  FROM {GetTableName<T>()} WHERE 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                if (!where.StartsWith("and", StringComparison.OrdinalIgnoreCase)) where = " AND " + where;
                sql += where;
            }

            return sql;
        }


        protected T ExecuteScalar<T>(string sql, object paras)
        {
            return ExecuteScalar<T>(sql, paras, null);
        }

        protected List<T> Query<T>(string sql, object paras)
        {
            return Query<T>(sql, paras, null);
        }

        protected List<T> Query<T>(string sql, object paras, int? commandTimeout)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.Query<T>(sql, paras, mgr.Transaction, false, commandTimeout, CommandType.Text).ToList();
                }
            });
        }

        protected List<TReturn> Query<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object paras = null, string splitOn = "Id", int? commandTimeout = null)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.Query(sql, types, map,
                    param: paras,
                    transaction: mgr.Transaction,
                    //buffered: false,
                    splitOn: splitOn,
                    commandTimeout: commandTimeout
                    //commandType: CommandType.Text
                    ).ToList();
                }
            });
        }

        protected List<TReturn> Query<TFirst, TSecond, TReturn>(string sql, object paras, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id", int? commandTimeout = null)
        {
            return ExecuteAndTrace(sql, paras, () =>
          {
              using (ConnectionManager mgr = GetConnection())
              {
                  var list = mgr.Connection.Query<TFirst, TSecond, TReturn>(sql, map,
                      paras,
                      mgr.Transaction,
                      commandTimeout: commandTimeout,
                      splitOn: splitOn);
                  return list.ToList();
              }
          });
        }

        protected List<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, object paras, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id", int? commandTimeout = null)
        {
            return ExecuteAndTrace(sql, paras, () =>
           {
               using (ConnectionManager mgr = GetConnection())
               {
                   var list = mgr.Connection.Query<TFirst, TSecond, TThird, TReturn>(sql, map,
                       paras,
                       mgr.Transaction,
                       commandTimeout: commandTimeout,
                       splitOn: splitOn);
                   return list.ToList();
               }
           });
        }

        protected T QueryFirstOrDefault<T>(string sql, object paras, int? commandTimeout)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    //https://blog.csdn.net/Day_and_Night_2017/article/details/88015637
                    return mgr.Connection.QueryFirstOrDefault<T>(sql, paras, mgr.Transaction, commandTimeout, CommandType.Text);
                }
            });
        }

        protected T ExecuteScalar<T>(string sql, object paras, int? commandTimeout)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.ExecuteScalar<T>(sql, paras, mgr.Transaction, commandTimeout, CommandType.Text);
                }
            });
        }

        protected MultipleResut2<Result1, Result2> QueryMultiple<Result1, Result2>(string sql, object paras, int? commandTimeout)
        {
            return ExecuteAndTrace(sql, paras, () =>
            {
                var ret = new MultipleResut2<Result1, Result2>();
                using (ConnectionManager mgr = GetConnection())
                {
                    using (var multiReader = mgr.Connection.QueryMultiple(sql, paras, mgr.Transaction, commandTimeout, CommandType.Text))
                    {
                        ret.R1 = multiReader.Read<Result1>().ToList();
                        ret.R2 = multiReader.Read<Result2>().ToList();
                    }
                }

                return ret;

            });
        }

        protected int SPExcute(string spName, object paras)
        {
            return ExecuteAndTrace(spName, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.Execute(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
                }
            });
        }

        protected T SPGet<T>(string spName, object paras)
        {
            return SPQuery<T>(spName, paras).FirstOrDefault();
        }

        protected List<T> SPQuery<T>(string spName, object paras)
        {

            return ExecuteAndTrace(spName, paras, () =>
            {
                using (ConnectionManager mgr = GetConnection())
                {
                    return mgr.Connection.Query<T>(spName, paras, mgr.Transaction, false, null, CommandType.StoredProcedure).ToList();
                }
            });
        }

        #region sql 跟踪
        private T ExecuteAndTrace<T>(string sql, object param, Func<T> func)
        {
            using (var trace = GetSqlExecuteTrace(sql, param))
            {
                try
                {
                    trace.ExecuteStart();
                    return func();
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
        }

        private async Task<T> ExecuteAndTraceAsync<T>(string sql, object param, Func<Task<T>> func)
        {
            using (var trace = GetSqlExecuteTrace(sql, param))
            {
                try
                {
                    trace.ExecuteStart();
                    return await func();
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }

        }

        #endregion

        protected ConnectionManager GetConnection()
        {
            return ConnectionManager.GetManager(this.ConnectionStrings, this.GetORMDBType());
        }

        /// <summary>
        /// 创建sql执行跟踪器对象
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="paras">执行sql的参数对象</param>
        /// <returns></returns>
        protected virtual AbstractSqlExecuteTrace GetSqlExecuteTrace(string sql, object paras)
        {
            return DefaultSqlExecuteTrace.Instance;

        }

        protected abstract ORMDBType GetORMDBType();
    }


}
