using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aix.EntityGenerator
{
    public class SaveToFileFactory 
    {
        private readonly IEnumerable<ISaveToFile> _saveToFiles;

        public SaveToFileFactory(IEnumerable<ISaveToFile> saveToFiles)
        {
            _saveToFiles = saveToFiles;
        }
        public ISaveToFile GetSaveToFile(bool multipleFiles)
        {
            if (multipleFiles)
            {
                return _saveToFiles.FirstOrDefault(x => x.GetType() == typeof(SaveToMultipleFile));
            }
            return _saveToFiles.FirstOrDefault(x => x.GetType() == typeof(SaveToSingleFile));
        }
    }
}
