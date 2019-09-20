using Aix.ORM.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORMSample.Repository
{
    public class BaseRepository : MySqlRepository// MySqlRepository// MsSqlRepository
    {
        public BaseRepository(string connectionStrings) : base(connectionStrings)
        {
        }
    }
}
