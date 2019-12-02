using Aix.EntityGenerator.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
    public interface IBuilderFactory
    {
        IEntityBuilder GetEntityBuilder(string type);
    }
}
