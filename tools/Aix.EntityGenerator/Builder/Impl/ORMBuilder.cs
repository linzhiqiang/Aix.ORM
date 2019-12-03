using System;
using System.Collections.Generic;
using System.Text;
using Aix.EntityGenerator.Entity;
using Aix.EntityGenerator.Utils;
using Aix.ORM.Common;

namespace Aix.EntityGenerator.Builder
{
    public class ORMBuilder : BaseEntityBuilder
    {
        public ORMBuilder(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }
        public override string BuildClass(ORMDBType dbType, TableInfo table)
        {
            StringBuilder sb = new StringBuilder();
            int space = 4;
            var dataTypeConvert = DBMetadataFactoryFactory.Instance.GetDBObjectFactory(dbType).GetDataTypeConvert();
            // 注释
            sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space));
            sb.AppendLine();
            sb.AppendFormat("{0}/// {1}", BuilderUtils.BuildSpace(space), Helper.RemoveNewLine(table.TableComment));
            sb.AppendLine();
            sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space));
            sb.AppendLine();

            //class 类名
            string baseEntityName = "BaseEntity";
            sb.AppendFormat("{0}[Table(\"{1}\")]", BuilderUtils.BuildSpace(space), table.TableName);
            sb.AppendLine();
            sb.AppendFormat("{0}public partial class {1} : {2}", BuilderUtils.BuildSpace(space), Helper.GetClassName(table.TableName), baseEntityName);
            sb.AppendLine();
            sb.AppendFormat("{0}{{", BuilderUtils.BuildSpace(space));
            sb.AppendLine();

            //私有字段
            foreach (var item in table.Columns)
            {
                string dateType = dataTypeConvert.ConvertDataType(item.DataType, item.ColumnIsNullable());
                sb.AppendFormat("{0}private {1} {2}; ", BuilderUtils.BuildSpace(space + 4), dateType, GetFieldName(item.ColumnName));
                sb.AppendLine();
            }
            sb.AppendLine();

            ////class 属性
            foreach (var item in table.Columns)
            {
                sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();
                sb.AppendFormat("{0}/// {1}", BuilderUtils.BuildSpace(space + 4), Helper.RemoveNewLine(item.ColumnComment));
                sb.AppendLine();
                sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();



                sb.AppendFormat("{0}[Column(\"{1}\")]", BuilderUtils.BuildSpace(space + 4), item.ColumnName);
                sb.AppendLine();

                if (table.PrimaryKeys.Exists(c => c.ColumnName == item.ColumnName))
                {
                    sb.AppendFormat("{0}[PrimaryKey]", BuilderUtils.BuildSpace(space + 4));
                    sb.AppendLine();
                }
                if (item.IsAutoIncrement())
                {
                    sb.AppendFormat("{0}[Identity]", BuilderUtils.BuildSpace(space + 4));
                    sb.AppendLine();
                }


                string dateType = dataTypeConvert.ConvertDataType(item.DataType, item.ColumnIsNullable());
                sb.AppendFormat("{0}public {1} {2}", BuilderUtils.BuildSpace(space + 4), dateType, Helper.GetPropertyName(item.ColumnName));
                sb.AppendLine();

                sb.AppendFormat("{0}{{", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();

                sb.AppendFormat("{0}get {{ return {1}; }}", BuilderUtils.BuildSpace(space + 8), GetFieldName(item.ColumnName));
                sb.AppendLine();
                sb.AppendFormat("{0}set {{ {1} = value; OnPropertyChanged(\"{2}\"); }}",
                    BuilderUtils.BuildSpace(space + 8), GetFieldName(item.ColumnName), item.ColumnName);
                sb.AppendLine();



                sb.AppendFormat("{0}}}", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();
            }

            sb.AppendFormat("{0}}}", BuilderUtils.BuildSpace(space));
            sb.AppendLine();
            return sb.ToString();
        }

        private string GetFieldName(string columnName)
        {
            return string.Format("_{0}", char.ToLower(columnName[0]) + (columnName.Length > 1 ? columnName.Substring(1) : ""));
        }
    }
}
