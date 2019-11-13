using Aix.ORM;
using Aix.ORM.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Aix.ORMSample.Repository
{
    public class BaseRepository : MySqlRepository// MySqlRepository// MsSqlRepository
    {
        protected IServiceProvider _provider;
        public BaseRepository(IServiceProvider provider, string connectionStrings) : base(connectionStrings)
        {
            _provider = provider;
        }

        protected override ISqlExecuteTrace GetSqlExecuteTrace()
        {
            return new SqlExecuteTrace(_provider);
        }
    }

    public class SqlExecuteTrace : ISqlExecuteTrace
    {
        protected IServiceProvider _provider;
        private ILogger<SqlExecuteTrace> _logger;

        private string _sql;
        private object _param;
        private Stopwatch _stopwatch;

        public SqlExecuteTrace(IServiceProvider provider)
        {
            _provider = provider;
            _logger = provider.GetService<ILogger<SqlExecuteTrace>>();
        }
        public void ExecuteStart(string sql, object parm)
        {
            _sql = sql;
            _param = parm;
            _stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            _stopwatch.Stop();

            var totalTime = _stopwatch.ElapsedMilliseconds;

            if (totalTime > 500)
            {
                _logger.LogWarning("SQL EXECUTE Finished in {0} ms,SQL={1},params = {2}", totalTime, _sql, _param ?? "");
            }
            else
            {
                _logger.LogDebug("SQL EXECUTE Finished in {0} ms,SQL={1},params = {2}", totalTime, _sql, _param ?? "");
            }
        }



    }
}
