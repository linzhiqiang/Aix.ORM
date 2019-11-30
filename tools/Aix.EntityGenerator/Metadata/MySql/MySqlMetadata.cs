using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aix.EntityGenerator.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace Aix.EntityGenerator.Metadata
{
    public class MySqlMetadata : IDBMetadata
    {
      public  string ConnectionStrings { get; }

        public MySqlMetadata(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public string GetDBName()
        {
            return Get<string>("SELECT DATABASE()", null);
        }

        public List<TableInfo> QueryTable()
        {
            var db = GetDBName();
            string sql = "SELECT TABLE_NAME as TableName  FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA=@db and Table_type='BASE TABLE' order by TABLE_NAME";
            object param = new { db = db };
            return Query<TableInfo>(sql, param);
        }

        public List<ColumnInfo> QueryColumn()
        {
            var db = GetDBName();
            string sql = @"SELECT a.TABLE_NAME as TableName ,COLUMN_NAME as ColumnName ,IS_NULLABLE as IsNullable,DATA_TYPE as DataType,COLUMN_KEY,COLUMN_COMMENT as ColumnComment,EXTRA as AutoIncrement
                        FROM INFORMATION_SCHEMA.columns a
                        inner JOIN  INFORMATION_SCHEMA.TABLES  b on a.TABLE_SCHEMA=b.TABLE_SCHEMA and a.TABLE_NAME=b.TABLE_NAME and Table_type='BASE TABLE'    
                        where a.TABLE_SCHEMA=@db order by b.TABLE_NAME, a.ORDINAL_POSITION";
            object param = new { db = db };
            return Query<ColumnInfo>(sql, param);
        }

        public List<PrimaryKey> QueryPrimaryKey()
        {
            var db = GetDBName();
            string sql = @"SELECT k.TABLE_NAME as TableName ,k.COLUMN_NAME as ColumnName from INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
                        JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS c  ON k.TABLE_SCHEMA = c.TABLE_SCHEMA and k.table_name = c.table_name  and  k.CONSTRAINT_NAME = c.CONSTRAINT_NAME
                        where k.TABLE_SCHEMA=@db and  c.CONSTRAINT_TYPE='PRIMARY KEY' order by k.TABLE_NAME, ORDINAL_POSITION ";
            object param = new { db = db };
            return Query<PrimaryKey>(sql, param);
        }


        #region private 

        private T Get<T>(string sql, object paras)
        {
            return Query<T>(sql, paras).FirstOrDefault();
        }

        private List<T> Query<T>(string sql, object paras)
        {
            List<T> list = null;
            using (MySqlConnection connection = new MySqlConnection(ConnectionStrings))
            {
                list = connection.Query<T>(sql, paras).ToList();
            }
            return list;
        }

        #endregion
    }
}
