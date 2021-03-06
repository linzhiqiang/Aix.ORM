﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.EntityGenerator.Entity
{
    public class TableInfo
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表注释
        /// </summary>
        public string TableComment { get; set; }

        private List<ColumnInfo> _columns;
        public List<ColumnInfo> Columns
        {
            get
            {
                if (_columns == null)
                    _columns = new List<ColumnInfo>();
                return _columns;
            }
            set { _columns = value; }
        }

        private List<PrimaryKey> _primaryKeys;
        public List<PrimaryKey> PrimaryKeys
        {
            get
            {
                if (_primaryKeys == null)
                    _primaryKeys = new List<PrimaryKey>();
                return _primaryKeys;
            }
            set { _primaryKeys = value; }
        }
    }
}
