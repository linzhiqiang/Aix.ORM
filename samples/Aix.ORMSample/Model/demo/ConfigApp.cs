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

}