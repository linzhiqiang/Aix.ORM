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
    /// 用户表
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
        /// 主键  int(11)
        /// <summary>
        [Column("user_id",IsNullable=false)]
        [PrimaryKey]
        [Identity]
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 用户名称  varchar(255)
        /// <summary>
        [Column("user_name",IsNullable=false)]
        public string UserName
        {
            get { return _user_name; }
            set { _user_name = value; OnPropertyChanged("user_name"); }
        }
        /// <summary>
        /// 状态 true=有效 false=无效  bit(1)
        /// <summary>
        [Column("status",IsNullable=false)]
        public bool Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 类型 1=a , 2=b  tinyint(255)
        /// <summary>
        [Column("type",IsNullable=false)]
        public sbyte Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("type"); }
        }
        /// <summary>
        /// 创建时间  datetime
        /// <summary>
        [Column("create_time",IsNullable=false)]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 修改时间  datetime
        /// <summary>
        [Column("update_time",IsNullable=false)]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

}