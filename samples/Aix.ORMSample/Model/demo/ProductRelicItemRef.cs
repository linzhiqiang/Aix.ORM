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
    [Table("product_relic_item_ref")]
    public partial class ProductRelicItemRef : BaseEntity
    {
        private int _id; 
        private int _product_id; 
        private int _relic_id; 
        private string _modifier_id; 
        private DateTime _modify_time; 

        /// <summary>
        /// 编号
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
        /// 商品ID
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
        /// <summary>
        /// 藏品ID
        /// <summary>
        [Column("relic_id")]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 修改人编号
        /// <summary>
        [Column("modifier_id")]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 修改日期
        /// <summary>
        [Column("modify_time")]
        public DateTime ModifyTime
        {
            get { return _modify_time; }
            set { _modify_time = value; OnPropertyChanged("modify_time"); }
        }
    }

}