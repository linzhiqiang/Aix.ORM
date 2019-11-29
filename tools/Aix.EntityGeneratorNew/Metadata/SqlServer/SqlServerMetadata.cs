using Aix.EntityGenerator.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Aix.EntityGeneratorNew.Metadata
{
    public class SqlServerMetadata : IDBMetadata
    {
        public string ConnectionStrings { get; }

        public SqlServerMetadata(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public string GetDBName()
        {
            return Get<string>("SELECT db_name()", null);
        }

        public List<TableInfo> QueryTable()
        {
            var db = GetDBName();
            //string sql = "SELECT TABLE_NAME as TableName  FROM INFORMATION_SCHEMA.TABLES where  Table_type='BASE TABLE'";
            string sql = @"select a.name as TableName,b.value as TableComment from sys.objects  a
                    left join sys.extended_properties b on a.object_id=b.major_id and b.minor_id =0 and b.name='MS_Description'
                    where type='U' order by a.name";
            object param = new { db = db };
            return Query<TableInfo>(sql, param);
        }

        public List<ColumnInfo> QueryColumn()
        {
            var db = GetDBName();
            //string sql = @"SELECT a.TABLE_NAME as TableName ,COLUMN_NAME as ColumnName ,IS_NULLABLE as IsNullable,DATA_TYPE as DataType
            //            FROM INFORMATION_SCHEMA.columns a
            //            inner JOIN  INFORMATION_SCHEMA.TABLES  b on a.TABLE_NAME=b.TABLE_NAME and Table_type='BASE TABLE'    
            //            ";
            string sql = @"select b.name as TableName,a.name as ColumnName,c.name as DataType,a.is_nullable as IsNullable,is_identity as AutoIncrement,d.value as ColumnComment
	                from sys.columns a
	                inner join sys.objects b on b.object_id=a.object_id
	                inner join sys.types c on c.user_type_id=a.user_type_id
	                left join sys.extended_properties d on d.major_id=b.object_id and d.minor_id=a.column_id and d.name='MS_Description'
	                where b.type='U' order by b.name,a.column_id";
            object param = new { db = db };
            return Query<ColumnInfo>(sql, param);
        }

        public List<PrimaryKey> QueryPrimaryKey()
        {
            var db = GetDBName();
            //string sql = @"SELECT k.TABLE_NAME as TableName ,k.COLUMN_NAME as ColumnName from INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
            //            JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS c  ON k.TABLE_SCHEMA = c.TABLE_SCHEMA and k.table_name = c.table_name  and  k.CONSTRAINT_NAME = c.CONSTRAINT_NAME
            //            where  c.CONSTRAINT_TYPE='PRIMARY KEY' ";
            string sql = @"select e.name as TableName,d.name as ColumnName from sys.key_constraints a 
                    inner join sys.indexes b on a.parent_object_id=b.object_id and a.name=b.name
                    inner join sys.index_columns c on c.object_id=b.object_id and c.index_id=b.index_id
                    inner join sys.columns d on d.object_id=c.object_id and d.column_id=c.column_id
                    inner join sys.objects e on e.object_id=d.object_id order by e.name,d.column_id";
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
            using (SqlConnection connection = new SqlConnection(ConnectionStrings))
            {
                list = connection.Query<T>(sql, paras).ToList();
            }
            return list;
        }

        #endregion
    }
}
