using Aix.EntityGenerator.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public class DBMetadataDTO
    {
        public string DBName { get; set; }

        public List<TableInfo> TableInfos { get; set; }
    }

    public class BuilderResult
    {
        public string DBName { get; set; }

        public string Header { get; set; }

        public List<ClassBuilderInfo> ClassInfos { get; set; }
    }

    public class ClassBuilderInfo
    {
        public TableInfo TableInfo { get; set; }
        public string ClassString { get; set; }
    }
}
