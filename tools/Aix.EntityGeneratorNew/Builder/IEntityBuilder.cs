using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorNew.Builder
{
    public interface IEntityBuilder
    {
        BuilderResult Builder(ORMDBType dbType,string connectionStrings);
       
    }
}
