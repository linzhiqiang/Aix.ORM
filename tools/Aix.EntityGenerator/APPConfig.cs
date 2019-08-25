using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator
{

    public class GeneratorOption
    {
        public static GeneratorOption Instance;
        public string NameSapce { get; set; }
        public ORMDBType DBtype { get; set; }

        public string EntityDirectory { get; set; }
        public string Maindb { get; set; }
    }

   
}
