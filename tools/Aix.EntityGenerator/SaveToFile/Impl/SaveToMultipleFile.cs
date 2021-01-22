using Aix.EntityGenerator.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aix.EntityGenerator
{
    public class  SaveToMultipleFile:ISaveToFile
    {
        ILogger<SaveToMultipleFile> _logger;
        protected GeneratorOptions _options;
        public SaveToMultipleFile(ILogger<SaveToMultipleFile>  logger,GeneratorOptions options)
        {
            _logger = logger;
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

            //_logger.LogInformation($"output directory is  {Helper.GetBasePath(_options)}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"output directory is  {Helper.GetBasePath(_options)}");
            Console.ResetColor();
        }
    }
}
