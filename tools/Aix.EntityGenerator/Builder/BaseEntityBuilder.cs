using Aix.EntityGenerator.Entity;
using Aix.EntityGenerator.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Builder
{
    public abstract class BaseEntityBuilder : IEntityBuilder
    {
        protected IDataTypeConvert DataTypeConvert = DBObjectFactoryFactory.Instance.GetDBObjectFactory().GetDataTypeConvert();
        //protected IBaseEntityInfo BaseEntityInfo = DBObjectFactoryFactory.Instance.GetDBObjectFactory().GetBaseEntityInfo();
        public void Builder(string nameSpace)
        {
            //string nameSpace = "My.EntityBuilder";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("/*");
            sb.AppendLine("该文件为自动生成，不要修改。");
            sb.AppendFormat("生成时间：{0}。", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            sb.AppendLine("*/");

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using Aix.ORM;");
            sb.AppendLine();
            sb.AppendFormat("namespace {0}", string.IsNullOrEmpty(nameSpace) ? "Entities" : nameSpace);
            sb.AppendLine();
            sb.AppendLine("{");


            Dictionary<string, TableInfo> dict = DBMetadataHelper.GetTableInfo();

            foreach (var item in dict)
            {
                Console.WriteLine();
                Console.Write("开始生成表：{0}......", item.Key);
                sb.AppendLine(BuildClass(item.Value));
                Console.Write("......成功");
            }
            Console.WriteLine();
            sb.AppendLine("}");

            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entities");
            string path = GeneratorOption.Instance.EntityDirectory;
            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }
            string fileName = "Entities.cs";

            if (File.Exists(Path.Combine(path, fileName)))
            {
                File.Delete(Path.Combine(path, fileName));
            }

            BuilderUtils.CreateFile(path, fileName, sb.ToString());
        }

        protected abstract string BuildClass(TableInfo table);

        protected string GetClassName(string tableName)
        {
            return UnderLineToCamel(tableName);
        }

        protected string GetPropertyName(string columnName)
        {
            //下划线转驼峰
            return UnderLineToCamel(columnName);
        }

        protected string UnderLineToCamel(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            if (str.Contains("_"))
            {
                var ss = str.Split('_').Where(_item => _item.Trim().Length > 0).Select(item => FirstLetterToUpper(item));
                return string.Join("", ss.ToArray());
            }

            if (str.Length == 1)
            {
                return char.ToUpper(str[0]).ToString();
            }
            else
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
        }

        protected string UnderLineToCamel2(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            if (!str.Contains("_"))
            {
                return FirstLetterToUpper(str);
            }

            var array = str.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append(FirstLetterToUpper(item));
            }
            return sb.ToString();
        }

        private string FirstLetterToUpper(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length == 1)
                {
                    return str[0].ToString().ToUpper();
                }
                else
                {
                    return $"{char.ToUpper(str[0])}{str.Substring(1)}";
                }

            }

            return str;
        }

        protected string RemoveNewLine(string content)
        {
            //return   content.Replace(Environment.NewLine, Environment.NewLine+"///");
            return content?.Replace(Environment.NewLine, "");
        }
    }
}
