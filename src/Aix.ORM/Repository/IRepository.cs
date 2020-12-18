using Aix.ORM.DbTransactionManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.Repository
{
  public  interface IRepository
    {
        /// <summary>
        /// 开启一个事务，
        /// using(var transScope=BeginTransScope())
        /// {...;
        /// transScope.Commit();
        /// }
        /// </summary>
        /// <param name="scopeOption"></param>
        /// <returns></returns>
        IDBTransScope BeginTransScope(TransScopeOption scopeOption = TransScopeOption.Required);

        /// <summary>
        /// 开启一个新的连接上下文 用于在正常逻辑中，异步执行一个任务（task.run）
        /// </summary>
        void OpenNewContext();
        #region 基本的增删改

        long Insert(BaseEntity entity);
        Task<long> InsertAsync(BaseEntity entity);

        int ReplaceInto(BaseEntity entity);

        Task<int> ReplaceIntoAsync(BaseEntity entity);

        int BatchInsert<T>(List<T> list) where T : BaseEntity;


       Task<int> BatchInsertAsync<T>(List<T> list) where T : BaseEntity;

        int Update(BaseEntity model);
        Task<int> UpdateAsync(BaseEntity model);

        int UpdateAllField(BaseEntity model);

        Task<int> UpdateAllFieldAsync(BaseEntity model);

        int BatchUpdate<T>(List<T> list) where T : BaseEntity;

        Task<int> BatchUpdateAsync<T>(List<T> list) where T : BaseEntity;

        int DeleteByPk(BaseEntity model);

        Task<int> DeleteByPkAsync(BaseEntity model);

        T GetByPk<T>(BaseEntity model);

        Task<T> GetByPkAsync<T>(BaseEntity model);

        #endregion
    }
}
