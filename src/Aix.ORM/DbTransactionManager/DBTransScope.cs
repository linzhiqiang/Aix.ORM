using Aix.ORM.Common;
using Aix.ORM.DBConnectionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.DbTransactionManager
{
    /// <summary>
    /// 事务操作
    /// </summary>
    public interface IDBTransScope : IDisposable
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();

        /// <summary>
        /// 提交事务 事务完成时回调
        /// </summary>
        /// <param name="action"></param>
        void Commit(Action action);

        /// <summary>
        /// 回滚事务 使用using时未提交或者提交出错会自动回滚，无需手动调用改方法；未使用using时需自行调用改方法
        /// </summary>
        void Rollback();
    }
    /// <summary>
    /// 事务管理
    /// </summary>
    public class DBTransScope : IDBTransScope
    {
        private ConnectionManager _connectionManager;
        private IDbTransaction _tran;
        /// <summary>
        /// 是否是该对象开启的事务(哪个对象负责开启则哪个对象负责提交)
        /// </summary>
        private bool _beginTransactionIsInCurrentTransScope = false;
        private bool _completed = false;

        public DBTransScope(string connectionStrings, ORMDBType dbTyp) : this(connectionStrings, dbTyp, TransScopeOption.Required)
        {
        }

        public DBTransScope(string connectionStrings, ORMDBType dbTyp, TransScopeOption option)
        {
            //如果有多数据库，再开放个构造函数 传递数据库连接字符串
            _connectionManager = ConnectionManager.GetManager(connectionStrings, dbTyp);
            if (!_connectionManager.IsExistDbTransaction() || option == TransScopeOption.RequiresNew)
            {
                _tran = _connectionManager.BeginTransaction();
                _beginTransactionIsInCurrentTransScope = true;
            }
            else
            {
                _tran = _connectionManager.Transaction;
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            if (_beginTransactionIsInCurrentTransScope && _tran != null)
            {
                _tran.Commit();
                _completed = true;

                ExecuteTransactionCommitCallback();
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="func">事务提交时 执行的任务</param>
        public void Commit(Action action)
        {
            AddTransactionCommitCallback(action);
            this.Commit();
        }

        private void AddTransactionCommitCallback(Action action)
        {
            if (action != null)
            {
                _connectionManager.AddTransactionCommitCallback(action);
            }
        }

        /// <summary>
        /// 执行回调
        /// </summary>
        /// <returns></returns>
        private void ExecuteTransactionCommitCallback()
        {
            if (_completed)
            {
                _connectionManager.ExecuteTransactionCommitCallback();
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            if (_beginTransactionIsInCurrentTransScope && _tran != null)
            {
                _tran.Rollback();
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            try
            {
                if (!_completed) //事务没有提交或者 没有提交成功
                {
                    Rollback();
                }
            }
            finally
            {
                _connectionManager.Dispose();
            }
        }


        #region IDisposable 成员

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}
