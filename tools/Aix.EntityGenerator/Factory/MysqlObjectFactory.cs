using Aix.EntityGenerator.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Factory
{
   public class MysqlObjectFactory: IDBObjectFactory
    {
        public IDBMetadata GetDBMetadata()
        {
            return new MySqlMetadata();
        }

        public IDataTypeConvert GetDataTypeConvert()
        {
            return new MySqlDataTypeConvert();
        }

       
    }
}
