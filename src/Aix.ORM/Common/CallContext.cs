using System.Collections.Concurrent;
using System.Threading;

namespace Aix.ORM.Common
{
    /// <summary>
    /// 如果是老版本程序，不用task，异步，使用CallContext.SetData(name,value); 就可以，不往下层线程传递
    /// https://www.cnblogs.com/wlhai/p/10818739.html
    /// </summary>

    /// <summary>
    /// 最外层不能直接应用，要包一层，防止key重复
    /// 上下文对象，从每次设置的对象范围 是从当前的task开始，一直到结束.内层嵌套的都可以访问
    /// 引用类型的无论那一层修改了，都影响了
    /// 值类型和string内层修改 不影响上层的
    /// 往下传递是 只是复制引用对象和参数一样
    /// https://www.liujiajia.me/2019/07/29/asynclocal/
    /// </summary>
    /// 

    public interface ICallContext<T>
    {
        void OpenNewContext();
        bool Contains(string key);
        void Set(string key, T value);

        T Get(string key);

        void Remove(string key);
        
    }

    public class CallContext<Child, T>:ICallContext<T>  where Child : ICallContext<T>, new()
    {
        public static ICallContext<T> Instance = new Child();

        static AsyncLocal<ConcurrentDictionary<string, T>> _asyncLocal = new AsyncLocal<ConcurrentDictionary<string, T>>();

        public ConcurrentDictionary<string, T> _context
        {
            get
            {
                if (_asyncLocal.Value == null) _asyncLocal.Value = new ConcurrentDictionary<string, T>();
                return _asyncLocal.Value;
            }
        }

        public void OpenNewContext()
        {
            _asyncLocal.Value = new ConcurrentDictionary<string, T>();
        }

        public bool Contains(string key)
        {
            return _context.ContainsKey(key);
        }

        public void Set(string key, T value)
        {
            _context.AddOrUpdate(key, value, (k, v) => value);
        }

        public T Get(string key)
        {
            if (_context.TryGetValue(key, out T value))
            {
                return value;
            }
            return default(T);
        }

        public void Remove(string key)
        {
            _context.TryRemove(key, out T value);
        }

    }

}
