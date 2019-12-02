using Aix.EntityGenerator.Entity;
using Aix.EntityGenerator.Metadata;
using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aix.EntityGenerator.Builder
{
    public  class DBMetadataWrapper
    {
        private DBObjectFactoryFactory _dBObjectFactoryFactory;
        public DBMetadataWrapper(DBObjectFactoryFactory dBObjectFactoryFactory)
        {
            _dBObjectFactoryFactory = dBObjectFactoryFactory;
        }
        public  DBMetadataDTO GetTableInfo(ORMDBType dbType, string connectionString)
        {
            Dictionary<string, TableInfo> dict = new Dictionary<string, TableInfo>();
            IDBMetadata dBMetadata = _dBObjectFactoryFactory.GetDBObjectFactory(dbType).GetDBMetadata(connectionString);

            string dbName = dBMetadata.GetDBName();
            List<TableInfo> tables = dBMetadata.QueryTable();

            List<ColumnInfo> columns = dBMetadata.QueryColumn();

            List<PrimaryKey> primaryKeys = dBMetadata.QueryPrimaryKey();

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

            return new DBMetadataDTO {
                DBName = dbName,
                TableInfos = dict.Values.ToList()
            };
        }
    }
}
