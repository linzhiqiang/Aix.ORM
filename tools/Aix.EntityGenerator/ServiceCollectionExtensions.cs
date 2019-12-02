using Aix.EntityGenerator.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
  public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityGenerator(this IServiceCollection services, GeneratorOptions options)
        {
            
            services.AddSingleton(options);

            services.AddSingleton<ISaveToFile, SaveToSingleFile>();
            services.AddSingleton<ISaveToFile, SaveToMultipleFile>();
            services.AddSingleton<ISaveToFileFactory,SaveToFileFactory>();

            services.AddSingleton<IEntityBuilder, DefaultBuilder>();
            services.AddSingleton<IEntityBuilder, ORMBuilder>();
            services.AddSingleton<IBuilderFactory, BuilderFactory>();

            services.AddSingleton<DBMetadataWrapper>();
            services.AddSingleton(DBObjectFactoryFactory.Instance);
            return services;
        }
    }
}
