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
    [Table("relic_item_media")]
    public partial class RelicItemMedia : BaseEntity
    {
        private string _id; 
        private int _relic_id; 
        private string _cover_url; 
        private string _media_url; 
        private sbyte? _media_type; 
        private DateTime _create_time; 

        /// <summary>
        /// 编号  varchar(50)
        /// <summary>
        [Column("id",IsNullable=false)]
        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
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
        /// 封面图  varchar(500)
        /// <summary>
        [Column("cover_url",IsNullable=true)]
        public string CoverUrl
        {
            get { return _cover_url; }
            set { _cover_url = value; OnPropertyChanged("cover_url"); }
        }
        /// <summary>
        /// 资源地址  varchar(500)
        /// <summary>
        [Column("media_url",IsNullable=true)]
        public string MediaUrl
        {
            get { return _media_url; }
            set { _media_url = value; OnPropertyChanged("media_url"); }
        }
        /// <summary>
        /// 资源类型  1= 视频 2=3d模型  tinyint(4)
        /// <summary>
        [Column("media_type",IsNullable=true)]
        public sbyte? MediaType
        {
            get { return _media_type; }
            set { _media_type = value; OnPropertyChanged("media_type"); }
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