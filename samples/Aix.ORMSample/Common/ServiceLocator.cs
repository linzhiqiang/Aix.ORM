using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORMSample.Common
{
    public static class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
