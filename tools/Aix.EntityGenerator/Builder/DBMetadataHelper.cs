using Aix.EntityGenerator.Entity;
using Aix.EntityGenerator.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Builder
{
    public static class DBMetadataHelper
    {
        public static Dictionary<string, TableInfo> GetTableInfo()
        {
            Dictionary<string, TableInfo> dict = new Dictionary<string, TableInfo>();
            IDBMetadata dBMetadata = DBObjectFactoryFactory.Instance.GetDBObjectFactory().GetDBMetadata();

            string dbName = dBMetadata.GetDBName();
            List<TableInfo> tables = dBMetadata.QueryTable(dbName);

            List<ColumnInfo> columns = dBMetadata.QueryColumn(dbName);

            List<PrimaryKey> primaryKeys = dBMetadata.QueryPrimaryKey(dbName);

            foreach (var item in tables)
            {
                dict.Add(item.TableName, item);
            }

            foreach (var item in columns)
            {
                string tableName = item.TableName;
                if (!dict.ContainsKey(tableName))
                    continue;
                dict[tableName].Columns.Add(item);
            }

            foreach (var item in primaryKeys)
            {
                string tableName = item.TableName;
                if (!dict.ContainsKey(tableName))
                    continue;
                dict[tableName].PrimaryKeys.Add(item);
            }

            return dict;


        }
    }
}
