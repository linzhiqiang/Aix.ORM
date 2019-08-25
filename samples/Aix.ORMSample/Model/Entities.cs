/*
该文件为自动生成，不要修改。
生成时间：2019-08-25 21:17:53。
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
    [Table("user_info")]
    public partial class UserInfo : BaseEntity
    {
        private int _user_id; 
        private string _user_name; 
        private int? _status; 
        private DateTime _createTime; 
        private DateTime _updateTime; 

        /// <summary>
        /// 
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
        /// 
        /// <summary>
        [Column("user_name")]
        public string UserName
        {
            get { return _user_name; }
            set { _user_name = value; OnPropertyChanged("user_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("Status")]
        public int? Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("CreateTime")]
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; OnPropertyChanged("CreateTime"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("UpdateTime")]
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; OnPropertyChanged("UpdateTime"); }
        }
    }

}
