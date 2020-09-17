using Aix.ORM.Common;
using Aix.ORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<Action> TransactionCommitCallbacks = new List<Action>();

        #endregion

        #region 静态方法
        private static object _lock = new object();
        public static ConnectionManager GetManager(string connectionString, ORMDBType dbType)
        {
            AssertUtils.IsNotEmpty(connectionString, "连接字符串为空");
            ConnectionManager mgr = null;
            if (!ConnectionContext.Instance.Contains(connectionString))
                lock (_lock)
                {
                    if (!ConnectionContext.Instance.Contains(connectionString))
                    {
                        mgr = new ConnectionManager(connectionString, dbType);
                        ConnectionContext.Instance.Set(connectionString, mgr);
                    }
                }
            mgr = ConnectionContext.Instance.Get(connectionString);

            mgr.AddRefCount();
            return mgr;
        }
        #endregion

        #region 构造
        private ConnectionManager(string connectionString, ORMDBType dbType)
        {
            _dbConnectionString = connectionString;
            _connection = ConnectionFactoryFactory.Instance.GetConnectionFactory().CreateConnection(connectionString, dbType);
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

        #region 事务完成回调

        public void AddTransactionCommitCallback(Action action)
        {
            if (action != null)
            {
                TransactionCommitCallbacks.Add(action);
            }
        }

        public void  ExecuteTransactionCommitCallback()
        {
            List<Exception> exceptions = new List<Exception>();
            try
            {
                foreach (var action in TransactionCommitCallbacks)
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }
            }
            finally
            {
                TransactionCommitCallbacks.Clear();
            }

            if (exceptions.Count > 0)
            {
                throw exceptions.First();
            }
        }

        #endregion

        #endregion


        #region  计数器

        private int _refCount;
        public int RefCount => this._refCount;

        private void AddRefCount()
        {
            _refCount += 1;
        }

        private object _releaseLock = new object();
        private void DeRefCount()
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
            DeRefCount();
        }
        #endregion


    }
}
