using Aix.ORM.Common;
using System;
using System.Data;

namespace Aix.ORM.DBConnectionManager
{
    public class ConnectionFactory
    {
        public IConnectionFactory DefaultFactory = null;// new MsSqlConnectionFactory();

        public static ConnectionFactory Instance = new ConnectionFactory();

        private ConnectionFactory() { }

        public IConnectionFactory GetConnectionFactory()
        {
            return DefaultFactory;
        }

    }

    public interface IConnectionFactory
    {
        IDbConnection CreateConnection(string connectionString);
    }

    public abstract class BaseConnectionFactory
    {
        IDbConnection CreateConnection(string connectionString , ORMDBType dbType )
        {
            IDbConnection connection = null;
            switch (dbType)
            {
                case ORMDBType.MsSql:
                    connection = CreateMsSqlSqlConnection(connectionString);
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

        public virtual IDbConnection CreateMsSqlSqlConnection(string connectionString)
        {
            throw new NotImplementedException();
        }

        public virtual IDbConnection CreateMySqlConnection(string connectionString)
        {
            throw new NotImplementedException();
        }

        public virtual IDbConnection CreateOracleSqlSqlConnection(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
