using Aix.ORM.Utils;
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
                    sqlbuilder.AppendFormat(" AND `{0}`=@{0}", item.PropertyName);
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
                    sqlbuilder.AppendFormat(" AND `{0}`=@{0}", item.PropertyName);
                }
            }

            return sqlbuilder.ToString();
        }


    }
}
