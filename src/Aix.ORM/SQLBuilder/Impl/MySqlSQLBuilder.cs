﻿using Aix.ORM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public class MySqlSQLBuilder : ISQLBuilder
    {
        public string BuildReplaceInsertSQL(EntityMeta meta)
        {
            if (meta.Columns == null || meta.Columns.Count == 0)
                return string.Empty;

            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("REPLACE INTO `{0}` (", meta.TableName);
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity)
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("`" + meta.Columns[i].ColumnName + "`");
                j++;
            }
            sqlbuilder.Append(") VALUES (");
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity)
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("@" + meta.Columns[i].PropertyName + "");
                j++;
            }
            sqlbuilder.Append(");");

            return sqlbuilder.ToString();
        }

        public string BuildInsertSql(EntityMeta meta)
        {
            if (meta.Columns == null || meta.Columns.Count == 0)
                return string.Empty;

            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("INSERT INTO `{0}` (", meta.TableName);
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity)
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("`" + meta.Columns[i].ColumnName + "`");
                j++;
            }
            sqlbuilder.Append(") VALUES (");
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity)
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("@" + meta.Columns[i].PropertyName + "");
                j++;
            }
            sqlbuilder.Append(");");

            if (meta.Columns.Exists(x => x.Identity && x.PrimaryKey))
            {
                sqlbuilder.Append("SELECT CAST(LAST_INSERT_ID() AS SIGNED);");
            }
            else
            {
                sqlbuilder.Append(" SELECT CAST(0 AS SIGNED);");
            }

            return sqlbuilder.ToString();
        }

        public string BuildUpdateSql(EntityMeta meta)
        {
            if (meta.Columns == null || meta.Columns.Count == 0)
                return string.Empty;

            var keys = meta.Columns.FindAll(_ => _.PrimaryKey);
            AssertUtils.IsTrue(keys.Count > 0, $"表{meta.TableName} 不存在主键");
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("UPDATE `{0}` SET ", meta.TableName);

            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (!meta.Columns[i].PrimaryKey)
                {
                    if (j > 0)
                    {
                        sqlbuilder.Append(",");
                    }
                    j++;
                    sqlbuilder.Append("`" + meta.Columns[i].ColumnName + "`=@" + meta.Columns[i].PropertyName + "");
                }
            }
            sqlbuilder.Append(" WHERE ");
            for (int i = 0; i < keys.Count; i++)
            {
                if (i > 0)
                {
                    sqlbuilder.Append(" AND ");
                }
                sqlbuilder.Append("`" + keys[i].ColumnName + "`=@" + keys[i].PropertyName);
            }

            return sqlbuilder.ToString();
        }

        public string BuildInsertSql(EntityMeta meta, List<string> list)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("INSERT INTO `{0}` (", meta.TableName);
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity || !list.Contains(meta.Columns[i].ColumnName))
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("`" + meta.Columns[i].ColumnName + "`");
                j++;
            }
            sqlbuilder.Append(") VALUES (");
            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (meta.Columns[i].Identity || !list.Contains(meta.Columns[i].ColumnName))
                {
                    continue;
                }
                if (j > 0)
                {
                    sqlbuilder.Append(",");
                }
                sqlbuilder.Append("@" + meta.Columns[i].PropertyName + "");
                j++;
            }
            sqlbuilder.Append(");");

            if (meta.Columns.Exists(x => x.Identity && x.PrimaryKey))
            {
                sqlbuilder.Append("SELECT CAST(LAST_INSERT_ID() AS SIGNED);");
            }
            else
            {
                sqlbuilder.Append(" SELECT CAST(0 AS SIGNED);");
            }

            return sqlbuilder.ToString();
        }

        public string BuildUpdateSql(EntityMeta meta, List<string> list)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            var keys = meta.Columns.FindAll(_ => _.PrimaryKey);
            AssertUtils.IsTrue(keys.Count > 0, $"表{meta.TableName} 不存在主键");
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("UPDATE `{0}` SET ", meta.TableName);

            for (int i = 0, j = 0; i < meta.Columns.Count; i++)
            {
                if (!meta.Columns[i].PrimaryKey && list.Contains(meta.Columns[i].ColumnName))
                {
                    if (j > 0)
                    {
                        sqlbuilder.Append(",");
                    }
                    j++;
                    sqlbuilder.Append("`" + meta.Columns[i].ColumnName + "`=@" + meta.Columns[i].PropertyName + "");
                }
            }
            sqlbuilder.Append(" WHERE ");
            for (int i = 0; i < keys.Count; i++)
            {
                if (i > 0)
                {
                    sqlbuilder.Append(" AND ");
                }
                sqlbuilder.Append("`" + keys[i].ColumnName + "`=@" + keys[i].PropertyName);
            }

            return sqlbuilder.ToString();
        }

        public string BuildSelectByPkSql(EntityMeta meta)
        {
            if (meta.Columns == null || meta.Columns.Count == 0)
                return string.Empty;

            List<string> selectColumns = new List<string>();
            meta.Columns.ForEach(item => selectColumns.Add(string.Format("`{0}`", item.ColumnName)));
            StringBuilder sqlbuilder = new StringBuilder();
            string selectColumnStr = string.Join(",", selectColumns);
            sqlbuilder.AppendFormat("SELECT {0} from `{1}`", selectColumnStr, meta.TableName);

            var pkList = meta.Columns.FindAll(item => item.PrimaryKey);
            AssertUtils.IsTrue(pkList.Count > 0, $"表{meta.TableName} 不存在主键");
            if (pkList != null && pkList.Count > 0)
            {
                sqlbuilder.Append(" WHERE 1=1 ");
                foreach (var item in pkList)
                {
                    sqlbuilder.AppendFormat(" AND `{0}`=@{1}", item.ColumnName, item.PropertyName);
                }
            }

            return sqlbuilder.ToString();

        }

        public string BuildDeleteByPkSql(EntityMeta meta)
        {
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("DELETE FROM `{0}` WHERE", meta.TableName);

            var pkList = meta.Columns.FindAll(item => item.PrimaryKey);
            AssertUtils.IsTrue(pkList.Count > 0, $"表{meta.TableName} 不存在主键");
            if (pkList != null && pkList.Count > 0)
            {
                sqlbuilder.Append(" 1=1");
                foreach (var item in pkList)
                {
                    sqlbuilder.AppendFormat(" AND `{0}`=@{1}", item.ColumnName, item.PropertyName);
                }
            }

            return sqlbuilder.ToString();
        }

        /// <summary>
        /// 通过指定列删除
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="list">指定那些列</param>
        /// <returns></returns>
        public string BuildDeleteSqlByColumns(EntityMeta meta, List<string> list)
        {
            AssertUtils.IsTrue(list != null && list.Count > 0, "删除没有指定列");

            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("DELETE FROM [{0}] WHERE 1=1 ", meta.TableName);
            var columns = meta.Columns.Where(x => list.Contains(x.ColumnName)).ToList();
            AssertUtils.IsTrue(columns != null && columns.Count > 0 && list.Count == columns.Count, "删除没有指定列或列不匹配");

            for (int i = 0; i < columns.Count; i++)
            {
                sqlbuilder.AppendFormat(" AND `{0}`=@{1}", columns[i].ColumnName, columns[i].PropertyName);
            }

            return sqlbuilder.ToString();
        }

        public string BuildDeleteSqlByProperty(EntityMeta meta, List<string> propertyNames)
        {
            AssertUtils.IsTrue(propertyNames.Count > 0, $"拼接删除语句属性列表为空,table:{meta.TableName}");
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.Append($"DELETE FROM `{meta.TableName}` WHERE 1=1 ");
            foreach (var item in propertyNames)
            {
                var columnMeta = meta.Columns.Find(x => x.PropertyName == item);
                AssertUtils.IsNotNull(columnMeta, $"拼接删除语句时，属性对应的列不存在,table:{meta.TableName},PropertyName:{item}");
                sqlbuilder.AppendFormat(" AND `{0}`=@{1}", columnMeta.ColumnName, item);
            }

            return sqlbuilder.ToString();
        }

        public string GetAllColumns(EntityMeta meta, string prefix)
        {
            prefix = prefix ?? "";
            if (!string.IsNullOrEmpty(prefix))
            {
                prefix = prefix + ".";
            }
            List<string> allColumns = meta.Columns.Select(x => $"{prefix}`{ x.ColumnName}`").ToList();
            return " " + string.Join(",", allColumns) + " ";
        }
    }
}
