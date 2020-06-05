using Aix.EntityGenerator;
using Aix.EntityGeneratorApp.Hosts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGeneratorApp
{
    public class Startup
    {
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var option = context.Configuration.GetSection("generator").Get<GeneratorOptions>();
            services.AddEntityGenerator(option);
            services.AddHostedService<StartHostService>();
        }

       
    }
}
