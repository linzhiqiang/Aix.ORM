using Aix.EntityGenerator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Builder
{
    public static class Helper
    {
        public static string GetClassName(string tableName)
        {
            return UnderLineToCamel(tableName);
        }

        public static string GetPropertyName(string columnName)
        {
            //下划线转驼峰
            return UnderLineToCamel(columnName);
        }

        public static string UnderLineToCamel(string str)
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

        public static string UnderLineToCamel2(string str)
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

        public static string FirstLetterToUpper(string str)
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

        public static string RemoveNewLine(string content)
        {
            //return   content.Replace(Environment.NewLine, Environment.NewLine+"///");
            return content?.Replace(Environment.NewLine, "");
        }

        public static void SaveToFile(GeneratorOptions generatorOptions, string parentDir, string fileName, string content)
        {
            string path = GetBasePath(generatorOptions);
            path = Path.Combine(path, parentDir);
            BuilderUtils.CreateFile(path, fileName, content);
        }

        public static string GetBasePath(GeneratorOptions generatorOptions)
        {
            string path = generatorOptions.EntityDirectory;
            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            return path;
        }
    }
}
