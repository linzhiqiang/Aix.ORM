﻿/*
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
    [Table("user_opus")]
    public partial class UserOpus : BaseEntity
    {
        private long _opus_id; 
        private long _user_id; 
        private string _title; 
        private int _category; 
        private string _with_topic; 
        private string _content; 
        private string _cover_url; 
        private string _voice_url; 
        private string _audition_url; 
        private sbyte _recommend_type; 
        private sbyte _hot_type; 
        private sbyte _status; 
        private sbyte _pay_type; 
        private DateTime _create_time; 
        private DateTime? _update_time; 
        private sbyte? _isread; 
        private int _duration; 
        private int _isload; 

        /// <summary>
        /// 编号 编号 全局自增ID
        /// <summary>
        [Column("opus_id")]
        [PrimaryKey]
        public long OpusId
        {
            get { return _opus_id; }
            set { _opus_id = value; OnPropertyChanged("opus_id"); }
        }
        /// <summary>
        /// 用户ID 所属应用ID
        /// <summary>
        [Column("user_id")]
        public long UserId
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged("user_id"); }
        }
        /// <summary>
        /// 标题 标题
        /// <summary>
        [Column("title")]
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        /// <summary>
        /// 分类 分类 1 大胆说爱 2 元气闹钟 3 失意诊所 4 入眠胶囊
        /// <summary>
        [Column("category")]
        public int Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged("category"); }
        }
        /// <summary>
        /// 话题
        /// <summary>
        [Column("with_topic")]
        public string WithTopic
        {
            get { return _with_topic; }
            set { _with_topic = value; OnPropertyChanged("with_topic"); }
        }
        /// <summary>
        /// 简介 简介
        /// <summary>
        [Column("content")]
        public string Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged("content"); }
        }
        /// <summary>
        /// 封面图_URL
        /// <summary>
        [Column("cover_url")]
        public string CoverUrl
        {
            get { return _cover_url; }
            set { _cover_url = value; OnPropertyChanged("cover_url"); }
        }
        /// <summary>
        /// 语音地址
        /// <summary>
        [Column("voice_url")]
        public string VoiceUrl
        {
            get { return _voice_url; }
            set { _voice_url = value; OnPropertyChanged("voice_url"); }
        }
        /// <summary>
        /// 试听的地址
        /// <summary>
        [Column("audition_url")]
        public string AuditionUrl
        {
            get { return _audition_url; }
            set { _audition_url = value; OnPropertyChanged("audition_url"); }
        }
        /// <summary>
        /// 推荐类型 推荐类型 1= 已推荐 0=未推荐
        /// <summary>
        [Column("recommend_type")]
        public sbyte RecommendType
        {
            get { return _recommend_type; }
            set { _recommend_type = value; OnPropertyChanged("recommend_type"); }
        }
        /// <summary>
        /// 是否热推 0=否 1=是
        /// <summary>
        [Column("hot_type")]
        public sbyte HotType
        {
            get { return _hot_type; }
            set { _hot_type = value; OnPropertyChanged("hot_type"); }
        }
        /// <summary>
        /// 可见状态 可见状态 0= 待审核 1=审核通过  2= 审核不通过
        /// <summary>
        [Column("status")]
        public sbyte Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 付费类型 付费类型 1=免费 2=道具收费 将来扩展
        /// <summary>
        [Column("pay_type")]
        public sbyte PayType
        {
            get { return _pay_type; }
            set { _pay_type = value; OnPropertyChanged("pay_type"); }
        }
        /// <summary>
        /// 开始时间
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 更新时间
        /// <summary>
        [Column("update_time")]
        public DateTime? UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
        /// <summary>
        /// 0=未阅读 1=已阅读
        /// <summary>
        [Column("isread")]
        public sbyte? Isread
        {
            get { return _isread; }
            set { _isread = value; OnPropertyChanged("isread"); }
        }
        /// <summary>
        /// 声品时长
        /// <summary>
        [Column("duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged("duration"); }
        }
        /// <summary>
        /// 是否下载音频文件
        /// <summary>
        [Column("isload")]
        public int Isload
        {
            get { return _isload; }
            set { _isload = value; OnPropertyChanged("isload"); }
        }
    }

}