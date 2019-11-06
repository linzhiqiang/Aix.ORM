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
        public string GetAllColumns<T>(string prefix="")where T:BaseEntity
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
            using (ConnectionManager mgr = GetConnection())
            {
                string sql = SQLBuilderHelper.GetInsertSql(entity, this.GetORMDBType());
                ret = mgr.Connection.QuerySingle<long>(sql, entity, mgr.Transaction, null, CommandType.Text);
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


        public int Delete(BaseEntity model)
        {
            string sql = SQLBuilderHelper.GetDeleteByPkSql(model, this.GetORMDBType());
            return this.Excute(sql, model);
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
            using (ConnectionManager mgr = GetConnection())
            {
                ret = mgr.Connection.Execute(sql, paras, mgr.Transaction, timeOut, CommandType.Text);
            }
            return ret;
        }



        protected T Get<T>(string sql, object paras)
        {
            return Query<T>(sql, paras).FirstOrDefault();
        }



        protected List<T> Query<T>(string sql, object paras)
        {
            return Query<T>(sql, null, paras);
        }

        protected List<T> Query<T>(string sql, int? timeOut, object paras)
        {
            List<T> list = null;
            using (ConnectionManager mgr = GetConnection())
            {
                list = mgr.Connection.Query<T>(sql, paras, mgr.Transaction, false, timeOut, CommandType.Text).ToList();
            }
            return list;
        }

        protected int SPExcute(string spName, object paras)
        {
            int ret = -1;
            using (ConnectionManager mgr = GetConnection())
            {
                ret = mgr.Connection.Execute(spName, paras, mgr.Transaction, null, CommandType.StoredProcedure);
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
            using (ConnectionManager mgr = GetConnection())
            {
                list = mgr.Connection.Query<T>(spName, paras, mgr.Transaction, false, null, CommandType.StoredProcedure).ToList();
            }
            return list;
        }

        protected ConnectionManager GetConnection()
        {
            return ConnectionManager.GetManager(this.ConnectionStrings);
        }

        protected abstract ORMDBType GetORMDBType();
    }


}
