/*
该文件为自动生成，不要修改。
生成时间：2020-06-05 10:06:13。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aix.ORM;

namespace Aix.ORMSample.Entity
{
    /// <summary>
    /// 
    /// <summary>
    [Table("test_sta")]
    public partial class TestSta : BaseEntity
    {
        private int _id; 
        private int _view_count; 

        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("id",IsNullable=false)]
        [PrimaryKey]
        [Identity]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("view_count",IsNullable=false)]
        public int ViewCount
        {
            get { return _view_count; }
            set { _view_count = value; OnPropertyChanged("view_count"); }
        }
    }

}