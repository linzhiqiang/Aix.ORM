using Aix.ORM.Common;
using Aix.ORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Aix.ORM.DBConnectionManager
{
    /// <summary>
    /// 连接管理
    /// </summary>
    public class ConnectionManager : IDisposable
    {
        #region  属性和字段

        private string _dbConnectionString;
        private IDbConnection _connection;
        /// <summary>
        /// 当前连接开启的事务，只记录最后一下事务（可能会开启多次，嵌套事务）
        /// </summary>
        private IDbTransaction _transaction;

        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }
        #endregion

        #region 静态方法
        private static object _lock = new object();
        public static ConnectionManager GetManager(string connectionString)
        {
            AssertUtils.IsNotEmpty(connectionString, "连接字符串为空");
            ConnectionManager mgr = null;
            if (!ConnectionContext.Instance.Contains(connectionString))
                lock (_lock)
                {
                    if (!ConnectionContext.Instance.Contains(connectionString))
                    {
                        //Console.WriteLine("获取新连接");
                        mgr = new ConnectionManager(connectionString);
                        ConnectionContext.Instance.Add(connectionString, mgr);
                    }
                }
            mgr = ConnectionContext.Instance.Get(connectionString);

            mgr.AddRef();
            return mgr;
        }
        #endregion

        #region 构造
        private ConnectionManager(string connectionString)
        {
            _dbConnectionString = connectionString;
            _connection = ConnectionFactory.Instance.GetConnectionFactory().CreateConnection(connectionString);
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        #endregion

        #region  public
        public IDbTransaction BeginTransaction()
        {
            _transaction = this.Connection.BeginTransaction();
            return _transaction;
        }

        public bool IsExistDbTransaction()
        {
            return Transaction != null;
        }
        #endregion

        #region  计数器

        private int _refCount;
        public int RefCount => this._refCount;

        private void AddRef()
        {
            _refCount += 1;
        }

        private object _releaseLock = new object();
        private void DeRef()
        {
            lock (_releaseLock)
            {
                _refCount -= 1;
                if (_refCount == 0)
                {
                    try
                    {
                        if (_connection != null && _connection.State != ConnectionState.Closed)
                        {
                            _connection.Close();
                            //Console.WriteLine("连接关闭");
                        }
                    }
                    finally
                    {
                        ConnectionContext.Instance.Remove(_dbConnectionString);
                    }

                }
            }

        }

        #endregion

        #region  IDisposable
        public void Dispose()
        {
            DeRef();
        }
        #endregion


    }
}
