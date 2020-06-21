using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public interface ISQLBuilder
    {
        /// <summary>
        ///根据实体的源信息获取insert sql 语句
        /// </summary>
        /// <param name="meta">The meta.</param>
        /// <returns></returns>
        string BuildInsertSql(EntityMeta meta);

        /// <summary>
        /// 根据实体的源信息获取update sql 语句
        /// </summary>
        /// <param name="meta">The meta.</param>
        /// <returns></returns>
        string BuildUpdateSql(EntityMeta meta);

        /// <summary>
        /// 根据实体元信息获取指定列的insert sql 语句
        /// </summary>
        /// <param name="meta">实体元信息.</param>
        /// <param name="list">新增的字段名列表.</param>
        /// <returns></returns>
        string BuildInsertSql(EntityMeta meta, List<string> list);

        /// <summary>
        /// 根据实体元信息获取指定列的update sql 语句
        /// </summary>
        /// <param name="meta">实体元信息</param>
        /// <param name="list">更新的字段名列表.</param>
        /// <returns></returns>
        string BuildUpdateSql(EntityMeta meta, List<string> list);

        string BuildSelectByPkSql(EntityMeta meta);

        string BuildDeleteByPkSql(EntityMeta meta);

        /// <summary>
        /// 通过制定列删除
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="list">指定那些列</param>
        /// <returns></returns>
        string BuildDeleteSqlByColumns(EntityMeta meta, List<string> list);

        /// <summary>
        /// mysql 专有的
        /// </summary>
        /// <param name="meta"></param>
        /// <returns></returns>
        string BuildReplaceInsertSQL(EntityMeta meta);

        /// <summary>
        /// 根据属性拼接删除语句
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        string BuildDeleteSqlByProperty(EntityMeta meta, List<string> propertyNames);

        /// <summary>
        /// 获取所有列 逗号分隔 mysql用``,sqlserver用[]
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="prefix">如A 最终sql语句就是A.Id，可为空</param>
        /// <returns></returns>
        string GetAllColumns(EntityMeta meta, string prefix);
    }
}
