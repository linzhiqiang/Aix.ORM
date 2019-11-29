using Aix.EntityGeneratorNew.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorNew
{
    public interface IDBObjectFactory
    {
        IDBMetadata GetDBMetadata(string connectionStrings);
        IDataTypeConvert GetDataTypeConvert();
    }
}
