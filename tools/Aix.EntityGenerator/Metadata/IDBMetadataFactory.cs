using Aix.EntityGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public interface IDBMetadataFactory
    {
        IDBMetadata GetDBMetadata(string connectionStrings);
        IDataTypeConvert GetDataTypeConvert();
    }
}
