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
        /// 编号
        /// <summary>
        [Column("id")]
        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
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
        /// 封面图
        /// <summary>
        [Column("cover_url")]
        public string CoverUrl
        {
            get { return _cover_url; }
            set { _cover_url = value; OnPropertyChanged("cover_url"); }
        }
        /// <summary>
        /// 资源地址
        /// <summary>
        [Column("media_url")]
        public string MediaUrl
        {
            get { return _media_url; }
            set { _media_url = value; OnPropertyChanged("media_url"); }
        }
        /// <summary>
        /// 资源类型  1= 视频 2=3d模型
        /// <summary>
        [Column("media_type")]
        public sbyte? MediaType
        {
            get { return _media_type; }
            set { _media_type = value; OnPropertyChanged("media_type"); }
        }
        /// <summary>
        /// 创建时间 创建时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
    }

}