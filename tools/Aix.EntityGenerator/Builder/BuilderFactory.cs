using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aix.EntityGenerator.Builder
{
    public class BuilderFactory: IBuilderFactory
    {
        private readonly  IServiceProvider _serviceProvider;
        private readonly IEnumerable<IEntityBuilder> _builders;
        public BuilderFactory(
            IServiceProvider serviceProvider
            , IEnumerable<IEntityBuilder> builders
            )
        {
            _serviceProvider = serviceProvider;
            _builders = builders;
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
