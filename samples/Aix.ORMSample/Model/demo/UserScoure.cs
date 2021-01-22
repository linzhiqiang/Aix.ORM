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
    /// 
    /// <summary>
    [Table("user_scoure")]
    public partial class UserScoure : BaseEntity
    {
        private int _id; 
        private int _user_id; 
        private string _course_name; 
        private int _score; 

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
        [Column("user_id",IsNullable=false)]
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        ///   varchar(50)
        /// <summary>
        [Column("course_name",IsNullable=false)]
        public string CourseName
        {
            get { return _course_name; }
            set { _course_name = value; OnPropertyChanged("course_name"); }
        }
        /// <summary>
        ///   int(11)
        /// <summary>
        [Column("score",IsNullable=false,DefaultValue="0")]
        public int Score
        {
            get { return _score; }
            set { _score = value; OnPropertyChanged("score"); }
        }
    }

}