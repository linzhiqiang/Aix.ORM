﻿using Aix.EntityGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public class MysqlMetadataFactory : IDBMetadataFactory
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
