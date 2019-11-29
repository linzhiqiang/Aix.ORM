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
    [Table("product")]
    public partial class Product : BaseEntity
    {
        private int _product_id; 
        private string _product_code; 
        private string _product_name; 

        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        [PrimaryKey]
        [Identity]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_code")]
        public string ProductCode
        {
            get { return _product_code; }
            set { _product_code = value; OnPropertyChanged("product_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_name")]
        public string ProductName
        {
            get { return _product_name; }
            set { _product_name = value; OnPropertyChanged("product_name"); }
        }
    }

}