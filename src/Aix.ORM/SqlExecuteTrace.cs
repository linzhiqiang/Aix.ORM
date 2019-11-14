using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM
{
    /// <summary>
    /// sql 执行跟踪器
    /// </summary>
    public abstract class AbstractSqlExecuteTrace : IDisposable
    {
        /// <summary>
        /// sql 执行跟踪器
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="paras">执行sql的参数对象</param>
        public AbstractSqlExecuteTrace(string sql, object paras)
        {
            Sql = sql;
            Param = paras;
        }

        public string Sql { get; }
        public object Param { get; }

        public void Dispose()
        {
            this.ExecuteEnd();
        }

        #region 接口定义 
        /// <summary>
        /// sql 执行开始触发前触发
        /// </summary>
        public virtual void ExecuteStart() { }

        /// <summary>
        /// sql 执行结束时触发
        /// </summary>
        public virtual void ExecuteEnd() { }

        #endregion


        /// <summary>
        /// sql执行发生异常时触发
        /// </summary>
        /// <param name="ex"></param>
        public virtual void ExecuteException(Exception ex) { }

    }

    public class DefaultSqlExecuteTrace : AbstractSqlExecuteTrace
    {
        public static DefaultSqlExecuteTrace Instance = new DefaultSqlExecuteTrace(null, null);
        public DefaultSqlExecuteTrace(string sql, object paras) : base(sql, paras)
        {
        }

    }
}
