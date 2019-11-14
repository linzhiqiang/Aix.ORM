﻿using Aix.ORM.Common;
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
        public AbstractRepository(string connectionStrings)
        {
            this.ConnectionStrings = connectionStrings;
        }

        private string ConnectionStrings { get; set; }

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
            return new DBTransScope(ConnectionStrings, scopeOption);
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
            long ret = 0;
            string sql = SQLBuilderHelper.GetInsertSql(entity, this.GetORMDBType());
            using (var trace = GetSqlExecuteTrace(sql, entity))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        ret = mgr.Connection.QuerySingle<long>(sql, entity, mgr.Transaction, null, CommandType.Text);
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
            return ret;
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
            return Excute(sql, null, paras);
        }

        protected int Excute(string sql, int? timeOut, object paras)
        {
            int ret = -1;
            using (var trace = GetSqlExecuteTrace(sql, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        ret = mgr.Connection.Execute(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
            return ret;
        }

        protected T Get<T>(string sql, object paras)
        {
            //return Query<T>(sql, paras).FirstOrDefault();
            return QueryFirstOrDefault<T>(sql, null, paras);
        }
        protected T QueryFirstOrDefault<T>(string sql, object paras)
        {
            //return Query<T>(sql, paras).FirstOrDefault();
            return QueryFirstOrDefault<T>(sql, null, paras);
        }

        protected T ExecuteScalar<T>(string sql, object paras)
        {
            return ExecuteScalar<T>(sql, null, paras);
        }


        protected List<T> Query<T>(string sql, object paras)
        {
            return Query<T>(sql, null, paras);
        }

        protected List<T> Query<T>(string sql, int? timeOut, object paras)
        {
            List<T> list = null;
            using (var trace = GetSqlExecuteTrace(sql, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        list = mgr.Connection.Query<T>(sql, paras, mgr.Transaction, false, timeOut, CommandType.Text).ToList();
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
            return list;
        }

        protected T QueryFirstOrDefault<T>(string sql, int? timeOut, object paras)
        {
            using (var trace = GetSqlExecuteTrace(sql, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        //https://blog.csdn.net/Day_and_Night_2017/article/details/88015637
                        return mgr.Connection.QueryFirstOrDefault<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
        }

        protected T ExecuteScalar<T>(string sql, int? timeOut, object paras)
        {
            using (var trace = GetSqlExecuteTrace(sql, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        return mgr.Connection.ExecuteScalar<T>(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
        }

        protected MultipleResut2<Result1, Result2> QueryMultiple<Result1, Result2>(string sql, int? timeOut, object paras)
        {
            var ret = new MultipleResut2<Result1, Result2>();
            using (var trace = GetSqlExecuteTrace(sql, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        using (var multiReader = mgr.Connection.QueryMultiple(sql, paras, mgr.Transaction, timeOut, CommandType.Text))
                        {
                            ret.R1 = multiReader.Read<Result1>().ToList();
                            ret.R2 = multiReader.Read<Result2>().ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
            return ret;

        }

        protected int SPExcute(string spName, object paras)
        {
            int ret = -1;
            using (var trace = GetSqlExecuteTrace(spName, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        ret = mgr.Connection.Execute(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
            }
            return ret;
        }

        protected T SPGet<T>(string spName, object paras)
        {
            return SPQuery<T>(spName, paras).FirstOrDefault();
        }

        protected List<T> SPQuery<T>(string spName, object paras)
        {
            List<T> list = null;
            using (var trace = GetSqlExecuteTrace(spName, paras))
            {
                try
                {
                    trace.ExecuteStart();
                    using (ConnectionManager mgr = GetConnection())
                    {
                        list = mgr.Connection.Query<T>(spName, paras, mgr.Transaction, false, null, CommandType.StoredProcedure).ToList();
                    }
                }
                catch (Exception ex)
                {
                    trace.ExecuteException(ex);
                    throw;
                }
                return list;
            }
        }

        protected ConnectionManager GetConnection()
        {
            return ConnectionManager.GetManager(this.ConnectionStrings);
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
