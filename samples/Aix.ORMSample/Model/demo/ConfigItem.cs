/*
该文件为自动生成，不要修改。
生成时间：2020-06-05 10:06:13。
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
        ///   int(11)
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
        ///   int(11)
        /// <summary>
        [Column("group_id",IsNullable=false)]
        public int GroupId
        {
            get { return _group_id; }
            set { _group_id = value; OnPropertyChanged("group_id"); }
        }
        /// <summary>
        ///   varchar(255)
        /// <summary>
        [Column("key",IsNullable=false)]
        public string Key
        {
            get { return _key; }
            set { _key = value; OnPropertyChanged("key"); }
        }
        /// <summary>
        ///   varchar(5000)
        /// <summary>
        [Column("value",IsNullable=true)]
        public string Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged("value"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("status",IsNullable=false)]
        public int Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        ///   varchar(500)
        /// <summary>
        [Column("remark",IsNullable=true)]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged("remark"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("sequence",IsNullable=false)]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        ///   varchar(50)
        /// <summary>
        [Column("create_user",IsNullable=false)]
        public string CreateUser
        {
            get { return _create_user; }
            set { _create_user = value; OnPropertyChanged("create_user"); }
        }
        /// <summary>
        ///   datetime
        /// <summary>
        [Column("create_time",IsNullable=false)]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        ///   varchar(50)
        /// <summary>
        [Column("update_user",IsNullable=false)]
        public string UpdateUser
        {
            get { return _update_user; }
            set { _update_user = value; OnPropertyChanged("update_user"); }
        }
        /// <summary>
        ///   datetime
        /// <summary>
        [Column("update_time",IsNullable=false)]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

}