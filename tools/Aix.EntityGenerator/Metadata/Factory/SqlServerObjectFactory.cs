using Aix.EntityGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public class SqlServerObjectFactory : IDBObjectFactory
    {
        public IDBMetadata GetDBMetadata(string connectionStrings)
        {
            return new SqlServerMetadata(connectionStrings);
        }

        public IDataTypeConvert GetDataTypeConvert()
        {
            return new SqlServerDataTypeConvert();
        }
    }
}
