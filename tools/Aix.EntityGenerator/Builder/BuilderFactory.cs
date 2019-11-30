using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Builder
{
    public class BuilderFactory: IBuilderFactory
    {
        private readonly  IServiceProvider _serviceProvider;
        private readonly GeneratorOptions _options;
        private readonly SaveToFileFactory _saveToFileFactory;
        //private readonly IEnumerable<IEntityBuilder> _builders;
        public BuilderFactory(
            IServiceProvider serviceProvider
            , GeneratorOptions options
            , SaveToFileFactory saveToFileFactory)
        {
            _serviceProvider = serviceProvider;
            _options = options;
            _saveToFileFactory = saveToFileFactory;
        }
        public IEntityBuilder GetEntityBuilder(string type)
        {
            IEntityBuilder builder = null;
            var saveToFile = _saveToFileFactory.GetSaveToFile();
            if (type == "1")
            {
                builder = new DefaultBuilder(_serviceProvider,saveToFile);
            }
            else if (type == "2")
            {
                builder = new ORMBuilder(_serviceProvider,saveToFile);
            }

            return builder;
        }

    }
}
