using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator
{
  public  interface ISaveToFileFactory
    {
        ISaveToFile GetSaveToFile(bool multipleFiles);
    }
}
