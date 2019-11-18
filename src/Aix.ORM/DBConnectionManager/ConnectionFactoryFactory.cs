﻿using Aix.ORM.Common;
using Aix.ORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Aix.ORM.DBConnectionManager
{
    /// <summary>
    /// ConnectionFactory 工厂
    /// </summary>
    public class ConnectionFactoryFactory
    {
        public static ConnectionFactoryFactory Instance = new ConnectionFactoryFactory();


        public AbstractConnectionFactory Factory = new DefaultConnectionFactory();

        private ConnectionFactoryFactory()
        {
            //User_Id->UserId
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public AbstractConnectionFactory GetConnectionFactory()
        {
            return Factory;
        }

    }

    
}
