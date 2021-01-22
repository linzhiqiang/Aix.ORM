/*
该文件为自动生成，不要修改。
生成时间：2021-01-19 09:30:03。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aix.ORM;

namespace Aix.ORMSample.Entity
{
    /// <summary>
    /// 分布式锁
    /// <summary>
    [Table("aix_distribution_lock")]
    public partial class AixDistributionLock : BaseEntity
    {
        private string _lock_name; 

        /// <summary>
        /// 主键  varchar(50)
        /// <summary>
        [Column("lock_name",IsNullable=false)]
        [PrimaryKey]
        public string LockName
        {
            get { return _lock_name; }
            set { _lock_name = value; OnPropertyChanged("lock_name"); }
        }
    }

}