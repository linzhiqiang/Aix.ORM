/*
该文件为自动生成，不要修改。
生成时间：2021-01-19 09:30:03。
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
        ///   int(11)
        /// <summary>
        [Column("product_id",IsNullable=false)]
        [PrimaryKey]
        [Identity]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
        /// <summary>
        ///   varchar(255)
        /// <summary>
        [Column("product_code",IsNullable=false)]
        public string ProductCode
        {
            get { return _product_code; }
            set { _product_code = value; OnPropertyChanged("product_code"); }
        }
        /// <summary>
        ///   varchar(255)
        /// <summary>
        [Column("product_name",IsNullable=false)]
        public string ProductName
        {
            get { return _product_name; }
            set { _product_name = value; OnPropertyChanged("product_name"); }
        }
    }

}