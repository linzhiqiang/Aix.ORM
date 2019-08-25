using Aix.EntityGenerator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator
{
    public interface IDBMetadata
    {
        string GetDBName();

        List<TableInfo> QueryTable(string db);

        List<ColumnInfo> QueryColumn(string db);

        List<PrimaryKey> QueryPrimaryKey(string db);
    }
}
