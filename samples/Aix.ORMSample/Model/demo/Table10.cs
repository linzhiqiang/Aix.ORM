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
    /// 数据表10
    /// <summary>
    [Table("Table10")]
    public partial class Table10 : BaseEntity
    {
        private int _id; 
        private string _name; 

        /// <summary>
        /// 主键  int(11)
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
        /// 名称  varchar(50)
        /// <summary>
        [Column("name",IsNullable=false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("name"); }
        }
    }

}