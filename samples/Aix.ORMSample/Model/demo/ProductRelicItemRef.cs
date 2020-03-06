/*
该文件为自动生成，不要修改。
生成时间：2020-03-06 12:26:54。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aix.ORM;

namespace Aix.ORMSample.Entity
{
    /// <summary>
    /// 商品和藏品关联信息表 商品和藏品关联信息表
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
        /// 编号  int(11)
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
        /// 商品ID  int(11)
        /// <summary>
        [Column("product_id",IsNullable=false)]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
        /// <summary>
        /// 藏品ID  int(11)
        /// <summary>
        [Column("relic_id",IsNullable=false)]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 修改人编号  varchar(50)
        /// <summary>
        [Column("modifier_id",IsNullable=false)]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 修改日期  datetime
        /// <summary>
        [Column("modify_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime ModifyTime
        {
            get { return _modify_time; }
            set { _modify_time = value; OnPropertyChanged("modify_time"); }
        }
    }

}