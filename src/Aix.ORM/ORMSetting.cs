using Aix.ORM.DBConnectionManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM
{
  public static  class ORMSetting
    {
        public static void SetConnectionFactory(AbstractConnectionFactory abstractConnectionFactory)
        {
            ConnectionFactoryFactory.Instance.SetConnectionFactory(abstractConnectionFactory);
        }
    }
}
