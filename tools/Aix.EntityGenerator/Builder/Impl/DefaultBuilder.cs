using System;
using System.Collections.Generic;
using System.Text;
using Aix.EntityGenerator.Entity;
using Aix.EntityGenerator.Utils;
using Aix.ORM.Common;

namespace Aix.EntityGenerator.Builder
{
    public class DefaultBuilder : BaseEntityBuilder
    {
        public DefaultBuilder(IServiceProvider serviceProvider)
            :base(serviceProvider)
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
            sb.AppendFormat("{0}public partial class {1}", BuilderUtils.BuildSpace(space), Helper.GetClassName(table.TableName));
            sb.AppendLine();
            sb.AppendFormat("{0}{{", BuilderUtils.BuildSpace(space));
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

                string dateType = dataTypeConvert.ConvertDataType(item.DataType, item.ColumnIsNullable());
                sb.AppendFormat("{0}public {1} {2} {{ get; set; }}", BuilderUtils.BuildSpace(space + 4), dateType, Helper.GetPropertyName(item.ColumnName));
                sb.AppendLine();
            }

            sb.AppendFormat("{0}}}", BuilderUtils.BuildSpace(space));
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
