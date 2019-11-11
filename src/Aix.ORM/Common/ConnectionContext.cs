using Aix.ORM.DBConnectionManager;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Threading;

namespace Aix.ORM.Common
{
    public class ConnectionContext : CallContext< ConnectionManager>
    {
        public static ICallContext<ConnectionManager> Instance = new ConnectionContext();

        private ConnectionContext()
        { 
        
        }
    }
    /*
    public interface IConnectionContext
    {
        void OpenNewConnectionContext();
        bool Contains(string key);
        void Set(string key, ConnectionManager value);

        ConnectionManager Get(string key);

        void Remove(string key);
    }

    public class ConnectionContextOld : IConnectionContext
    {
        public static IConnectionContext Instance = new ConnectionContextOld();

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

        public void Set(string key, ConnectionManager value)
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

    }
    */
}
