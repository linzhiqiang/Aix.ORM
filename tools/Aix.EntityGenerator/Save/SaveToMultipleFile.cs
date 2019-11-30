using Aix.EntityGenerator.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Aix.EntityGenerator
{
    public class  SaveToMultipleFile:ISaveToFile
    {
        protected GeneratorOptions _options;
        public SaveToMultipleFile(GeneratorOptions options)
        {
            _options = options;
        }
        public void Save(BuilderResult result)
        {
            foreach (var item in result.ClassInfos)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(result.Header);
                sb.AppendLine();
                sb.Append("{");
                sb.AppendLine();

                sb.Append(item.ClassString);
                sb.AppendLine();
                sb.Append("}");

                var fileName = $"{Helper.GetClassName(item.TableInfo.TableName)}.cs";
                Helper.SaveToFile(_options, result.DBName, fileName, sb.ToString());
            }
        }
    }
}
