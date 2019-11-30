using Aix.EntityGenerator.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Metadata
{
    public interface IDBMetadata
    {
        string ConnectionStrings { get; }
        string GetDBName();

        List<TableInfo> QueryTable();

        List<ColumnInfo> QueryColumn();

        List<PrimaryKey> QueryPrimaryKey();
    }
}
