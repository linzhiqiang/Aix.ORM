using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Metadata
{
    public class MySqlDataTypeConvert : IDataTypeConvert
    {
        public string ConvertDataType(string dbType, bool isNullable)
        {

            string dataType = string.Empty;
            switch (dbType)
            {
                case "enum":
                case "timestamp":
                case "bigint":
                    dataType = "long";
                    break;

                case "int":
                case "integer":
                case "year":
                    dataType = "int";
                    break;

                case "smallint":
                    dataType = "short";
                    break;

                case "tinyint":
                    dataType = "sbyte";
                    break;

                case "decimal":
                case "float":
                case "double":
                case "money":
                case "numeric":
                case "real":
                    dataType = "decimal";
                    break;

                case "bit":
                    dataType = "bool";
                    break;

                case "date":
                case "time":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    dataType = "DateTime";
                    break;

                case "char":
                case "varchar":
                case "text":
                case "tinytext":
                case "mediumtext":
                case "longtext":
                case "uniqueidentifier":
                case "xml":
                    dataType = "string";
                    break;

                case "binary":
                case "varbinary":
                case "blob":
                case "tinyblob":
                case "mediumblob":
                case "longblob":
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
