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
    /// 拍卖品
    /// <summary>
    [Table("cms_auction_item")]
    public partial class CmsAuctionItem : BaseEntity
    {
        private int _id; 
        private string _title; 
        private string _cover_url; 
        private string _owner; 
        private string _platform; 
        private int _valuation; 
        private int _start_price; 
        private DateTime _start_time; 
        private string _content; 
        private sbyte _status; 
        private int _sequence; 
        private DateTime? _publish_time; 
        private string _creator_id; 
        private DateTime _create_time; 
        private string _modifier_id; 
        private DateTime _modify_time; 

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
        /// 拍卖品名称  varchar(50)
        /// <summary>
        [Column("title",IsNullable=false)]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 封面图  varchar(1000)
        /// <summary>
        [Column("cover_url",IsNullable=false)]
        public string CoverUrl
        {
            get { return _cover_url; }
            set { _cover_url = value; OnPropertyChanged("cover_url"); }
        }
        /// <summary>
        /// 持有人  varchar(50)
        /// <summary>
        [Column("owner",IsNullable=false)]
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; OnPropertyChanged("owner"); }
        }
        /// <summary>
        /// 拍卖平台  varchar(50)
        /// <summary>
        [Column("platform",IsNullable=false)]
        public string Platform
        {
            get { return _platform; }
            set { _platform = value; OnPropertyChanged("platform"); }
        }
        /// <summary>
        /// 拍卖估值  int(11)
        /// <summary>
        [Column("valuation",IsNullable=false,DefaultValue="0")]
        public int Valuation
        {
            get { return _valuation; }
            set { _valuation = value; OnPropertyChanged("valuation"); }
        }
        /// <summary>
        /// 起拍价  int(11)
        /// <summary>
        [Column("start_price",IsNullable=false,DefaultValue="0")]
        public int StartPrice
        {
            get { return _start_price; }
            set { _start_price = value; OnPropertyChanged("start_price"); }
        }
        /// <summary>
        /// 起拍时间  datetime
        /// <summary>
        [Column("start_time",IsNullable=false)]
        public DateTime StartTime
        {
            get { return _start_time; }
            set { _start_time = value; OnPropertyChanged("start_time"); }
        }
        /// <summary>
        /// 拍品简介  varchar(1000)
        /// <summary>
        [Column("content",IsNullable=true)]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 状态 0 = 待发布（不显示）1=发布 9=删除  tinyint(4)
        /// <summary>
        [Column("status",IsNullable=false)]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 排序  int(11)
        /// <summary>
        [Column("sequence",IsNullable=false,DefaultValue="0")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 发布时间 进行发布操作时更新为当前时间  datetime
        /// <summary>
        [Column("publish_time",IsNullable=true)]
        public DateTime? PublishTime
        {
            get { return _publish_time; }
            set { _publish_time = value; OnPropertyChanged("publish_time"); }
        }
        /// <summary>
        /// 创建人编号  varchar(50)
        /// <summary>
        [Column("creator_id",IsNullable=false)]
        public string CreatorId
        {
            get { return _creator_id; }
            set { _creator_id = value; OnPropertyChanged("creator_id"); }
        }
        /// <summary>
        /// 创建日期  datetime
        /// <summary>
        [Column("create_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
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