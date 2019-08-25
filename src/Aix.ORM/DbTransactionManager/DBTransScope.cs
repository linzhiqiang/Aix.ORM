using Aix.ORM.DBConnectionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Aix.ORM.DbTransactionManager
{
    public interface IDBTransScope : IDisposable
    {
        void Commit();

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

        public DBTransScope(string connectionStrings) : this(connectionStrings, TransScopeOption.Required)
        {
        }

        public DBTransScope(string connectionStrings, TransScopeOption option)
        {
            //如果有多数据库，再开放个构造函数 传递数据库连接字符串
            _connectionManager = ConnectionManager.GetManager(connectionStrings);
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
            if (!_completed)
            {
                Rollback();
            }

            _connectionManager.Dispose();
        }


        #region IDisposable 成员

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}
