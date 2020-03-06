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
    /// 
    /// <summary>
    [Table("temp_import_data")]
    public partial class TempImportData : BaseEntity
    {
        private int _relic_id; 
        private int _product_id; 

        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("relic_id",IsNullable=false)]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("product_id",IsNullable=false)]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

}