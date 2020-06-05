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
    /// 藏品标签表
    /// <summary>
    [Table("relic_tag")]
    public partial class RelicTag : BaseEntity
    {
        private int _id; 
        private int _relic_id; 
        private sbyte _tag_type; 
        private string _content; 
        private int _sequence; 
        private DateTime _create_time; 

        /// <summary>
        /// 主键标识 主键标识   int(11)
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
        /// 藏品id 藏品id  int(11)
        /// <summary>
        [Column("relic_id",IsNullable=false)]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 标签类型 标签类型 1=年代 2=功用 3=来源 4=类别 5=价值6=自定义标签  tinyint(4)
        /// <summary>
        [Column("tag_type",IsNullable=false)]
        public sbyte TagType
        {
            get { return _tag_type; }
            set { _tag_type = value; OnPropertyChanged("tag_type"); }
        }
        /// <summary>
        /// 标签内容 标签内容  varchar(50)
        /// <summary>
        [Column("content",IsNullable=false)]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 序号 序号 正序  int(11)
        /// <summary>
        [Column("sequence",IsNullable=false)]
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; OnPropertyChanged("sequence"); }
        }
        /// <summary>
        /// 创建时间 创建时间  datetime
        /// <summary>
        [Column("create_time",IsNullable=false,DefaultValue="CURRENT_TIMESTAMP")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
    }

}