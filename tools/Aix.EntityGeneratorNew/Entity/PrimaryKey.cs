using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Entity
{
    /// <summary>
    /// 主键信息
    /// </summary>
    public class PrimaryKey
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
    }
}
