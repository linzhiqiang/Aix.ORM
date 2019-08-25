using Aix.EntityGenerator.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Builder
{


    public class DefaultBuilder : BaseEntityBuilder
    {
        protected override string BuildClass(TableInfo table)
        {
            StringBuilder sb = new StringBuilder();
            int space = 4;

            // 注释
            sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space));
            sb.AppendLine();
            sb.AppendFormat("{0}/// {1}", BuilderUtils.BuildSpace(space), RemoveNewLine(table.TableComment));
            sb.AppendLine();
            sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space));
            sb.AppendLine();

            //class 类名
            sb.AppendFormat("{0}public partial class {1}", BuilderUtils.BuildSpace(space), GetClassName(table.TableName));
            sb.AppendLine();
            sb.AppendFormat("{0}{{", BuilderUtils.BuildSpace(space));
            sb.AppendLine();

            ////class 属性
            foreach (var item in table.Columns)
            {
                sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();
                sb.AppendFormat("{0}/// {1}", BuilderUtils.BuildSpace(space + 4), RemoveNewLine(item.ColumnComment));
                sb.AppendLine();
                sb.AppendFormat("{0}/// <summary>", BuilderUtils.BuildSpace(space + 4));
                sb.AppendLine();

                string dateType = DataTypeConvert.ConvertDataType(item.DataType, item.ColumnIsNullable());
                sb.AppendFormat("{0}public {1} {2} {{ get; set; }}", BuilderUtils.BuildSpace(space + 4), dateType, item.ColumnName);
                sb.AppendLine();
            }

            sb.AppendFormat("{0}}}", BuilderUtils.BuildSpace(space));
            sb.AppendLine();
            return sb.ToString();
        }

        

    }
}
