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
    public class BaseMySqlRepository : MySqlRepository
    {
        protected IServiceProvider _provider;
        public BaseMySqlRepository(IServiceProvider provider, string connectionStrings) : base(connectionStrings)
        {
            _provider = provider;
        }

        protected override AbstractSqlExecuteTrace GetSqlExecuteTrace(string sql, object paras)
        {
            return new SqlExecuteTrace(sql, paras, _provider);
        }
    }

    
}
