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
    /// 定时任务
    /// <summary>
    [Table("aix_schedule_task_info")]
    public partial class AixScheduleTaskInfo : BaseEntity
    {
        private int _id; 
        private string _task_group; 
        private sbyte _status; 
        private string _task_name; 
        private string _task_desc; 
        private string _cron; 
        private string _task_content; 
        private long _last_execute_time; 
        private long _next_execute_time; 
        private int _max_retry_count; 
        private string _creator_id; 
        private DateTime _create_time; 
        private string _modifier_id; 
        private DateTime _modify_time; 

        /// <summary>
        /// 主键  int(11)
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
        /// 所属组 根据需要进行扩展  varchar(50)
        /// <summary>
        [Column("task_group",IsNullable=true)]
        public string TaskGroup
        {
            get { return _task_group; }
            set { _task_group = value; OnPropertyChanged("task_group"); }
        }
        /// <summary>
        /// 状态 0=禁用 1=启动  tinyint(4)
        /// <summary>
        [Column("status",IsNullable=false,DefaultValue="0")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 任务名称  varchar(50)
        /// <summary>
        [Column("task_name",IsNullable=false)]
        public string TaskName
        {
            get { return _task_name; }
            set { _task_name = value; OnPropertyChanged("task_name"); }
        }
        /// <summary>
        /// 任务描述  varchar(200)
        /// <summary>
        [Column("task_desc",IsNullable=true)]
        public string TaskDesc
        {
            get { return _task_desc; }
            set { _task_desc = value; OnPropertyChanged("task_desc"); }
        }
        /// <summary>
        /// 定时表达式  varchar(50)
        /// <summary>
        [Column("cron",IsNullable=false)]
        public string Cron
        {
            get { return _cron; }
            set { _cron = value; OnPropertyChanged("cron"); }
        }
        /// <summary>
        /// 执行参数  varchar(500)
        /// <summary>
        [Column("task_content",IsNullable=true)]
        public string TaskContent
        {
            get { return _task_content; }
            set { _task_content = value; OnPropertyChanged("task_content"); }
        }
        /// <summary>
        /// 上次执行时间  bigint(20)
        /// <summary>
        [Column("last_execute_time",IsNullable=false,DefaultValue="0")]
        public long LastExecuteTime
        {
            get { return _last_execute_time; }
            set { _last_execute_time = value; OnPropertyChanged("last_execute_time"); }
        }
        /// <summary>
        /// 下次执行时间  bigint(20)
        /// <summary>
        [Column("next_execute_time",IsNullable=false,DefaultValue="0")]
        public long NextExecuteTime
        {
            get { return _next_execute_time; }
            set { _next_execute_time = value; OnPropertyChanged("next_execute_time"); }
        }
        /// <summary>
        /// 最大重试次数 0=不重试  int(11)
        /// <summary>
        [Column("max_retry_count",IsNullable=false,DefaultValue="0")]
        public int MaxRetryCount
        {
            get { return _max_retry_count; }
            set { _max_retry_count = value; OnPropertyChanged("max_retry_count"); }
        }
        /// <summary>
        /// 创建人编号  varchar(50)
        /// <summary>
        [Column("creator_id",IsNullable=false)]
        public string CreatorId
        {
            get { return _creator_id; }
            set { _creator_id = value; OnPropertyChanged("creator_id"); }
        }
        /// <summary>
        /// 创建日期  datetime
        /// <summary>
        [Column("create_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 修改人编号  varchar(50)
        /// <summary>
        [Column("modifier_id",IsNullable=false)]
        public string ModifierId
        {
            get { return _modifier_id; }
            set { _modifier_id = value; OnPropertyChanged("modifier_id"); }
        }
        /// <summary>
        /// 修改日期  datetime
        /// <summary>
        [Column("modify_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime ModifyTime
        {
            get { return _modify_time; }
            set { _modify_time = value; OnPropertyChanged("modify_time"); }
        }
    }

}