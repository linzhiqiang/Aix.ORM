using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM
{
    public interface ISqlExecuteTrace : IDisposable
    {
        void ExecuteStart(string sql, object parm);

    }

    public class DefaultSqlTrace : ISqlExecuteTrace
    {
        public static ISqlExecuteTrace Instance = new DefaultSqlTrace();
        public void Dispose()
        {
        }

        public void ExecuteStart(string sql, object parm)
        {
        }

    }
}
