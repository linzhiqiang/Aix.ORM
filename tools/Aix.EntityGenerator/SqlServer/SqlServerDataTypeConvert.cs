using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.SqlServer
{
    public class SqlServerDataTypeConvert : IDataTypeConvert
    {
        public string ConvertDataType(string dbType, bool isNullable)
        {

            string dataType = string.Empty;
            switch (dbType)
            {
                case "bigint":
                case "timestamp":
                    dataType = "long";
                    break;
                case "int":
                    dataType = "int";
                    break;
                case "smallint":
                    dataType = "short";
                    break;
                case "tinyint":
                    dataType = "byte";
                    break;
                case "decimal":
                case "float":
                case "money":
                case "numeric":
                case "real":
                    dataType = "decimal";
                    break;
                case "bit":
                    dataType = "bool";
                    break;

                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    dataType = "DateTime";
                    break;

                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "uniqueidentifier":
                case "xml":
                    dataType = "string";
                    break;

                case "binary":
                case "varbinary":
                    dataType = "byte[]";
                    break;

                default:
                    throw new Exception("没有对应的数据类型");

            }
            if (isNullable)
            {
                if (dataType != "string" && dataType != "byte[]")
                {
                    dataType = dataType + "?";
                }
            }

            return dataType;
        }
    }
}
