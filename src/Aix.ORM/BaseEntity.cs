using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 发生变化的属性 (进行了赋值的)
        /// </summary>
        private List<string> _PropertyChangedList = new List<string>();

        /// <summary>
        /// 修改时 是否修改案全部字段  false=只修改赋值的字段 false=修改所有字段  默认false
        /// </summary>
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
