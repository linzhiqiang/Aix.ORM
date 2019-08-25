using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public class SQLBuilderFactory
    {
        public static SQLBuilderFactory Instance = new SQLBuilderFactory();

        private ISQLBuilder MsSql = new MsSqlSQLBuilder();

        private ISQLBuilder MySql = new MySqlSQLBuilder();

        public ISQLBuilder GetSQLBuilder(ORMDBType type)
        {
            switch (type)
            {
                case ORMDBType.MsSql:
                    return MsSql;

                case ORMDBType.MySql:
                    return MySql;

                case ORMDBType.Oracle:
                    throw new Exception("未实现OracleSQLBuilder");
                default:
                    throw new Exception("不存在的数据库类型");

            }


        }
    }
}
