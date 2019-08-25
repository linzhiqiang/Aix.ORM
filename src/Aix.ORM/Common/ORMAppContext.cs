using Aix.ORM.DBConnectionManager;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Threading;

namespace Aix.ORM.Common
{
    public class ORMAppContextOld
    {
        #region 上下文级别的

        private const string _localContextName = "ORMAppContext.ConnectionContext";

        public static HybridDictionary ConnectionContext
        {
            get
            {
                HybridDictionary ctx = CallContext.GetData(_localContextName) as HybridDictionary;
                if (ctx == null)
                {
                    ctx = new HybridDictionary();
                    CallContext.SetData(_localContextName, ctx);
                }
                return ctx;
            }
        }


        #endregion
    }

    public interface IConnectionContext
    {
        bool Contains(string key);
        void Add(string key, ConnectionManager value);

        ConnectionManager Get(string key);

        void Remove(string key);

        void OpenNewConnectionContext();
    }

    public class ConnectionContext : IConnectionContext
    {
        public static IConnectionContext Instance = new ConnectionContext();

        #region 上下文级别的

        private static AsyncLocal<ConcurrentDictionary<string, ConnectionManager>> AsyncLocalData =
            new AsyncLocal<ConcurrentDictionary<string, ConnectionManager>> { Value = new ConcurrentDictionary<string, ConnectionManager>() };

        private ConcurrentDictionary<string, ConnectionManager> GetData()
        {
            if (AsyncLocalData.Value == null) AsyncLocalData.Value = new ConcurrentDictionary<string, ConnectionManager>();
            return AsyncLocalData.Value;
        }
        public void OpenNewConnectionContext()
        {
            AsyncLocalData.Value = new ConcurrentDictionary<string, ConnectionManager>();
        }

        public bool Contains(string key)
        {
            return GetData().ContainsKey(key);
        }

        public void Add(string key, ConnectionManager value)
        {
            GetData().AddOrUpdate(key, value, (k, v) => value);
        }

        public ConnectionManager Get(string key)
        {
            if (GetData().TryGetValue(key, out ConnectionManager value))
            {
                return value;
            }
            return null;
        }

        public void Remove(string key)
        {
            GetData().TryRemove(key, out ConnectionManager value);
        }

        #endregion
    }
}
