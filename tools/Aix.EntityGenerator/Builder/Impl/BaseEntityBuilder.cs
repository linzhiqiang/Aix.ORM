﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aix.EntityGenerator.Entity;
using Aix.ORM.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aix.EntityGenerator.Builder
{
    public abstract class BaseEntityBuilder : IEntityBuilder
    {
        protected readonly IServiceProvider _serviceProvider;
        protected GeneratorOptions _options;
        protected ILogger<BaseEntityBuilder> _logger;
        private SaveToFileFactory _saveToFileFactory;
        private DBMetadataWrapper _dBMetadataWrapper;
        public BaseEntityBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _options = serviceProvider.GetService<GeneratorOptions>();
            _logger = serviceProvider.GetService<ILogger<BaseEntityBuilder>>();
            _saveToFileFactory = serviceProvider.GetService<SaveToFileFactory>();
            _dBMetadataWrapper = serviceProvider.GetService<DBMetadataWrapper>();
        }

        public void Builder(ORMDBType dbType, string connectionStrings)
        {
            var metadatas = _dBMetadataWrapper.GetTableInfo(dbType, connectionStrings);

            List<ClassBuilderInfo> classInfos = new List<ClassBuilderInfo>();
            foreach (var item in metadatas.TableInfos)
            {
                _logger.LogInformation("开始生成表：{0}......", item.TableName);
                var classString = BuildClass(dbType, item);
                classInfos.Add(new ClassBuilderInfo { ClassString = classString, TableInfo = item });
                _logger.LogInformation("......成功");
            }
            var result = new BuilderResult
            {
                Header = BuilderHead(),
                DBName = metadatas.DBName,
                ClassInfos = classInfos
            };

            var saveToFile = _saveToFileFactory.GetSaveToFile(_options.MultipleFiles);
            saveToFile.Save(result);
        }

        public abstract string BuildClass(ORMDBType dbType, TableInfo table);

        #region private 
        private string BuilderHead()
        {
            StringBuilder sb = new StringBuilder();

            var nameSpace = _options.NameSapce;

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

            return sb.ToString();
        }

        #endregion


    }
}