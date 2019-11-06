/*
该文件为自动生成，不要修改。
生成时间：2019-11-06 13:52:16。
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
    [Table("config_app")]
    public partial class ConfigApp : BaseEntity
    {
        private int _app_id; 
        private string _app_code; 
        private string _app_name; 
        private string _create_user; 
        private string _update_user; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 
        /// <summary>
        [Column("app_id")]
        [PrimaryKey]
        [Identity]
        public int AppId
        {
            get { return _app_id; }
            set { _app_id = value; OnPropertyChanged("app_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("app_code")]
        public string AppCode
        {
            get { return _app_code; }
            set { _app_code = value; OnPropertyChanged("app_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("app_name")]
        public string AppName
        {
            get { return _app_name; }
            set { _app_name = value; OnPropertyChanged("app_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_user")]
        public string CreateUser
        {
            get { return _create_user; }
            set { _create_user = value; OnPropertyChanged("create_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_user")]
        public string UpdateUser
        {
            get { return _update_user; }
            set { _update_user = value; OnPropertyChanged("update_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("config_group")]
    public partial class ConfigGroup : BaseEntity
    {
        private int _group_id; 
        private int? _app_id; 
        private int? _parent_id; 
        private string _group_code; 
        private string _group_name; 
        private string _create_user; 
        private DateTime _create_time; 
        private string _update_user; 
        private DateTime _update_time; 

        /// <summary>
        /// 
        /// <summary>
        [Column("group_id")]
        [PrimaryKey]
        [Identity]
        public int GroupId
        {
            get { return _group_id; }
            set { _group_id = value; OnPropertyChanged("group_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("app_id")]
        public int? AppId
        {
            get { return _app_id; }
            set { _app_id = value; OnPropertyChanged("app_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("parent_id")]
        public int? ParentId
        {
            get { return _parent_id; }
            set { _parent_id = value; OnPropertyChanged("parent_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("group_code")]
        public string GroupCode
        {
            get { return _group_code; }
            set { _group_code = value; OnPropertyChanged("group_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("group_name")]
        public string GroupName
        {
            get { return _group_name; }
            set { _group_name = value; OnPropertyChanged("group_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_user")]
        public string CreateUser
        {
            get { return _create_user; }
            set { _create_user = value; OnPropertyChanged("create_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_user")]
        public string UpdateUser
        {
            get { return _update_user; }
            set { _update_user = value; OnPropertyChanged("update_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("config_item")]
    public partial class ConfigItem : BaseEntity
    {
        private int _id; 
        private int _group_id; 
        private string _key; 
        private string _value; 
        private int _status; 
        private string _remark; 
        private int _sequence; 
        private string _create_user; 
        private DateTime _create_time; 
        private string _update_user; 
        private DateTime _update_time; 

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
        [Column("group_id")]
        public int GroupId
        {
            get { return _group_id; }
            set { _group_id = value; OnPropertyChanged("group_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; OnPropertyChanged("key"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged("value"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("sequence")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_user")]
        public string CreateUser
        {
            get { return _create_user; }
            set { _create_user = value; OnPropertyChanged("create_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_user")]
        public string UpdateUser
        {
            get { return _update_user; }
            set { _update_user = value; OnPropertyChanged("update_user"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

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
        /// 
        /// <summary>
        [Column("product_id")]
        [PrimaryKey]
        [Identity]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_code")]
        public string ProductCode
        {
            get { return _product_code; }
            set { _product_code = value; OnPropertyChanged("product_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_name")]
        public string ProductName
        {
            get { return _product_name; }
            set { _product_name = value; OnPropertyChanged("product_name"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("product_relic_item_ref")]
    public partial class ProductRelicItemRef : BaseEntity
    {
        private int _id; 
        private int _product_id; 
        private int _relic_id; 
        private string _modifier_id; 
        private DateTime _modify_time; 

        /// <summary>
        /// 编号
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
        /// 商品ID
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
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
        /// 修改人编号
        /// <summary>
        [Column("modifier_id")]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 修改日期
        /// <summary>
        [Column("modify_time")]
        public DateTime ModifyTime
        {
            get { return _modify_time; }
            set { _modify_time = value; OnPropertyChanged("modify_time"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("product_sku")]
    public partial class ProductSku : BaseEntity
    {
        private int _sku_id; 
        private string _sku_code; 
        private string _sku_name; 
        private int _product_id; 

        /// <summary>
        /// 
        /// <summary>
        [Column("sku_id")]
        [PrimaryKey]
        [Identity]
        public int SkuId
        {
            get { return _sku_id; }
            set { _sku_id = value; OnPropertyChanged("sku_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("sku_code")]
        public string SkuCode
        {
            get { return _sku_code; }
            set { _sku_code = value; OnPropertyChanged("sku_code"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("sku_name")]
        public string SkuName
        {
            get { return _sku_name; }
            set { _sku_name = value; OnPropertyChanged("sku_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

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
        /// 编号
        /// <summary>
        [Column("id")]
        [PrimaryKey]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 物品名称
        /// <summary>
        [Column("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 首图URLS 图片JSON格式
        /// <summary>
        [Column("cover_urls")]
        public string CoverUrls
        {
            get { return _cover_urls; }
            set { _cover_urls = value; OnPropertyChanged("cover_urls"); }
        }
        /// <summary>
        /// 展示图-如果没有取cover_urls的l图
        /// <summary>
        [Column("show_cover_url")]
        public string ShowCoverUrl
        {
            get { return _show_cover_url; }
            set { _show_cover_url = value; OnPropertyChanged("show_cover_url"); }
        }
        /// <summary>
        /// 缩略展示图如果没有则取cover_urls的m图
        /// <summary>
        [Column("thumbnail_url")]
        public string ThumbnailUrl
        {
            get { return _thumbnail_url; }
            set { _thumbnail_url = value; OnPropertyChanged("thumbnail_url"); }
        }
        /// <summary>
        /// 350*450 缩略图尺寸用于瀑布流展示尺寸
        /// <summary>
        [Column("thumbnail_size")]
        public string ThumbnailSize
        {
            get { return _thumbnail_size; }
            set { _thumbnail_size = value; OnPropertyChanged("thumbnail_size"); }
        }
        /// <summary>
        /// 分享展示图，如果没有取cover_urls 的L图
        /// <summary>
        [Column("share_url")]
        public string ShareUrl
        {
            get { return _share_url; }
            set { _share_url = value; OnPropertyChanged("share_url"); }
        }
        /// <summary>
        /// 摘要
        /// <summary>
        [Column("summary")]
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("summary"); }
        }
        /// <summary>
        /// 详细信息
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 藏品材质ID
        /// <summary>
        [Column("material")]
        public int Material
        {
            get { return _material; }
            set { _material = value; OnPropertyChanged("material"); }
        }
        /// <summary>
        /// 材质 材质数据字典
        /// <summary>
        [Column("material_name")]
        public string MaterialName
        {
            get { return _material_name; }
            set { _material_name = value; OnPropertyChanged("material_name"); }
        }
        /// <summary>
        /// 来源博物馆ID
        /// <summary>
        [Column("museum_id")]
        public int MuseumId
        {
            get { return _museum_id; }
            set { _museum_id = value; OnPropertyChanged("museum_id"); }
        }
        /// <summary>
        /// 年代
        /// <summary>
        [Column("dynasty")]
        public int Dynasty
        {
            get { return _dynasty; }
            set { _dynasty = value; OnPropertyChanged("dynasty"); }
        }
        /// <summary>
        /// 年代显示名 年代数据字典
        /// <summary>
        [Column("dynasty_name")]
        public string DynastyName
        {
            get { return _dynasty_name; }
            set { _dynasty_name = value; OnPropertyChanged("dynasty_name"); }
        }
        /// <summary>
        /// 功用字典值
        /// <summary>
        [Column("usage")]
        public int Usage
        {
            get { return _usage; }
            set { _usage = value; OnPropertyChanged("usage"); }
        }
        /// <summary>
        /// 功用 功用数据字典
        /// <summary>
        [Column("usage_name")]
        public string UsageName
        {
            get { return _usage_name; }
            set { _usage_name = value; OnPropertyChanged("usage_name"); }
        }
        /// <summary>
        /// 价值 价值数据字典
        /// <summary>
        [Column("value_level")]
        public int ValueLevel
        {
            get { return _value_level; }
            set { _value_level = value; OnPropertyChanged("value_level"); }
        }
        /// <summary>
        /// 价值显示
        /// <summary>
        [Column("value_level_name")]
        public string ValueLevelName
        {
            get { return _value_level_name; }
            set { _value_level_name = value; OnPropertyChanged("value_level_name"); }
        }
        /// <summary>
        /// 来源
        /// <summary>
        [Column("museum_name")]
        public string MuseumName
        {
            get { return _museum_name; }
            set { _museum_name = value; OnPropertyChanged("museum_name"); }
        }
        /// <summary>
        /// 标签
        /// <summary>
        [Column("tags")]
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; OnPropertyChanged("tags"); }
        }
        /// <summary>
        /// 标记 标记1 = 突出
        /// <summary>
        [Column("flag")]
        public sbyte Flag
        {
            get { return _flag; }
            set { _flag = value; OnPropertyChanged("flag"); }
        }
        /// <summary>
        /// 是否有3d模型 1=有 0=无
        /// <summary>
        [Column("view_3d_flag")]
        public sbyte View3dFlag
        {
            get { return _view_3d_flag; }
            set { _view_3d_flag = value; OnPropertyChanged("view_3d_flag"); }
        }
        /// <summary>
        /// 编辑用户 最后编辑用户
        /// <summary>
        [Column("modifier_id")]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 置顶类型
        /// <summary>
        [Column("top_type")]
        public sbyte TopType
        {
            get { return _top_type; }
            set { _top_type = value; OnPropertyChanged("top_type"); }
        }
        /// <summary>
        /// 显示时间
        /// <summary>
        [Column("show_after_time")]
        public DateTime? ShowAfterTime
        {
            get { return _show_after_time; }
            set { _show_after_time = value; OnPropertyChanged("show_after_time"); }
        }
        /// <summary>
        /// 状态 1=有效 0=无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 排序号
        /// <summary>
        [Column("sequence")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

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
        /// 主键编号 主键编号
        /// <summary>
        [Column("id")]
        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 图片JSON信息
        /// <summary>
        [Column("pic_urls")]
        public string PicUrls
        {
            get { return _pic_urls; }
            set { _pic_urls = value; OnPropertyChanged("pic_urls"); }
        }
        /// <summary>
        /// 藏品编号 藏品编号
        /// <summary>
        [Column("relic_id")]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 排序号 排序号
        /// <summary>
        [Column("sequence")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
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

    /// <summary>
    /// 
    /// <summary>
    [Table("relic_tag")]
    public partial class RelicTag : BaseEntity
    {
        private int _id; 
        private int _relic_id; 
        private sbyte _tag_type; 
        private string _content; 
        private int _sequence; 
        private DateTime _create_time; 

        /// <summary>
        /// 主键标识 主键标识 
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
        /// 藏品id 藏品id
        /// <summary>
        [Column("relic_id")]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 标签类型 标签类型 1=年代 2=功用 3=来源 4=类别 5=价值6=自定义标签
        /// <summary>
        [Column("tag_type")]
        public sbyte TagType
        {
            get { return _tag_type; }
            set { _tag_type = value; OnPropertyChanged("tag_type"); }
        }
        /// <summary>
        /// 标签内容 标签内容
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 序号 序号 正序
        /// <summary>
        [Column("sequence")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
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

    /// <summary>
    /// 
    /// <summary>
    [Table("temp_import_data")]
    public partial class TempImportData : BaseEntity
    {
        private int _relic_id; 
        private int _product_id; 

        /// <summary>
        /// 
        /// <summary>
        [Column("relic_id")]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("test_sta")]
    public partial class TestSta : BaseEntity
    {
        private int _id; 
        private int _view_count; 

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
        [Column("view_count")]
        public int ViewCount
        {
            get { return _view_count; }
            set { _view_count = value; OnPropertyChanged("view_count"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("user_info")]
    public partial class UserInfo : BaseEntity
    {
        private int _user_id; 
        private string _user_name; 
        private bool _status; 
        private sbyte _type; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 主键
        /// <summary>
        [Column("user_id")]
        [PrimaryKey]
        [Identity]
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 用户名称
        /// <summary>
        [Column("user_name")]
        public string UserName
        {
            get { return _user_name; }
            set { _user_name = value; OnPropertyChanged("user_name"); }
        }
        /// <summary>
        /// 状态 true=有效 false=无效
        /// <summary>
        [Column("status")]
        public bool Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 类型 1=a , 2=b
        /// <summary>
        [Column("type")]
        public sbyte Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("type"); }
        }
        /// <summary>
        /// 创建时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 修改时间
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("user_opus")]
    public partial class UserOpus : BaseEntity
    {
        private long _opus_id; 
        private long _user_id; 
        private string _title; 
        private int _category; 
        private string _with_topic; 
        private string _content; 
        private string _cover_url; 
        private string _voice_url; 
        private string _audition_url; 
        private sbyte _recommend_type; 
        private sbyte _hot_type; 
        private sbyte _status; 
        private sbyte _pay_type; 
        private DateTime _create_time; 
        private DateTime? _update_time; 
        private sbyte? _isread; 
        private int _duration; 
        private int _isload; 

        /// <summary>
        /// 编号 编号 全局自增ID
        /// <summary>
        [Column("opus_id")]
        [PrimaryKey]
        public long OpusId
        {
            get { return _opus_id; }
            set { _opus_id = value; OnPropertyChanged("opus_id"); }
        }
        /// <summary>
        /// 用户ID 所属应用ID
        /// <summary>
        [Column("user_id")]
        public long UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 标题 标题
        /// <summary>
        [Column("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 分类 分类 1 大胆说爱 2 元气闹钟 3 失意诊所 4 入眠胶囊
        /// <summary>
        [Column("category")]
        public int Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged("category"); }
        }
        /// <summary>
        /// 话题
        /// <summary>
        [Column("with_topic")]
        public string WithTopic
        {
            get { return _with_topic; }
            set { _with_topic = value; OnPropertyChanged("with_topic"); }
        }
        /// <summary>
        /// 简介 简介
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 封面图_URL
        /// <summary>
        [Column("cover_url")]
        public string CoverUrl
        {
            get { return _cover_url; }
            set { _cover_url = value; OnPropertyChanged("cover_url"); }
        }
        /// <summary>
        /// 语音地址
        /// <summary>
        [Column("voice_url")]
        public string VoiceUrl
        {
            get { return _voice_url; }
            set { _voice_url = value; OnPropertyChanged("voice_url"); }
        }
        /// <summary>
        /// 试听的地址
        /// <summary>
        [Column("audition_url")]
        public string AuditionUrl
        {
            get { return _audition_url; }
            set { _audition_url = value; OnPropertyChanged("audition_url"); }
        }
        /// <summary>
        /// 推荐类型 推荐类型 1= 已推荐 0=未推荐
        /// <summary>
        [Column("recommend_type")]
        public sbyte RecommendType
        {
            get { return _recommend_type; }
            set { _recommend_type = value; OnPropertyChanged("recommend_type"); }
        }
        /// <summary>
        /// 是否热推 0=否 1=是
        /// <summary>
        [Column("hot_type")]
        public sbyte HotType
        {
            get { return _hot_type; }
            set { _hot_type = value; OnPropertyChanged("hot_type"); }
        }
        /// <summary>
        /// 可见状态 可见状态 0= 待审核 1=审核通过  2= 审核不通过
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 付费类型 付费类型 1=免费 2=道具收费 将来扩展
        /// <summary>
        [Column("pay_type")]
        public sbyte PayType
        {
            get { return _pay_type; }
            set { _pay_type = value; OnPropertyChanged("pay_type"); }
        }
        /// <summary>
        /// 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间
        /// <summary>
        [Column("update_time")]
        public DateTime? UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
        /// <summary>
        /// 0=未阅读 1=已阅读
        /// <summary>
        [Column("isread")]
        public sbyte? Isread
        {
            get { return _isread; }
            set { _isread = value; OnPropertyChanged("isread"); }
        }
        /// <summary>
        /// 声品时长
        /// <summary>
        [Column("duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged("duration"); }
        }
        /// <summary>
        /// 是否下载音频文件
        /// <summary>
        [Column("isload")]
        public int Isload
        {
            get { return _isload; }
            set { _isload = value; OnPropertyChanged("isload"); }
        }
    }

}
