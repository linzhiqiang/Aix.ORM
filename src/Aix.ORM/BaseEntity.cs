using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM
{
    public abstract class BaseEntity
    {
        private List<string> _PropertyChangedList = new List<string>();
        private bool _fullUpdate = false;//默认不更新全部

        public bool FullUpdate
        {
            get { return _fullUpdate; }
            set { _fullUpdate = value; }
        }

        public List<string> GetPropertyChangedList()
        {
            return _PropertyChangedList;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (!_PropertyChangedList.Contains(propName))
            {
                lock (_PropertyChangedList)
                {
                    if (!_PropertyChangedList.Contains(propName))
                    {
                        _PropertyChangedList.Add(propName);
                    }
                }

            }
        }


        protected void Clear()
        {
            lock (_PropertyChangedList)
            {
                _PropertyChangedList.Clear();
            }
        }
    }
}
