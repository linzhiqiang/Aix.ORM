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

    //public class MsSqlConnectionFactory : IConnectionFactory
    //{
    //    public IDbConnection CreateConnection(string connectionString)
    //    {
    //        return new SqlConnection(connectionString);
    //    }
    //}


}
