using Aix.EntityGenerator.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Factory
{
   public class SqlServerObjectFactory: IDBObjectFactory
    {
        public IDBMetadata GetDBMetadata( )
        {
            return new SqlServerMetadata();
        }

        public IDataTypeConvert GetDataTypeConvert()
        {
            return new SqlServerDataTypeConvert();
        }
      
    }
}
