using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public class DBMetadataFactoryFactory
    {
        public static DBMetadataFactoryFactory Instance = new DBMetadataFactoryFactory();
        private DBMetadataFactoryFactory() { }


        private Dictionary<ORMDBType, IDBMetadataFactory> Cache = new Dictionary<ORMDBType, IDBMetadataFactory>();
        private object SynLock = new object();
        public IDBMetadataFactory GetDBObjectFactory(ORMDBType dbType)
        {
            if (!Cache.ContainsKey(dbType))
            {
                lock (SynLock)
                {
                    if (!Cache.ContainsKey(dbType))
                    {

                        if (dbType == ORMDBType.MySql)
                        {
                            Cache.Add(dbType, new MysqlMetadataFactory());
                        }
                        else if (dbType == ORMDBType.MsSql)
                        {
                            Cache.Add(dbType, new SqlServerMetadataFactory());
                        }
                        else
                        {
                            throw new Exception("GetDBObjectFactory失败，没有配置对应的数据库类型");
                        }
                    }
                }
            }

            return Cache[dbType];



        }
    }
}
