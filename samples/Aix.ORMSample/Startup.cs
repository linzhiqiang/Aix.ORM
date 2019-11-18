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
            Dapper.SqlMapper.Settings.CommandTimeout = 10;//秒
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
            //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            //  ConnectionFactoryFactory.Instance.Factory = new DBConnectionFactory();
            // ConnectionFactory.Instance.DefaultFactory = new MsSqlConnectionFactory();
        }
    }

    public class DBConnectionFactory : AbstractConnectionFactory
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

}
