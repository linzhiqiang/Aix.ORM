using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Factory
{
    public class DBObjectFactoryFactory
    {
        public static DBObjectFactoryFactory Instance = new DBObjectFactoryFactory();
        private DBObjectFactoryFactory() { }


        private Dictionary<ORMDBType, IDBObjectFactory> Cache = new Dictionary<ORMDBType, IDBObjectFactory>();
        private object SynLock = new object();
        public IDBObjectFactory GetDBObjectFactory()
        {
            ORMDBType dbType = GeneratorOptions.Instance.DBtype;
            if (!Cache.ContainsKey(dbType))
            {
                lock (SynLock)
                {
                    if (!Cache.ContainsKey(dbType))
                    {
                        
                        if (dbType == ORMDBType.MySql)
                        {
                            Cache.Add(dbType, new MysqlObjectFactory());
                        }
                        else if (dbType == ORMDBType.MsSql)
                        {
                            Cache.Add(dbType, new SqlServerObjectFactory());
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
