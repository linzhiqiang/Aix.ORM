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
    [Table("temp_import")]
    public partial class TempImport : BaseEntity
    {
        private int _id; 
        private string _relic_id; 
        private string _relic_name; 
        private string _product_id; 

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
        ///   varchar(255)
        /// <summary>
        [Column("relic_id",IsNullable=true)]
        public string RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        ///   varchar(255)
        /// <summary>
        [Column("relic_name",IsNullable=true)]
        public string RelicName
        {
            get { return _relic_name; }
            set { _relic_name = value; OnPropertyChanged("relic_name"); }
        }
        /// <summary>
        ///   mediumtext
        /// <summary>
        [Column("product_id",IsNullable=true)]
        public string ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

}