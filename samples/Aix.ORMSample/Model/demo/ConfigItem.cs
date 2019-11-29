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

}