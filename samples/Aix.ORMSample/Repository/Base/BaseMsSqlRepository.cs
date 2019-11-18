using Aix.ORM;
using Aix.ORM.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORMSample.Repository
{
  public  class BaseMsSqlRepository : MsSqlRepository
    {
        protected IServiceProvider _provider;
        public BaseMsSqlRepository(IServiceProvider provider, string connectionStrings) : base(connectionStrings)
        {
            _provider = provider;
        }

        protected override AbstractSqlExecuteTrace GetSqlExecuteTrace(string sql, object paras)
        {
            return new SqlExecuteTrace(sql, paras, _provider);
        }
    }
}
