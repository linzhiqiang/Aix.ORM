using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aix.EntityGenerator
{
    public class SaveToFileFactory
    {
        private readonly GeneratorOptions _options;
        private readonly IEnumerable<ISaveToFile> _saveToFiles;

        public SaveToFileFactory(GeneratorOptions options, IEnumerable<ISaveToFile> saveToFiles)
        {
            _options = options;
            _saveToFiles = saveToFiles;
        }
        public ISaveToFile GetSaveToFile()
        {
            if (_options.MultipleFiles)
            {
              return   _saveToFiles.FirstOrDefault(x => x.GetType() == typeof(SaveToMultipleFile));
            }
            return _saveToFiles.FirstOrDefault(x => x.GetType() == typeof(SaveToSingleFile));
        }
    }
}
