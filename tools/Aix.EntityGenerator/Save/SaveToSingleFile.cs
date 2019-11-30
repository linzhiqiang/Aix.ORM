using System;
using System.Collections.Generic;
using System.Text;
using Aix.EntityGenerator.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aix.EntityGenerator
{
  public  class SaveToSingleFile:ISaveToFile
    {
        protected GeneratorOptions _options;
        public SaveToSingleFile(GeneratorOptions options)
        {
            _options = options;
        }
        public void Save(BuilderResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(result.Header);
            sb.AppendLine();
            sb.Append("{");
            sb.AppendLine();
            foreach (var item in result.ClassInfos)
            {
                sb.Append(item.ClassString);
                sb.AppendLine();
            }
            sb.Append("}");

            var fileName = $"{result.DBName}.cs";
            Helper.SaveToFile(_options, result.DBName, fileName, sb.ToString());
        }
    }
}
