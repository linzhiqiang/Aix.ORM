using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Builder
{
    public interface IEntityBuilder
    {
        void Builder(ORMDBType dbType,string connectionStrings);
       
    }
}
