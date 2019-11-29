using Aix.EntityGenerator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aix.EntityGeneratorApp
{
    public class Startup
    {
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var option = context.Configuration.GetSection("generator").Get<GeneratorOptions>();
            GeneratorOptions.Instance = option;

            //ConnectionFactory.Instance.DefaultFactory = new MsSqlConnectionFactory();
            //services.AddSingleton<IConfigService, ConfigService>();
            services.AddHostedService<StartHostService>();
        }
    }

    
}
