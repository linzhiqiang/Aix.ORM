/*
该文件为自动生成，不要修改。
生成时间：2019-09-10 14:09:24。
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
    [Table("temp_import_data")]
    public partial class TempImportData : BaseEntity
    {
        private int _relic_id;
        private int _product_id;

        /// <summary>
        /// 
        /// <summary>
        [Column("relic_id")]
        [PrimaryKey]
        public int RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public int ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }
    /// <summary>
    /// 
    /// <summary>
    [Table("temp_import")]
    public partial class TempImport : BaseEntity
    {
        private int _id;
        private string _relic_id;
        private string _relic_name;
        private string _product_id;

        /// <summary>
        /// 
        /// <summary>
        [Column("id")]
        [PrimaryKey]
        [Identity]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("relic_id")]
        public string RelicId
        {
            get { return _relic_id; }
            set { _relic_id = value; OnPropertyChanged("relic_id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("relic_name")]
        public string RelicName
        {
            get { return _relic_name; }
            set { _relic_name = value; OnPropertyChanged("relic_name"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("product_id")]
        public string ProductId
        {
            get { return _product_id; }
            set { _product_id = value; OnPropertyChanged("product_id"); }
        }
    }


    /// <summary>
    /// 
    /// <summary>
    [Table("Table_1")]
    public partial class Table1 : BaseEntity
    {
        private int _id;
        private short _test;

        /// <summary>
        /// 
        /// <summary>
        [Column("Id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("Test")]
        public short Test
        {
            get { return _test; }
            set { _test = value; OnPropertyChanged("Test"); }
        }
    }

    /// <summary>
    /// 
    /// <summary>
    [Table("user_info")]
    public partial class UserInfo : BaseEntity
    {
        private int _user_id;
        private string _user_name;
        private bool _status;
        private byte _type;
        private DateTime _create_time;
        private DateTime _update_time;

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
        [Column("status")]
        public bool Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("status"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("type")]
        public byte Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("type"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("create_time")]
        public DateTime CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; OnPropertyChanged("create_time"); }
        }
        /// <summary>
        /// 
        /// <summary>
        [Column("update_time")]
        public DateTime UpdateTime
        {
            get { return _update_time; }
            set { _update_time = value; OnPropertyChanged("update_time"); }
        }
    }

}
