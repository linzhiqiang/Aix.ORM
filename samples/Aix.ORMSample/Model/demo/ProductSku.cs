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
    [Table("product_sku")]
    public partial class ProductSku : BaseEntity
    {
        private int _sku_id; 
        private string _sku_code; 
        private string _sku_name; 
        private int _product_id; 

        /// <summary>
        /// 
        /// <summary>
        [Column("sku_id")]
        [PrimaryKey]
        [Identity]
        public int SkuId
        {
            get { return _sku_id; }
            set { _sku_id = value; OnPropertyChanged("sku_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("sku_code")]
        public string SkuCode
        {
            get { return _sku_code; }
            set { _sku_code = value; OnPropertyChanged("sku_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("sku_name")]
        public string SkuName
        {
            get { return _sku_name; }
            set { _sku_name = value; OnPropertyChanged("sku_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

}