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
    [Table("relic_item")]
    public partial class RelicItem : BaseEntity
    {
        private int _id; 
        private string _title; 
        private string _cover_urls; 
        private string _show_cover_url; 
        private string _thumbnail_url; 
        private string _thumbnail_size; 
        private string _share_url; 
        private string _summary; 
        private string _content; 
        private int _material; 
        private string _material_name; 
        private int _museum_id; 
        private int _dynasty; 
        private string _dynasty_name; 
        private int _usage; 
        private string _usage_name; 
        private int _value_level; 
        private string _value_level_name; 
        private string _museum_name; 
        private string _tags; 
        private sbyte _flag; 
        private sbyte _view_3d_flag; 
        private string _modifier_id; 
        private sbyte _top_type; 
        private DateTime? _show_after_time; 
        private sbyte _status; 
        private int _sequence; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 编号  int(11)
        /// <summary>
        [Column("id",IsNullable=false)]
        [PrimaryKey]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 物品名称  varchar(200)
        /// <summary>
        [Column("title",IsNullable=true)]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 首图URLS 图片JSON格式  varchar(1000)
        /// <summary>
        [Column("cover_urls",IsNullable=true)]
        public string CoverUrls
        {
            get { return _cover_urls; }
            set { _cover_urls = value; OnPropertyChanged("cover_urls"); }
        }
        /// <summary>
        /// 展示图-如果没有取cover_urls的l图  varchar(255)
        /// <summary>
        [Column("show_cover_url",IsNullable=true)]
        public string ShowCoverUrl
        {
            get { return _show_cover_url; }
            set { _show_cover_url = value; OnPropertyChanged("show_cover_url"); }
        }
        /// <summary>
        /// 缩略展示图如果没有则取cover_urls的m图  varchar(255)
        /// <summary>
        [Column("thumbnail_url",IsNullable=true)]
        public string ThumbnailUrl
        {
            get { return _thumbnail_url; }
            set { _thumbnail_url = value; OnPropertyChanged("thumbnail_url"); }
        }
        /// <summary>
        /// 350*450 缩略图尺寸用于瀑布流展示尺寸  varchar(50)
        /// <summary>
        [Column("thumbnail_size",IsNullable=true)]
        public string ThumbnailSize
        {
            get { return _thumbnail_size; }
            set { _thumbnail_size = value; OnPropertyChanged("thumbnail_size"); }
        }
        /// <summary>
        /// 分享展示图，如果没有取cover_urls 的L图  varchar(255)
        /// <summary>
        [Column("share_url",IsNullable=true)]
        public string ShareUrl
        {
            get { return _share_url; }
            set { _share_url = value; OnPropertyChanged("share_url"); }
        }
        /// <summary>
        /// 摘要  varchar(255)
        /// <summary>
        [Column("summary",IsNullable=false,DefaultValue="0")]
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("summary"); }
        }
        /// <summary>
        /// 详细信息  text
        /// <summary>
        [Column("content",IsNullable=false)]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 藏品材质ID  int(11)
        /// <summary>
        [Column("material",IsNullable=false,DefaultValue="0")]
        public int Material
        {
            get { return _material; }
            set { _material = value; OnPropertyChanged("material"); }
        }
        /// <summary>
        /// 材质 材质数据字典  varchar(50)
        /// <summary>
        [Column("material_name",IsNullable=false)]
        public string MaterialName
        {
            get { return _material_name; }
            set { _material_name = value; OnPropertyChanged("material_name"); }
        }
        /// <summary>
        /// 来源博物馆ID  int(11)
        /// <summary>
        [Column("museum_id",IsNullable=false,DefaultValue="0")]
        public int MuseumId
        {
            get { return _museum_id; }
            set { _museum_id = value; OnPropertyChanged("museum_id"); }
        }
        /// <summary>
        /// 年代  int(11)
        /// <summary>
        [Column("dynasty",IsNullable=false)]
        public int Dynasty
        {
            get { return _dynasty; }
            set { _dynasty = value; OnPropertyChanged("dynasty"); }
        }
        /// <summary>
        /// 年代显示名 年代数据字典  varchar(50)
        /// <summary>
        [Column("dynasty_name",IsNullable=false)]
        public string DynastyName
        {
            get { return _dynasty_name; }
            set { _dynasty_name = value; OnPropertyChanged("dynasty_name"); }
        }
        /// <summary>
        /// 功用字典值  int(11)
        /// <summary>
        [Column("usage",IsNullable=false,DefaultValue="0")]
        public int Usage
        {
            get { return _usage; }
            set { _usage = value; OnPropertyChanged("usage"); }
        }
        /// <summary>
        /// 功用 功用数据字典  varchar(50)
        /// <summary>
        [Column("usage_name",IsNullable=false)]
        public string UsageName
        {
            get { return _usage_name; }
            set { _usage_name = value; OnPropertyChanged("usage_name"); }
        }
        /// <summary>
        /// 价值 价值数据字典  int(11)
        /// <summary>
        [Column("value_level",IsNullable=false)]
        public int ValueLevel
        {
            get { return _value_level; }
            set { _value_level = value; OnPropertyChanged("value_level"); }
        }
        /// <summary>
        /// 价值显示  varchar(50)
        /// <summary>
        [Column("value_level_name",IsNullable=false)]
        public string ValueLevelName
        {
            get { return _value_level_name; }
            set { _value_level_name = value; OnPropertyChanged("value_level_name"); }
        }
        /// <summary>
        /// 来源  varchar(100)
        /// <summary>
        [Column("museum_name",IsNullable=false)]
        public string MuseumName
        {
            get { return _museum_name; }
            set { _museum_name = value; OnPropertyChanged("museum_name"); }
        }
        /// <summary>
        /// 标签  varchar(500)
        /// <summary>
        [Column("tags",IsNullable=true)]
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; OnPropertyChanged("tags"); }
        }
        /// <summary>
        /// 标记 标记1 = 突出  tinyint(4)
        /// <summary>
        [Column("flag",IsNullable=false,DefaultValue="0")]
        public sbyte Flag
        {
            get { return _flag; }
            set { _flag = value; OnPropertyChanged("flag"); }
        }
        /// <summary>
        /// 是否有3d模型 1=有 0=无  tinyint(4)
        /// <summary>
        [Column("view_3d_flag",IsNullable=false,DefaultValue="0")]
        public sbyte View3dFlag
        {
            get { return _view_3d_flag; }
            set { _view_3d_flag = value; OnPropertyChanged("view_3d_flag"); }
        }
        /// <summary>
        /// 编辑用户 最后编辑用户  varchar(50)
        /// <summary>
        [Column("modifier_id",IsNullable=false)]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 置顶类型  tinyint(4)
        /// <summary>
        [Column("top_type",IsNullable=false,DefaultValue="0")]
        public sbyte TopType
        {
            get { return _top_type; }
            set { _top_type = value; OnPropertyChanged("top_type"); }
        }
        /// <summary>
        /// 显示时间  datetime
        /// <summary>
        [Column("show_after_time",IsNullable=true)]
        public DateTime? ShowAfterTime
        {
            get { return _show_after_time; }
            set { _show_after_time = value; OnPropertyChanged("show_after_time"); }
        }
        /// <summary>
        /// 状态 1=有效 0=无效  tinyint(4)
        /// <summary>
        [Column("status",IsNullable=false,DefaultValue="0")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 排序号  int(11)
        /// <summary>
        [Column("sequence",IsNullable=false,DefaultValue="0")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 开始时间  datetime
        /// <summary>
        [Column("create_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间  datetime
        /// <summary>
        [Column("update_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

}