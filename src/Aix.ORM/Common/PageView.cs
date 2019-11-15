using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Aix.ORM.Common
{
    public class PageView
    {
        public PageView()
        {
        }

        public PageView(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 从1开始
        /// </summary>
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        //public string SortName { get; set; }

        //public string SortOrder { get; set; }

        /// <summary>
        /// 是不是每一页查询都返回总数，默认只有第一页返回总数
        /// </summary>
        public bool IsFirstQueryTotal { get; set; } = true;

        /*
        public string GetSqlOrder()
        {
            if (!string.IsNullOrEmpty(SortName) && !string.IsNullOrEmpty(SortOrder))
                return string.Format("ORDER BY {0} {1} ", SortName, SortOrder);
            return string.Empty;
        }
        */
    }
}
