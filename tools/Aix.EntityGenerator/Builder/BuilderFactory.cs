using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aix.EntityGenerator.Builder
{
    public class BuilderFactory: IBuilderFactory
    {
        private readonly  IServiceProvider _serviceProvider;
        private readonly GeneratorOptions _options;
        private readonly SaveToFileFactory _saveToFileFactory;
        private readonly IEnumerable<IEntityBuilder> _builders;
        public BuilderFactory(
            IServiceProvider serviceProvider
            , GeneratorOptions options
            , IEnumerable<IEntityBuilder> builders
            , SaveToFileFactory saveToFileFactory)
        {
            _serviceProvider = serviceProvider;
            _options = options;
            _builders = builders;
            _saveToFileFactory = saveToFileFactory;
        }
        public IEntityBuilder GetEntityBuilder(string type)
        {
            IEntityBuilder builder = null;
            if (type == "1")
            {
                builder = _builders.FirstOrDefault(x=>x.GetType()==typeof(DefaultBuilder));
            }
            else if (type == "2")
            {
                builder = _builders.FirstOrDefault(x => x.GetType() == typeof(ORMBuilder));
            }

            return builder;
        }

    }
}
