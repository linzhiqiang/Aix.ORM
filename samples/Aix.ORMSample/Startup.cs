using Aix.ORM.DBConnectionManager;
using Aix.ORMSample.Repository;
using Aix.ORMSample.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aix.ORMSample
{
    public class Startup
    {
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            #region 注入
            var dbOption = context.Configuration.GetSection("connectionStrings").Get<DBOption>();
            services.AddSingleton(dbOption);
            AddDB(services);

            //repository
            services.AddSingleton<UserRepository>();
            services.AddSingleton<RelicRepository>();
            services.AddSingleton<UserOpusRepository>();

            //service
            services.AddSingleton<UserOpusService>();
            services.AddSingleton<RelicService>();
            services.AddSingleton<UserService>();
            services.AddHostedService<StartHostService>();

            #endregion
        }

        private static void AddDB(IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            ConnectionFactory.Instance.DefaultFactory = new MySqlConnectionFactory();
            // ConnectionFactory.Instance.DefaultFactory = new MsSqlConnectionFactory();
        }
    }

    public class MsSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
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
