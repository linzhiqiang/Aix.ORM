/*
该文件为自动生成，不要修改。
生成时间：2019-11-29 18:56:59。
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
        /// 
        /// <summary>
        [Column("id")]
        [PrimaryKey]
        [Identity]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("view_count")]
        public int ViewCount
        {
            get { return _view_count; }
            set { _view_count = value; OnPropertyChanged("view_count"); }
        }
    }

}