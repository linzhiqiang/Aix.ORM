using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aix.ORM.Common;

namespace Aix.ORM.Repository
{
    public class MsSqlRepository : AbstractRepository
    {
        public MsSqlRepository(string connectionStrings) : base(connectionStrings)
        {
        }

        protected override ORMDBType GetORMDBType()
        {
            return ORMDBType.MsSql;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <typeparam name="T">返回列表的实体对象类型</typeparam>
        /// <param name="view">分页查询信息</param>
        /// <param name="sqlColumns">查询的字符串</param>
        /// <param name="sqlTable">查询的表，可以为多表，即From后面 where之前的内容</param>
        /// <param name="sqlCondition">查询条件 Where 后面的部分.</param>
        /// <param name="param">查询实体值得实体对象.</param>
        /// <param name="sqlOrder">排序字段 包含Order by.</param>
        /// <returns>返回分页信息，当查询为第一页时 返回总记录数</returns>
        protected async Task<PagedList<T>> PagedQueryAsync<T>(PageView view, string sqlColumns, string sqlTable, string sqlCondition, object param, string sqlOrder)
        {
            PagedList<T> pList = new PagedList<T>();
            var totalCount = -1;
            if (view.PageIndex == 1 || view.IsFirstQueryTotal == false)
            {
                string totalSql = string.Format(" select count(1) from {0} where 1=1 {1}  ", sqlTable, sqlCondition);
                totalCount = await ExecuteScalarAsync<int>(totalSql, param);
            }

            //if (string.IsNullOrEmpty(sqlOrder))
            //{
            //    sqlOrder = " ORDER BY " + sqlPk;
            //}
            int pageStartIndex = view.PageSize * (view.PageIndex - 1) + 1;
            int pageEndIndex = view.PageSize * view.PageIndex;
            string sql = string.Format(" select {0},ROW_NUMBER() OVER({1}) AS RowNumber  from {2} where 1=1  {3} ", sqlColumns, sqlOrder, sqlTable, sqlCondition);
            string pageSql =
                string.Format(" select * from ({0}) as pagetable where RowNumber >={1}  and RowNumber<= {2}  ", sql, pageStartIndex, pageEndIndex);
            pList.DataList = await QueryAsync<T>(pageSql, param);
            pList.Total = (int)totalCount;
            pList.PageIndex = view.PageIndex;
            pList.PageSize = view.PageSize;
            return pList;
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <typeparam name="T">返回列表的实体对象类型</typeparam>
        /// <param name="view">分页查询信息</param>
        /// <param name="sqlColumns">查询的字符串</param>
        /// <param name="sqlTable">查询的表，可以为多表，即From后面 where之前的内容</param>
        /// <param name="sqlCondition">查询条件 Where 后面的部分.</param>
        /// <param name="param">查询实体值得实体对象.</param>
        /// <param name="sqlOrder">排序字段 包含Order by.</param>
        /// <returns>返回分页信息，当查询为第一页时 返回总记录数</returns>
        protected PagedList<T> PagedQuery<T>(PageView view, string sqlColumns, string sqlTable, string sqlCondition, object param,  string sqlOrder)
        {
            PagedList<T> pList = new PagedList<T>();
            var totalCount = -1;
            if (view.PageIndex == 1 || view.IsFirstQueryTotal == false)
            {
                string totalSql = string.Format(" select count(1) from {0} where 1=1 {1}  ", sqlTable, sqlCondition);
                totalCount = ExecuteScalar<int>(totalSql, param);
            }

            //if (string.IsNullOrEmpty(sqlOrder))
            //{
            //    sqlOrder = " ORDER BY " + sqlPk;
            //}
            int pageStartIndex = view.PageSize * (view.PageIndex - 1) + 1;
            int pageEndIndex = view.PageSize * view.PageIndex;
            string sql = string.Format(" select {0},ROW_NUMBER() OVER({1}) AS RowNumber  from {2} where 1=1  {3} ", sqlColumns, sqlOrder, sqlTable, sqlCondition);
            string pageSql =
                string.Format(" select * from ({0}) as pagetable where RowNumber >={1}  and RowNumber<= {2}  ", sql, pageStartIndex, pageEndIndex);
            pList.DataList = Query<T>(pageSql, param);
            pList.Total = (int)totalCount;
            pList.PageIndex = view.PageIndex;
            pList.PageSize = view.PageSize;
            return pList;
        }

        /// <summary>
        /// 分页查询单表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view"></param>
        /// <param name="where">userid=1 and username='admin'</param>
        /// <param name="param"></param>
        /// <param name="sqlOrder">排序字段 包含Order by </param>
        /// <returns></returns>
        protected PagedList<T> SimplePagedQuery<T>(PageView view, string where, object param, string sqlOrder) where T : BaseEntity
        {
            string sqlColumns = GetAllColumns<T>();
            string sqlTable = GetTableName<T>();
            return PagedQuery<T>(view, sqlColumns, sqlTable, where, param, sqlOrder);

        }

        /// <summary>
        /// 分页查询单表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view"></param>
        /// <param name="where">userid=1 and username='admin'</param>
        /// <param name="param"></param>
        /// <param name="sqlOrder">排序字段 包含Order by </param>
        /// <returns></returns>
        protected Task<PagedList<T>> SimplePagedQueryAsync<T>(PageView view, string where, object param, string sqlOrder) where T : BaseEntity
        {
            string sqlColumns = GetAllColumns<T>();
            string sqlTable = GetTableName<T>();
            return PagedQueryAsync<T>(view, sqlColumns, sqlTable, where, param, sqlOrder);

        }
    }
}
