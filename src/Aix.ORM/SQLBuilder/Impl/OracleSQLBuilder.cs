using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public class OracleSQLBuilder : ISQLBuilder
    {
        public string BuildDeleteByPkSql(EntityMeta meta)
        {
            throw new NotImplementedException();
        }

        public string BuildDeleteSqlByProperty(EntityMeta meta, List<string> propertyNames)
        {
            throw new NotImplementedException();
        }

        public string BuildInsertSql(EntityMeta meta)
        {
            throw new NotImplementedException();
        }

        public string BuildInsertSql(EntityMeta meta, List<string> list)
        {
            throw new NotImplementedException();
        }

        public string BuildReplaceInsertSQL(EntityMeta meta)
        {
            throw new NotImplementedException();
        }

        public string BuildSelectByPkSql(EntityMeta meta)
        {
            throw new NotImplementedException();
        }

        public string BuildUpdateSql(EntityMeta meta)
        {
            throw new NotImplementedException();
        }

        public string BuildUpdateSql(EntityMeta meta, List<string> list)
        {
            throw new NotImplementedException();
        }

        public string GetAllColumns(EntityMeta meta, string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
