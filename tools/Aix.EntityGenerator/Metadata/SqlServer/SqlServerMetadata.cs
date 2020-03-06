using Aix.EntityGenerator.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Metadata
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
            //var db = GetDBName();
            string sql = @"select a.name as TableName,b.value as TableComment from sys.objects  a
                    left join sys.extended_properties b on a.object_id=b.major_id and b.minor_id =0 and b.name='MS_Description'
                    where type='U' order by a.name";
            // object param = new { db = db };
            return Query<TableInfo>(sql, null);
        }

        public List<ColumnInfo> QueryColumn()
        {
            // var db = GetDBName();
            string sql = @"select b.name as TableName,a.name as ColumnName,c.name as DataType ,a.is_nullable as IsNullable,is_identity as AutoIncrement,d.value as ColumnComment, a.max_length as MaxLength, e.text as DefaultValue
	                from sys.columns a
	                inner join sys.objects b on b.object_id=a.object_id
	                inner join sys.types c on c.user_type_id=a.user_type_id
	                left join sys.extended_properties d on d.major_id=b.object_id and d.minor_id=a.column_id and d.name='MS_Description'
                    left join sys.syscomments as e on e.id=a.default_object_id
	                where b.type='U' order by b.name,a.column_id";
            // object param = new { db = db };
            var list = Query<ColumnInfo>(sql, null);
            foreach (var item in list)
            {
                item.ColumnType = $"{item.DataType}({item.MaxLength})"; 
                item.DefaultValue = ParseDefaultValue(item.DefaultValue);
                
            }
            return list;
        }

        public List<PrimaryKey> QueryPrimaryKey()
        {
            // var db = GetDBName();
            string sql = @"select e.name as TableName,d.name as ColumnName from sys.key_constraints a 
                    inner join sys.indexes b on a.parent_object_id=b.object_id and a.name=b.name
                    inner join sys.index_columns c on c.object_id=b.object_id and c.index_id=b.index_id
                    inner join sys.columns d on d.object_id=c.object_id and d.column_id=c.column_id
                    inner join sys.objects e on e.object_id=d.object_id order by e.name,d.column_id";
            //object param = new { db = db };
            return Query<PrimaryKey>(sql, null);
        }

        private string ParseDefaultValue(string defaultValue)
        {
            if (string.IsNullOrEmpty(defaultValue)) return defaultValue;
            var tempStr = defaultValue;
            while (true)
            {
                if (tempStr.StartsWith("(") && tempStr.EndsWith(")"))
                {
                    tempStr = tempStr.Substring(1, tempStr.Length-1) ;
                    tempStr = tempStr.Substring(0, tempStr.Length - 1);
                }
                else
                {
                    break;
                }
            }

            return tempStr;
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
