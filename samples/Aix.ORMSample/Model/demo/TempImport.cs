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
    [Table("temp_import")]
    public partial class TempImport : BaseEntity
    {
        private int _id; 
        private string _relic_id; 
        private string _relic_name; 
        private string _product_id; 

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
        [Column("relic_id")]
        public string RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("relic_name")]
        public string RelicName
        {
            get { return _relic_name; }
            set { _relic_name = value; OnPropertyChanged("relic_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public string ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

}