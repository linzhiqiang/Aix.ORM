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
        ///   int(11)
        /// <summary>
        [Column("group_id",IsNullable=false)]
        [PrimaryKey]
        [Identity]
        public int GroupId
        {
            get { return _group_id; }
            set { _group_id = value; OnPropertyChanged("group_id"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("app_id",IsNullable=true)]
        public int? AppId
        {
            get { return _app_id; }
            set { _app_id = value; OnPropertyChanged("app_id"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("parent_id",IsNullable=true)]
        public int? ParentId
        {
            get { return _parent_id; }
            set { _parent_id = value; OnPropertyChanged("parent_id"); }
        }
        /// <summary>
        ///   varchar(50)
        /// <summary>
        [Column("group_code",IsNullable=false)]
        public string GroupCode
        {
            get { return _group_code; }
            set { _group_code = value; OnPropertyChanged("group_code"); }
        }
        /// <summary>
        ///   varchar(50)
        /// <summary>
        [Column("group_name",IsNullable=false)]
        public string GroupName
        {
            get { return _group_name; }
            set { _group_name = value; OnPropertyChanged("group_name"); }
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