/*
该文件为自动生成，不要修改。
生成时间：2019-10-17 10:54:14。
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

        [Column("isload")]
        public int Isload
        {
            get { return _isload; }
            set { _isload = value; OnPropertyChanged("isload"); }
        }
        
    }

}
