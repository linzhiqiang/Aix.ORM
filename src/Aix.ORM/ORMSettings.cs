using Aix.ORM.DBConnectionManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM
{
  public static  class ORMSettings
    {
        /// <summary>
        /// 设置数据路连接工厂实现
        /// </summary>
        /// <param name="abstractConnectionFactory"></param>
        public static void SetConnectionFactory(AbstractConnectionFactory abstractConnectionFactory)
        {
            ConnectionFactoryFactory.Instance.SetConnectionFactory(abstractConnectionFactory);
        }
    }
}
