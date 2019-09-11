/*
该文件为自动生成，不要修改。
生成时间：2019-09-09 14:54:50。
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
    [Table("admin_user")]
    public partial class AdminUser : BaseEntity
    {
        private string _user_id; 
        private string _password; 
        private string _full_name; 
        private sbyte _status; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 用户账号 用户账号
        /// <summary>
        [Column("user_id")]
        [PrimaryKey]
        public string UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 密码
        /// <summary>
        [Column("password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("password"); }
        }
        /// <summary>
        /// 用户名称
        /// <summary>
        [Column("full_name")]
        public string FullName
        {
            get { return _full_name; }
            set { _full_name = value; OnPropertyChanged("full_name"); }
        }
        /// <summary>
        /// 状态 状态 1= 有效 0=无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
    [Table("app_config")]
    public partial class AppConfig : BaseEntity
    {
        private int _id; 
        private string _conf_key; 
        private sbyte _conf_type; 
        private string _conf_value; 
        private sbyte _status; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 编号 编号
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
        /// 配置key
        /// <summary>
        [Column("conf_key")]
        public string ConfKey
        {
            get { return _conf_key; }
            set { _conf_key = value; OnPropertyChanged("conf_key"); }
        }
        /// <summary>
        /// 配置类型 配置类型1 = 全平台  10=苹果 20=安卓
        /// <summary>
        [Column("conf_type")]
        public sbyte ConfType
        {
            get { return _conf_type; }
            set { _conf_type = value; OnPropertyChanged("conf_type"); }
        }
        /// <summary>
        /// 配置值
        /// <summary>
        [Column("conf_value")]
        public string ConfValue
        {
            get { return _conf_value; }
            set { _conf_value = value; OnPropertyChanged("conf_value"); }
        }
        /// <summary>
        /// 状态 状态 1= 有效 0=无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
    [Table("bg_city")]
    public partial class BgCity : BaseEntity
    {
        private int _id; 
        private string _city_name; 
        private string _city_code; 
        private string _province_name; 
        private string _province_code; 

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
        /// 城市名称
        /// <summary>
        [Column("city_name")]
        public string CityName
        {
            get { return _city_name; }
            set { _city_name = value; OnPropertyChanged("city_name"); }
        }
        /// <summary>
        /// 城市代码
        /// <summary>
        [Column("city_code")]
        public string CityCode
        {
            get { return _city_code; }
            set { _city_code = value; OnPropertyChanged("city_code"); }
        }
        /// <summary>
        /// 省份名称
        /// <summary>
        [Column("province_name")]
        public string ProvinceName
        {
            get { return _province_name; }
            set { _province_name = value; OnPropertyChanged("province_name"); }
        }
        /// <summary>
        /// 省份代码
        /// <summary>
        [Column("province_code")]
        public string ProvinceCode
        {
            get { return _province_code; }
            set { _province_code = value; OnPropertyChanged("province_code"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("bg_province")]
    public partial class BgProvince : BaseEntity
    {
        private int _id; 
        private string _province_name; 
        private string _province_code; 

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
        /// 名称
        /// <summary>
        [Column("province_name")]
        public string ProvinceName
        {
            get { return _province_name; }
            set { _province_name = value; OnPropertyChanged("province_name"); }
        }
        /// <summary>
        /// 代码
        /// <summary>
        [Column("province_code")]
        public string ProvinceCode
        {
            get { return _province_code; }
            set { _province_code = value; OnPropertyChanged("province_code"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("block_ip_cfg")]
    public partial class BlockIpCfg : BaseEntity
    {
        private int _id; 
        private string _ip_address; 
        private sbyte _status; 
        private string _admin_user_id; 
        private string _remark; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 编号 编号
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
        /// 目标的IP地址 目标的IP地址，支持正则
        /// <summary>
        [Column("ip_address")]
        public string IpAddress
        {
            get { return _ip_address; }
            set { _ip_address = value; OnPropertyChanged("ip_address"); }
        }
        /// <summary>
        /// 状态 状态1= 有效 0 = 无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 设置的管理员账号
        /// <summary>
        [Column("admin_user_id")]
        public string AdminUserId
        {
            get { return _admin_user_id; }
            set { _admin_user_id = value; OnPropertyChanged("admin_user_id"); }
        }
        /// <summary>
        /// 备注
        /// <summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
    [Table("complaint")]
    public partial class Complaint : BaseEntity
    {
        private int _id; 
        private long _user_id; 
        private sbyte _complaint_type; 
        private sbyte _complaint_source_type; 
        private string _content; 
        private int _ref_item_id; 
        private string _ref_comment_id; 
        private string _ref_pic_urls; 
        private string _link_way; 
        private sbyte _status; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 主键自增 主键自增
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
        /// 用户ID 用户ID
        /// <summary>
        [Column("user_id")]
        public long UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 投诉类型 投诉类型 1= 详见数据字典 1= 投诉藏品
        /// <summary>
        [Column("complaint_type")]
        public sbyte ComplaintType
        {
            get { return _complaint_type; }
            set { _complaint_type = value; OnPropertyChanged("complaint_type"); }
        }
        /// <summary>
        /// 投诉源类型 详见数据字典
        /// <summary>
        [Column("complaint_source_type")]
        public sbyte ComplaintSourceType
        {
            get { return _complaint_source_type; }
            set { _complaint_source_type = value; OnPropertyChanged("complaint_source_type"); }
        }
        /// <summary>
        /// 反馈内容
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 关联物品ID
        /// <summary>
        [Column("ref_item_id")]
        public int RefItemId
        {
            get { return _ref_item_id; }
            set { _ref_item_id = value; OnPropertyChanged("ref_item_id"); }
        }
        /// <summary>
        /// 关联的评论ID
        /// <summary>
        [Column("ref_comment_id")]
        public string RefCommentId
        {
            get { return _ref_comment_id; }
            set { _ref_comment_id = value; OnPropertyChanged("ref_comment_id"); }
        }
        /// <summary>
        /// 相关图片
        /// <summary>
        [Column("ref_pic_urls")]
        public string RefPicUrls
        {
            get { return _ref_pic_urls; }
            set { _ref_pic_urls = value; OnPropertyChanged("ref_pic_urls"); }
        }
        /// <summary>
        /// 回访联系方式
        /// <summary>
        [Column("link_way")]
        public string LinkWay
        {
            get { return _link_way; }
            set { _link_way = value; OnPropertyChanged("link_way"); }
        }
        /// <summary>
        /// 状态 状态 0 =新提交 1=已查看 =2 已受理 3=已反馈 9=无效反馈
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 创建时间 创建时间 创建时间-按创建时间分区
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
        private int _app_id; 
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
        public int AppId
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
    [Table("delay_task")]
    public partial class DelayTask : BaseEntity
    {
        private int _task_id; 
        private string _task_code; 
        private string _check_code; 
        private string _task_desc; 
        private int _service_id; 
        private int _message_id; 
        private DateTime _excute_time; 
        private string _excute_data; 
        private sbyte _status; 
        private int _fail_count; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 编号
        /// <summary>
        [Column("task_id")]
        [PrimaryKey]
        [Identity]
        public int TaskId
        {
            get { return _task_id; }
            set { _task_id = value; OnPropertyChanged("task_id"); }
        }
        /// <summary>
        /// 任务标识用于检索
        /// <summary>
        [Column("task_code")]
        public string TaskCode
        {
            get { return _task_code; }
            set { _task_code = value; OnPropertyChanged("task_code"); }
        }
        /// <summary>
        /// 检查代码 用于检查判断是否重复任务，只更新执行时间
        /// <summary>
        [Column("check_code")]
        public string CheckCode
        {
            get { return _check_code; }
            set { _check_code = value; OnPropertyChanged("check_code"); }
        }
        /// <summary>
        /// 任务说明
        /// <summary>
        [Column("task_desc")]
        public string TaskDesc
        {
            get { return _task_desc; }
            set { _task_desc = value; OnPropertyChanged("task_desc"); }
        }
        /// <summary>
        /// 延迟任务调用的服务ID
        /// <summary>
        [Column("service_id")]
        public int ServiceId
        {
            get { return _service_id; }
            set { _service_id = value; OnPropertyChanged("service_id"); }
        }
        /// <summary>
        /// 延迟任务调用消息ID
        /// <summary>
        [Column("message_id")]
        public int MessageId
        {
            get { return _message_id; }
            set { _message_id = value; OnPropertyChanged("message_id"); }
        }
        /// <summary>
        /// 执行时间
        /// <summary>
        [Column("excute_time")]
        public DateTime ExcuteTime
        {
            get { return _excute_time; }
            set { _excute_time = value; OnPropertyChanged("excute_time"); }
        }
        /// <summary>
        /// 执行参数JSON
        /// <summary>
        [Column("excute_data")]
        public string ExcuteData
        {
            get { return _excute_data; }
            set { _excute_data = value; OnPropertyChanged("excute_data"); }
        }
        /// <summary>
        /// 状态 状态1= 有效 0=失效 2=已执行
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 失败次数
        /// <summary>
        [Column("fail_count")]
        public int FailCount
        {
            get { return _fail_count; }
            set { _fail_count = value; OnPropertyChanged("fail_count"); }
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
    [Table("dict_info")]
    public partial class DictInfo : BaseEntity
    {
        private int _dict_id; 
        private string _dict_code; 
        private string _dict_name; 
        private string _parent_code; 
        private string _dict_value; 
        private sbyte _dict_type; 
        private string _dynamic_sql; 
        private int _sequence; 
        private string _remark; 
        private DateTime _create_time; 

        /// <summary>
        /// 自增 自增
        /// <summary>
        [Column("dict_id")]
        [PrimaryKey]
        [Identity]
        public int DictId
        {
            get { return _dict_id; }
            set { _dict_id = value; OnPropertyChanged("dict_id"); }
        }
        /// <summary>
        /// 数据字典标识 数据字典标识
        /// <summary>
        [Column("dict_code")]
        public string DictCode
        {
            get { return _dict_code; }
            set { _dict_code = value; OnPropertyChanged("dict_code"); }
        }
        /// <summary>
        /// 数据字典名称 数据字典名称
        /// <summary>
        [Column("dict_name")]
        public string DictName
        {
            get { return _dict_name; }
            set { _dict_name = value; OnPropertyChanged("dict_name"); }
        }
        /// <summary>
        /// 父字典ID 父字典ID
        /// <summary>
        [Column("parent_code")]
        public string ParentCode
        {
            get { return _parent_code; }
            set { _parent_code = value; OnPropertyChanged("parent_code"); }
        }
        /// <summary>
        /// 数据字典的值 数据字典的值
        /// <summary>
        [Column("dict_value")]
        public string DictValue
        {
            get { return _dict_value; }
            set { _dict_value = value; OnPropertyChanged("dict_value"); }
        }
        /// <summary>
        /// 字典类型 字典类型，0 静态字典 1 动态字典 2 数据项
        /// <summary>
        [Column("dict_type")]
        public sbyte DictType
        {
            get { return _dict_type; }
            set { _dict_type = value; OnPropertyChanged("dict_type"); }
        }
        /// <summary>
        /// 动态字典的SQL语句 动态字典的SQL语句
        /// <summary>
        [Column("dynamic_sql")]
        public string DynamicSql
        {
            get { return _dynamic_sql; }
            set { _dynamic_sql = value; OnPropertyChanged("dynamic_sql"); }
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
        /// 备注 备注
        /// <summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        /// 创建时间 开始时间
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
    [Table("feedback")]
    public partial class Feedback : BaseEntity
    {
        private int _id; 
        private int _user_id; 
        private sbyte _feedback_type; 
        private string _content; 
        private string _ref_pic_urls; 
        private string _link_way; 
        private string _deal_remark; 
        private string _deal_admin_id; 
        private string _reply_message; 
        private sbyte _status; 
        private DateTime _create_time; 
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
        /// 用户ID 用户ID
        /// <summary>
        [Column("user_id")]
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 反馈类型 反馈类型 1= 详见数据字典 反馈类型
        /// <summary>
        [Column("feedback_type")]
        public sbyte FeedbackType
        {
            get { return _feedback_type; }
            set { _feedback_type = value; OnPropertyChanged("feedback_type"); }
        }
        /// <summary>
        /// 反馈内容
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 相关图片
        /// <summary>
        [Column("ref_pic_urls")]
        public string RefPicUrls
        {
            get { return _ref_pic_urls; }
            set { _ref_pic_urls = value; OnPropertyChanged("ref_pic_urls"); }
        }
        /// <summary>
        /// 回访联系方式
        /// <summary>
        [Column("link_way")]
        public string LinkWay
        {
            get { return _link_way; }
            set { _link_way = value; OnPropertyChanged("link_way"); }
        }
        /// <summary>
        /// 处理备注
        /// <summary>
        [Column("deal_remark")]
        public string DealRemark
        {
            get { return _deal_remark; }
            set { _deal_remark = value; OnPropertyChanged("deal_remark"); }
        }
        /// <summary>
        /// 处理管理员ID
        /// <summary>
        [Column("deal_admin_id")]
        public string DealAdminId
        {
            get { return _deal_admin_id; }
            set { _deal_admin_id = value; OnPropertyChanged("deal_admin_id"); }
        }
        /// <summary>
        /// 回复文本
        /// <summary>
        [Column("reply_message")]
        public string ReplyMessage
        {
            get { return _reply_message; }
            set { _reply_message = value; OnPropertyChanged("reply_message"); }
        }
        /// <summary>
        /// 状态 状态 0 =新提交 1=已查看 =2 已受理 3=已反馈 9=无效反馈
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 创建时间 创建时间 创建时间-按创建时间分区
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
    [Table("ilgwords")]
    public partial class Ilgwords : BaseEntity
    {
        private int _id; 
        private string _word; 
        private DateTime _create_time; 

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
        /// 敏感词
        /// <summary>
        [Column("word")]
        public string Word
        {
            get { return _word; }
            set { _word = value; OnPropertyChanged("word"); }
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
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("rate_limit_cfg")]
    public partial class RateLimitCfg : BaseEntity
    {
        private int _id; 
        private string _app_code; 
        private sbyte _limit_type; 
        private int _limit_period; 
        private int _limit_times; 
        private sbyte _status; 
        private string _request_path; 
        private string _remark; 
        private int _sequence; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 编号 编号
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
        /// 应用编码 应用编码
        /// <summary>
        [Column("app_code")]
        public string AppCode
        {
            get { return _app_code; }
            set { _app_code = value; OnPropertyChanged("app_code"); }
        }
        /// <summary>
        /// 限制类型 限制类型1 = 根据IP限制 2= 根据设备标识  3= 根据用户标识
        /// <summary>
        [Column("limit_type")]
        public sbyte LimitType
        {
            get { return _limit_type; }
            set { _limit_type = value; OnPropertyChanged("limit_type"); }
        }
        /// <summary>
        /// 计次周期 计次周期 单位为秒
        /// <summary>
        [Column("limit_period")]
        public int LimitPeriod
        {
            get { return _limit_period; }
            set { _limit_period = value; OnPropertyChanged("limit_period"); }
        }
        /// <summary>
        /// 最大请求数 计次周期内最大请求数
        /// <summary>
        [Column("limit_times")]
        public int LimitTimes
        {
            get { return _limit_times; }
            set { _limit_times = value; OnPropertyChanged("limit_times"); }
        }
        /// <summary>
        /// 状态 状态 1= 有效 0=无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 请求地址 请求地址 支持正则匹配
        /// <summary>
        [Column("request_path")]
        public string RequestPath
        {
            get { return _request_path; }
            set { _request_path = value; OnPropertyChanged("request_path"); }
        }
        /// <summary>
        /// 备注 备注
        /// <summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        /// 排序号 排序号，路径只匹配一次，越小越容易被匹配
        /// <summary>
        [Column("sequence")]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
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
    [Table("scenario_background_cfg")]
    public partial class ScenarioBackgroundCfg : BaseEntity
    {
        private int _id; 
        private string _pic_url; 
        private int _ref_level; 
        private DateTime _start_time; 
        private DateTime _end_time; 
        private sbyte _status; 
        private DateTime _create_time; 
        private DateTime _update_time; 

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
        /// 图片地址 非JSON格式
        /// <summary>
        [Column("pic_url")]
        public string PicUrl
        {
            get { return _pic_url; }
            set { _pic_url = value; OnPropertyChanged("pic_url"); }
        }
        /// <summary>
        /// 关联等级 关联等级0 = 所有等级 1=等级1 2=等级2 3=等级3 4=等级4
        /// <summary>
        [Column("ref_level")]
        public int RefLevel
        {
            get { return _ref_level; }
            set { _ref_level = value; OnPropertyChanged("ref_level"); }
        }
        /// <summary>
        /// 生效开始时间
        /// <summary>
        [Column("start_time")]
        public DateTime StartTime
        {
            get { return _start_time; }
            set { _start_time = value; OnPropertyChanged("start_time"); }
        }
        /// <summary>
        /// 生效开始时间
        /// <summary>
        [Column("end_time")]
        public DateTime EndTime
        {
            get { return _end_time; }
            set { _end_time = value; OnPropertyChanged("end_time"); }
        }
        /// <summary>
        /// 状态
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
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
    [Table("scenario_tip_cfg")]
    public partial class ScenarioTipCfg : BaseEntity
    {
        private int _id; 
        private string _animation_position; 
        private string _animation_level1_url; 
        private string _animation_level2_url; 
        private string _animation_level3_url; 
        private string _animation_level4_url; 
        private string _tip; 
        private string _redirect_url; 
        private sbyte _default_flag; 
        private DateTime _start_time; 
        private DateTime _end_time; 
        private sbyte _status; 
        private DateTime _create_time; 
        private DateTime _update_time; 

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
        /// 动画位置
        /// <summary>
        [Column("animation_position")]
        public string AnimationPosition
        {
            get { return _animation_position; }
            set { _animation_position = value; OnPropertyChanged("animation_position"); }
        }
        /// <summary>
        /// 动画地址1
        /// <summary>
        [Column("animation_level1_url")]
        public string AnimationLevel1Url
        {
            get { return _animation_level1_url; }
            set { _animation_level1_url = value; OnPropertyChanged("animation_level1_url"); }
        }
        /// <summary>
        /// 动画地址2
        /// <summary>
        [Column("animation_level2_url")]
        public string AnimationLevel2Url
        {
            get { return _animation_level2_url; }
            set { _animation_level2_url = value; OnPropertyChanged("animation_level2_url"); }
        }
        /// <summary>
        /// 动画地址3
        /// <summary>
        [Column("animation_level3_url")]
        public string AnimationLevel3Url
        {
            get { return _animation_level3_url; }
            set { _animation_level3_url = value; OnPropertyChanged("animation_level3_url"); }
        }
        /// <summary>
        /// 动画地址4
        /// <summary>
        [Column("animation_level4_url")]
        public string AnimationLevel4Url
        {
            get { return _animation_level4_url; }
            set { _animation_level4_url = value; OnPropertyChanged("animation_level4_url"); }
        }
        /// <summary>
        /// 提示信息
        /// <summary>
        [Column("tip")]
        public string Tip
        {
            get { return _tip; }
            set { _tip = value; OnPropertyChanged("tip"); }
        }
        /// <summary>
        /// 跳转的H5地址
        /// <summary>
        [Column("redirect_url")]
        public string RedirectUrl
        {
            get { return _redirect_url; }
            set { _redirect_url = value; OnPropertyChanged("redirect_url"); }
        }
        /// <summary>
        /// 是否默认 是否默认
        /// <summary>
        [Column("default_flag")]
        public sbyte DefaultFlag
        {
            get { return _default_flag; }
            set { _default_flag = value; OnPropertyChanged("default_flag"); }
        }
        /// <summary>
        /// 生效开始时间
        /// <summary>
        [Column("start_time")]
        public DateTime StartTime
        {
            get { return _start_time; }
            set { _start_time = value; OnPropertyChanged("start_time"); }
        }
        /// <summary>
        /// 生效开始时间
        /// <summary>
        [Column("end_time")]
        public DateTime EndTime
        {
            get { return _end_time; }
            set { _end_time = value; OnPropertyChanged("end_time"); }
        }
        /// <summary>
        /// 状态
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
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
    [Table("sys_message")]
    public partial class SysMessage : BaseEntity
    {
        private int _id; 
        private string _admin_user_id; 
        private string _title; 
        private string _user_ids; 
        private sbyte _send_type; 
        private int _read_count; 
        private sbyte _status; 
        private DateTime? _start_time; 
        private DateTime? _end_time; 
        private DateTime _create_time; 

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
        /// 发布人的ID
        /// <summary>
        [Column("admin_user_id")]
        public string AdminUserId
        {
            get { return _admin_user_id; }
            set { _admin_user_id = value; OnPropertyChanged("admin_user_id"); }
        }
        /// <summary>
        /// 文本
        /// <summary>
        [Column("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 用户消息
        /// <summary>
        [Column("user_ids")]
        public string UserIds
        {
            get { return _user_ids; }
            set { _user_ids = value; OnPropertyChanged("user_ids"); }
        }
        /// <summary>
        /// 发送类型 1=广播 2=单播
        /// <summary>
        [Column("send_type")]
        public sbyte SendType
        {
            get { return _send_type; }
            set { _send_type = value; OnPropertyChanged("send_type"); }
        }
        /// <summary>
        /// 阅读数
        /// <summary>
        [Column("read_count")]
        public int ReadCount
        {
            get { return _read_count; }
            set { _read_count = value; OnPropertyChanged("read_count"); }
        }
        /// <summary>
        /// 状态 状态1= 有效 0=无效
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 开始时间
        /// <summary>
        [Column("start_time")]
        public DateTime? StartTime
        {
            get { return _start_time; }
            set { _start_time = value; OnPropertyChanged("start_time"); }
        }
        /// <summary>
        /// 结束时间
        /// <summary>
        [Column("end_time")]
        public DateTime? EndTime
        {
            get { return _end_time; }
            set { _end_time = value; OnPropertyChanged("end_time"); }
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
    [Table("sys_message_app_push")]
    public partial class SysMessageAppPush : BaseEntity
    {
        private int _id; 
        private string _title; 
        private string _content; 
        private sbyte _redirect_type; 
        private string _redirect_url; 
        private sbyte _push_type; 
        private sbyte _platform_type; 
        private DateTime? _publish_time; 
        private string _tags; 
        private string _ref_id; 
        private sbyte _status; 
        private string _publish_user_id; 
        private DateTime _create_time; 
        private DateTime _update_time; 

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
        /// 标题
        /// <summary>
        [Column("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 内容
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 条状类型 0 = 无跳转 1=Html地址跳转 2=App内跳转
        /// <summary>
        [Column("redirect_type")]
        public sbyte RedirectType
        {
            get { return _redirect_type; }
            set { _redirect_type = value; OnPropertyChanged("redirect_type"); }
        }
        /// <summary>
        /// 条状类型 跳转信息
        /// <summary>
        [Column("redirect_url")]
        public string RedirectUrl
        {
            get { return _redirect_url; }
            set { _redirect_url = value; OnPropertyChanged("redirect_url"); }
        }
        /// <summary>
        /// 推送方式 0 =广播 1=按tag推送 2=按别名推送 3=按设备ID推送
        /// <summary>
        [Column("push_type")]
        public sbyte PushType
        {
            get { return _push_type; }
            set { _push_type = value; OnPropertyChanged("push_type"); }
        }
        /// <summary>
        /// 推送平台 1=IOS 2=安卓
        /// <summary>
        [Column("platform_type")]
        public sbyte PlatformType
        {
            get { return _platform_type; }
            set { _platform_type = value; OnPropertyChanged("platform_type"); }
        }
        /// <summary>
        /// 发布时间
        /// <summary>
        [Column("publish_time")]
        public DateTime? PublishTime
        {
            get { return _publish_time; }
            set { _publish_time = value; OnPropertyChanged("publish_time"); }
        }
        /// <summary>
        /// 用户标签 多个按逗号分隔
        /// <summary>
        [Column("tags")]
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; OnPropertyChanged("tags"); }
        }
        /// <summary>
        /// 外部关联ID GPushId
        /// <summary>
        [Column("ref_id")]
        public string RefId
        {
            get { return _ref_id; }
            set { _ref_id = value; OnPropertyChanged("ref_id"); }
        }
        /// <summary>
        /// 状态 0=无效 1=有效 2=定时发布 9=已取消
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 发布人ID
        /// <summary>
        [Column("publish_user_id")]
        public string PublishUserId
        {
            get { return _publish_user_id; }
            set { _publish_user_id = value; OnPropertyChanged("publish_user_id"); }
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
    [Table("task_cfg")]
    public partial class TaskCfg : BaseEntity
    {
        private int _task_id; 
        private string _task_name; 
        private string _task_desc; 
        private sbyte _task_type; 
        private DateTime? _start_time; 
        private DateTime? _end_time; 
        private int _up_value; 
        private sbyte _up_type; 
        private string _resource; 
        private DateTime _create_time; 
        private DateTime _update_time; 
        private string _update_user_id; 

        /// <summary>
        /// 任务编号 任务编号
        /// <summary>
        [Column("task_id")]
        [PrimaryKey]
        public int TaskId
        {
            get { return _task_id; }
            set { _task_id = value; OnPropertyChanged("task_id"); }
        }
        /// <summary>
        /// 任务名称 任务名称
        /// <summary>
        [Column("task_name")]
        public string TaskName
        {
            get { return _task_name; }
            set { _task_name = value; OnPropertyChanged("task_name"); }
        }
        /// <summary>
        /// 任务说明 任务说明
        /// <summary>
        [Column("task_desc")]
        public string TaskDesc
        {
            get { return _task_desc; }
            set { _task_desc = value; OnPropertyChanged("task_desc"); }
        }
        /// <summary>
        /// 任务类型 1 = 新手任务 2= 每日任务 3=活动任务
        /// <summary>
        [Column("task_type")]
        public sbyte TaskType
        {
            get { return _task_type; }
            set { _task_type = value; OnPropertyChanged("task_type"); }
        }
        /// <summary>
        /// 开始时间
        /// <summary>
        [Column("start_time")]
        public DateTime? StartTime
        {
            get { return _start_time; }
            set { _start_time = value; OnPropertyChanged("start_time"); }
        }
        /// <summary>
        /// 结束时间
        /// <summary>
        [Column("end_time")]
        public DateTime? EndTime
        {
            get { return _end_time; }
            set { _end_time = value; OnPropertyChanged("end_time"); }
        }
        /// <summary>
        /// 增加的经验值 增加的经验值
        /// <summary>
        [Column("up_value")]
        public int UpValue
        {
            get { return _up_value; }
            set { _up_value = value; OnPropertyChanged("up_value"); }
        }
        /// <summary>
        /// 经验值类型 经验值类型1 =买家  2=卖家
        /// <summary>
        [Column("up_type")]
        public sbyte UpType
        {
            get { return _up_type; }
            set { _up_type = value; OnPropertyChanged("up_type"); }
        }
        /// <summary>
        /// 资源 资源
        /// <summary>
        [Column("resource")]
        public string Resource
        {
            get { return _resource; }
            set { _resource = value; OnPropertyChanged("resource"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
        /// <summary>
        /// 最后一次操作人ID 最后一次操作人ID
        /// <summary>
        [Column("update_user_id")]
        public string UpdateUserId
        {
            get { return _update_user_id; }
            set { _update_user_id = value; OnPropertyChanged("update_user_id"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("user_switch_cfg")]
    public partial class UserSwitchCfg : BaseEntity
    {
        private int _user_id; 
        private int _user_rc_a; 
        private int _user_rc_b; 
        private sbyte _user_rc_x; 
        private int? _system_rc_a; 
        private int _system_rc_b; 
        private sbyte? _system_rc_x; 
        private string _remark; 
        private DateTime _create_time; 
        private DateTime _update_time; 

        /// <summary>
        /// 用户标识 用户标识
        /// <summary>
        [Column("user_id")]
        [PrimaryKey]
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 用户风控消费策略 用户风控策略111 = 禁止提现|禁止下单|禁止被下单
        /// <summary>
        [Column("user_rc_a")]
        public int UserRcA
        {
            get { return _user_rc_a; }
            set { _user_rc_a = value; OnPropertyChanged("user_rc_a"); }
        }
        /// <summary>
        /// 系统风控业务策略 1 = 禁止评价
        /// <summary>
        [Column("user_rc_b")]
        public int UserRcB
        {
            get { return _user_rc_b; }
            set { _user_rc_b = value; OnPropertyChanged("user_rc_b"); }
        }
        /// <summary>
        /// 用户风控总开关 1 = 禁止一切操作 0 = 不限制登录 转入 消费 提现
        /// <summary>
        [Column("user_rc_x")]
        public sbyte UserRcX
        {
            get { return _user_rc_x; }
            set { _user_rc_x = value; OnPropertyChanged("user_rc_x"); }
        }
        /// <summary>
        /// 系统风控消费策略
        /// <summary>
        [Column("system_rc_a")]
        public int? SystemRcA
        {
            get { return _system_rc_a; }
            set { _system_rc_a = value; OnPropertyChanged("system_rc_a"); }
        }
        /// <summary>
        /// 系统风控业务策略 1 = 禁止评价
        /// <summary>
        [Column("system_rc_b")]
        public int SystemRcB
        {
            get { return _system_rc_b; }
            set { _system_rc_b = value; OnPropertyChanged("system_rc_b"); }
        }
        /// <summary>
        /// 系统风控策略总开关
        /// <summary>
        [Column("system_rc_x")]
        public sbyte? SystemRcX
        {
            get { return _system_rc_x; }
            set { _system_rc_x = value; OnPropertyChanged("system_rc_x"); }
        }
        /// <summary>
        /// 备注 上一次操作的原因
        /// <summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        /// 开始时间 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间 更新时间
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

}
