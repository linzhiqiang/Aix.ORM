using Aix.EntityGeneratorNew.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorNew
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
