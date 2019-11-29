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

}