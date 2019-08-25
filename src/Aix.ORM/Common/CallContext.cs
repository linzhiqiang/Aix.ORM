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
    internal static class CallContext
    {
        static AsyncLocal<ConcurrentDictionary<string, object>> _asyncLocal = new AsyncLocal<ConcurrentDictionary<string, object>>();

        public static ConcurrentDictionary<string, object> _context
        {
            get
            {
                if (_asyncLocal.Value == null) _asyncLocal.Value = new ConcurrentDictionary<string, object>();
                return _asyncLocal.Value;
            }
        }

        public static void SetData(string name, object value)
        {
            _context.AddOrUpdate(name, value, (k, v) => value);
        }

        public static object GetData(string name)
        {
            if (_context.TryGetValue(name, out object value))
            {
                return value;
            }
            return null;
        }

        public static void FreeNamedDataSlot(string name)
        {
            _context.TryRemove(name, out object value);
        }



    }

}
