using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorNew
{
    public class GeneratorOptions
    {
       // public static GeneratorOptions Instance;
        public string NameSapce { get; set; }

        public string EntityDirectory { get; set; }

        /// <summary>
        /// 多个文件 false=一个文件 true=多个文件 默认一个文件
        /// </summary>
        public bool MultipleFiles { get; set; }

        public DatabaseInfo[] Databases { get; set; }
    }

    public class DatabaseInfo
    {
        public ORMDBType DBtype { get; set; }

        public string ConnectionStrings { get; set; }
    }
}
