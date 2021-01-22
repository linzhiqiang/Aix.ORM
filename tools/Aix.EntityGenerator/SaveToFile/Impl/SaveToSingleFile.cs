using System;
using System.Collections.Generic;
using System.Text;
using Aix.EntityGenerator.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aix.EntityGenerator
{
  public  class SaveToSingleFile:ISaveToFile
    {
        ILogger<SaveToSingleFile> _logger;
        protected GeneratorOptions _options;
        public SaveToSingleFile(ILogger<SaveToSingleFile> logger, GeneratorOptions options)
        {
            _logger = logger;
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

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //_logger.LogInformation($"output directory is  {Helper.GetBasePath(_options)}");
            Console.WriteLine($"output directory is  {Helper.GetBasePath(_options)}");
            Console.ResetColor();
        }
    }
}
