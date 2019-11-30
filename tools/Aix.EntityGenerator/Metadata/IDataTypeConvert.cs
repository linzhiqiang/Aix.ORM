using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Metadata
{
    /// <summary>
    /// 数据类型装换 db数据类型->.net数据类型
    /// </summary>
    public interface IDataTypeConvert
    {
        string ConvertDataType(string dbType, bool isNullable);
    }
}
