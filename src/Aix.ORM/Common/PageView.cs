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

        public PageView(int pageIndex,int pageSize,string sortName,string sortOrder)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            SortName = sortName;
            SortOrder = sortOrder;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string SortName { get; set; }

        public string SortOrder { get; set; }

        public string GetSqlOrder()
        {
            if (!string.IsNullOrEmpty(SortName) && !string.IsNullOrEmpty(SortOrder))
                return string.Format("ORDER BY {0} {1} ", SortName, SortOrder);
            return string.Empty;
        }
    }
}
