using Aix.ORM;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Aix.ORMSample.Common.Utils;

namespace Aix.ORMSample.Repository
{
    /// <summary>
    /// sql执行 跟踪
    /// </summary>
    public class SqlExecuteTrace : AbstractSqlExecuteTrace
    {
        protected IServiceProvider _provider;
        private ILogger<SqlExecuteTrace> _logger;
        private Stopwatch _stopwatch;

        public SqlExecuteTrace(string sql, object paras, IServiceProvider provider) : base(sql, paras)
        {
            _provider = provider;
            _logger = provider.GetService<ILogger<SqlExecuteTrace>>();
        }
        public override void ExecuteStart()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public override void ExecuteException(Exception ex)
        {
            _logger.LogError("SQL执行失败,  SQL={0},params = {1},Message={2},StackTrace={3}", Sql, JsonUtils.ToJson(Param), ex.Message, ex.StackTrace);
        }
        public override void ExecuteEnd()
        {
            _stopwatch.Stop();

            var totalTime = _stopwatch.ElapsedMilliseconds;

            if (totalTime > 500)
            {
                _logger.LogWarning("SQL执行警告 in {0} ms,SQL={1},params = {2}", totalTime, Sql, JsonUtils.ToJson(Param));
            }
            else
            {
                _logger.LogDebug("SQL执行跟踪 in {0} ms,SQL={1},params = {2}", totalTime, Sql, JsonUtils.ToJson(Param));
            }
        }



    }
}
