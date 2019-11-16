using Aix.ORM;
using Aix.ORM.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Aix.ORMSample.Common.Utils;

namespace Aix.ORMSample.Repository
{
    public class BaseRepository : MySqlRepository
    {
        protected IServiceProvider _provider;
        public BaseRepository(IServiceProvider provider, string connectionStrings) : base(connectionStrings)
        {
            _provider = provider;
        }

        protected override AbstractSqlExecuteTrace GetSqlExecuteTrace(string sql, object paras)
        {
            return new MySqlExecuteTrace(sql, paras, _provider);
        }
    }

    /// <summary>
    /// sql执行 跟踪
    /// </summary>
    public class MySqlExecuteTrace : AbstractSqlExecuteTrace
    {
        protected IServiceProvider _provider;
        private ILogger<MySqlExecuteTrace> _logger;
        private Stopwatch _stopwatch;

        public MySqlExecuteTrace(string sql, object paras, IServiceProvider provider) : base(sql, paras)
        {
            _provider = provider;
            _logger = provider.GetService<ILogger<MySqlExecuteTrace>>();
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
