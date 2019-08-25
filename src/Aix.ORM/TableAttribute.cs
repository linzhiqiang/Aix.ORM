using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
        public string TableName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public ColumnAttribute(string column)
        {
            this.ColumnName = column;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IdentityAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}
