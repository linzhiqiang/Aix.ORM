using Aix.EntityGeneratorNew.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorNew
{
    public class MysqlObjectFactory : IDBObjectFactory
    {
        public IDBMetadata GetDBMetadata(string connectionStrings)
        {
            return new MySqlMetadata(connectionStrings);
        }

        public IDataTypeConvert GetDataTypeConvert()
        {
            return new MySqlDataTypeConvert();
        }

    }
}
