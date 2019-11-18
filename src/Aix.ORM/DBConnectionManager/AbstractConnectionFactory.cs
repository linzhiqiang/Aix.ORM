using Aix.ORM.Common;
using Aix.ORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Aix.ORM.DBConnectionManager
{
    public abstract class AbstractConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString, ORMDBType dbType)
        {
            IDbConnection connection = null;
            switch (dbType)
            {
                case ORMDBType.MsSql:
                    connection = CreateMsSqlConnection(connectionString);
                    break;
                case ORMDBType.MySql:
                    connection = CreateMySqlConnection(connectionString);
                    break;
                case ORMDBType.Oracle:
                    connection = CreateOracleSqlSqlConnection(connectionString);
                    break;
                default:
                    break;
            }

            return connection;
        }

        public virtual IDbConnection CreateMsSqlConnection(string connectionString)
        {
            throw new NotImplementedException($"请实现:{this.GetType().FullName}.CreateMsSqlConnection");
        }

        public virtual IDbConnection CreateMySqlConnection(string connectionString)
        {
            throw new NotImplementedException($"请实现:{this.GetType().FullName}.CreateMySqlConnection");
        }

        public virtual IDbConnection CreateOracleSqlSqlConnection(string connectionString)
        {
            throw new NotImplementedException($"请实现:{this.GetType().FullName}.CreateOracleSqlSqlConnection");
        }
    }

    public class DefaultConnectionFactory : AbstractConnectionFactory
    {
        public static object SyncObj = new object();

        private Func<string, IDbConnection> MsSqlFunc = null;
        private Func<string, IDbConnection> MySqlFunc = null;

        public override IDbConnection CreateMsSqlConnection(string connectionString)
        {
            if (MsSqlFunc == null)
            {
                lock (SyncObj)
                {
                    if (MsSqlFunc == null)
                    {
                        var type = Type.GetType("System.Data.SqlClient.SqlConnection,System.Data.SqlClient");
                        AssertUtils.IsNotNull(type, "请添加System.Data.SqlClient组件");
                        MsSqlFunc = MethodUtils.CreateInstanceDelegate<Func<string, IDbConnection>>(type, new Type[] { typeof(string) });
                    }
                }
            }

            return MsSqlFunc(connectionString);
        }

        public override IDbConnection CreateMySqlConnection(string connectionString)
        {
            if (MySqlFunc == null)
            {
                lock (SyncObj)
                {
                    if (MySqlFunc == null)
                    {
                        var type = Type.GetType("MySql.Data.MySqlClient.MySqlConnection,MySql.Data");
                        AssertUtils.IsNotNull(type, "请添加MySql.Data组件");
                        var MySqlConstructor = type.GetConstructor(new Type[] { typeof(string) });
                        // Activator.CreateInstance
                        // return MySqlCons tructor.Invoke(new object[] { connectionString }) as IDbConnection;
                        MySqlFunc = MethodUtils.CreateInstanceDelegate<Func<string, IDbConnection>>(type, new Type[] { typeof(string) });
                    }
                }
            }

            return MySqlFunc(connectionString);
        }

    }

    /*
    public class DBConnectionFactory : DefaultConnectionFactory
    {
        public override IDbConnection CreateSqlServerConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public override IDbConnection CreateMySqlConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
    */
}
