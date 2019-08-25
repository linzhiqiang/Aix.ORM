using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator
{
    public interface IDBObjectFactory
    {
        IDBMetadata GetDBMetadata();
        IDataTypeConvert GetDataTypeConvert();

    }
}
