using Aix.ORM.DBConnectionManager;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Aix.ORMSample
{
    public class Startup
    {
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var dbOption = context.Configuration.GetSection("connectionStrings").Get<DBOption>();
            services.AddSingleton(dbOption);
            AddDB(services);
            services.AddSingleton<UserRepository>();
            services.AddHostedService<StartHostService>();
        }

        private static void AddDB(IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
           // ConnectionFactory.Instance.DefaultFactory = new MySqlConnectionFactory();
            ConnectionFactory.Instance.DefaultFactory = new MsSqlConnectionFactory();
        }
    }

    public class MySqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
