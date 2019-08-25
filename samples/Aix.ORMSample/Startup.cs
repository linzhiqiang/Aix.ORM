using Aix.ORMSample.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORMSample
{
    public class Startup
    {
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var dbOption = context.Configuration.GetSection("connectionStrings").Get<DBOption>();
            services.AddSingleton(dbOption);
            services.AddSingleton< UserRepository>();
            services.AddHostedService<StartHostService>();
        }
    }
}
