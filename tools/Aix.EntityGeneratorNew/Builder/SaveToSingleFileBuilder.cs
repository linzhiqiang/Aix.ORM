using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aix.EntityGeneratorNew.Utils;
using Aix.ORM.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Aix.EntityGeneratorNew.Builder
{
    
    public class SaveToSingleFileBuilder : IEntityBuilder
    {
        IEntityBuilder _builder;
        protected GeneratorOptions _generatorOptions;
        public SaveToSingleFileBuilder(IEntityBuilder builder)
        {
            _builder = builder;
            _generatorOptions = ServiceLocator.Instance.GetService<GeneratorOptions>();
        }
        public  BuilderResult Builder(ORMDBType dbType, string connectionStrings)
        {
            var result = _builder.Builder(dbType, connectionStrings);

            //savetofile
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
            SaveToFile(sb.ToString(), result.DBName, $"{result.DBName}.cs");

            return result;
        }

        protected void SaveToFile(string content, string rootDir, string fileName)
        {
            string path = _generatorOptions.EntityDirectory;
            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            path = Path.Combine(path, rootDir);


            BuilderUtils.CreateFile(path, fileName, content);
        }


    }
}
