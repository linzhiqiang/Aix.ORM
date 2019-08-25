/*
该文件为自动生成，不要修改。
生成时间：2019-08-25 19:14:16。
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
    [Table("UserInfo")]
    public partial class UserInfo : BaseEntity
    {
        private int _userId; 
        private string _userName; 
        private int? _status; 
        private DateTime _createTime; 
        private DateTime _updateTime; 

        /// <summary>
        /// 
        /// <summary>
        [Column("UserId")]
        [PrimaryKey]
        [Identity]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged("UserId"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("UserName")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }
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
