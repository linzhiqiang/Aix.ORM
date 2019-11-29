using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM
{
    /// <summary>
    /// 实体类的特性 对应数据库表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
        public string TableName { get; private set; }
    }

    /// <summary>
    /// 属性特性 对应数据路列信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public ColumnAttribute(string column)
        {
            this.ColumnName = column;
        }
    }

    /// <summary>
    /// 属性特性 对应列是否为主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {

    }

    /// <summary>
    /// 属性特性 对应列是否为自增列
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentityAttribute : Attribute
    {
    }

}
