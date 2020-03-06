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
    [Table("relic_item_pics")]
    public partial class RelicItemPics : BaseEntity
    {
        private string _id; 
        private string _pic_urls; 
        private int _relic_id; 
        private int _sequence; 
        private DateTime _create_time; 

        /// <summary>
        /// 主键编号 主键编号  varchar(50)
        /// <summary>
        [Column("id",IsNullable=false)]
        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 图片JSON信息  varchar(2000)
        /// <summary>
        [Column("pic_urls",IsNullable=false)]
        public string PicUrls
        {
            get { return _pic_urls; }
            set { _pic_urls = value; OnPropertyChanged("pic_urls"); }
        }
        /// <summary>
        /// 藏品编号 藏品编号  int(11)
        /// <summary>
        [Column("relic_id",IsNullable=false)]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 排序号 排序号  int(11)
        /// <summary>
        [Column("sequence",IsNullable=false,DefaultValue="0")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 创建时间 创建时间  datetime
        /// <summary>
        [Column("create_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
    }

}