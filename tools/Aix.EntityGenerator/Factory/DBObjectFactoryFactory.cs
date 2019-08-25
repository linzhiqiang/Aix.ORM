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


        private IDBObjectFactory DBFactory { get; set; }
        private object SynLock = new object();
        public IDBObjectFactory GetDBObjectFactory()
        {
            if (DBFactory == null)
            {
                lock (SynLock)
                {
                    if (DBFactory == null)
                    {
                        ORMDBType dbType = GeneratorOption.Instance.DBtype;

                        if (dbType == ORMDBType.MySql)
                        {
                            DBFactory= new MysqlObjectFactory();
                        }
                        else if (dbType == ORMDBType.MsSql)
                        {
                            DBFactory= new SqlServerObjectFactory();
                        }
                        else
                        {
                            throw new Exception("GetDBObjectFactory失败，没有配置对应的数据库类型");
                        }
                    }
                }
            }

            return DBFactory;


            
        }
    }
}
