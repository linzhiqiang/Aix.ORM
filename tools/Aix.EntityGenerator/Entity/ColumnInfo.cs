using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Entity
{
    /// <summary>
    /// 列信息
    /// </summary>
    public class ColumnInfo
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }

        public string IsNullable { get; set; }

        public string DataType { get; set; }

        public string ColumnComment { get; set; }

        public string AutoIncrement { get; set; }

        /// <summary>
        /// 列的定义 如 mysql varchar(100) ,sqlserver和DataType一样
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// sqlserver 直接有，mysql需要从ColumnType中解析
        /// </summary>
        public int MaxLength { get; set; }

        public string DefaultValue { get; set; }

        public bool IsAutoIncrement()
        {
            if (!string.IsNullOrEmpty(this.AutoIncrement))
            {
                return this.AutoIncrement.ToLower() == "auto_increment" || this.AutoIncrement == "1" || this.AutoIncrement.ToLower() == "true";
            }
            return false;
        }

        public bool ColumnIsNullable()
        {
            if (!string.IsNullOrEmpty(this.IsNullable))
            {
                return this.IsNullable.ToLower() == "yes" || this.IsNullable == "1" || this.IsNullable.ToLower() == "true";
            }
                return false;
        }


    }
}
