using Aix.ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public static class SQLBuilderHelper
    {
        private static Dictionary<Type, string> _InsertSqlCache = new Dictionary<Type, string>();
        private static Dictionary<Type, string> _UpdateSqlCache = new Dictionary<Type, string>();
        private static Dictionary<Type, string> _GetByPkSqlCache = new Dictionary<Type, string>();
        private static Dictionary<Type, string> _DeleteByPkSqlCache = new Dictionary<Type, string>();
        private static Dictionary<Type, string> _ReplaceSqlCache = new Dictionary<Type, string>();
        private static Dictionary<Type, string> _AllColumnsSqlCache = new Dictionary<Type, string>();


        public static string GetInsertSql(BaseEntity model, ORMDBType dbType)
        {
            if (model.FullUpdate)
            {
                return GetInsertFullSql(model, dbType);
            }
            return GetInsertChangeColumnsSql(model, dbType);
        }

        public static string GetUpdateSql(BaseEntity model, ORMDBType dbType)
        {
            if (model.FullUpdate)
            {
                return GetUpdateFullSql(model, dbType);
            }
            return GetUpdateChangeColumnsSql(model, dbType);
        }

        public static string GetByPkSql(BaseEntity model, ORMDBType dbType)
        {
            Type type = model.GetType();
            if (!_GetByPkSqlCache.ContainsKey(type))
            {
                lock (_GetByPkSqlCache)
                {
                    if (!_GetByPkSqlCache.ContainsKey(type))
                    {
                        EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                        _GetByPkSqlCache.Add(type, SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildSelectByPkSql(metadeta));
                    }
                }
            }
            return _GetByPkSqlCache[type];
        }

        public static string GetDeleteByPkSql(BaseEntity model, ORMDBType dbType)
        {
            Type type = model.GetType();
            if (!_DeleteByPkSqlCache.ContainsKey(type))
            {
                lock (_DeleteByPkSqlCache)
                {
                    if (!_DeleteByPkSqlCache.ContainsKey(type))
                    {
                        EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                        _DeleteByPkSqlCache.Add(type, SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildDeleteByPkSql(metadeta));
                    }
                }
            }
            return _DeleteByPkSqlCache[type];
        }

        public static string GetReplaceInsertSQL(BaseEntity model, ORMDBType dbType)
        {
            Type t = model.GetType();
            if (!_ReplaceSqlCache.ContainsKey(t))
            {
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(t);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildReplaceInsertSQL(metadeta);
                lock (_ReplaceSqlCache)
                {
                    if (!_ReplaceSqlCache.ContainsKey(t))
                    {
                        _ReplaceSqlCache.Add(t, sql);
                    }
                }
            }
            return _ReplaceSqlCache[t];
        }

        public static string BuildDeleteSqlByProperty(BaseEntity model, List<string> propertyNames, ORMDBType dbType)
        {
            Type t = model.GetType();
            EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(t);
            string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildDeleteSqlByProperty(metadeta, propertyNames);
            return sql;
        }
        public static string GetAllColumns(Type entityType, ORMDBType dbType, string prefix)
        {

            Type t = entityType;
            if (!_AllColumnsSqlCache.ContainsKey(t))
            {
                EntityMeta metadata = EntityReflect.GetDefineInfoFromType(t);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).GetAllColumns(metadata, prefix);
                lock (_AllColumnsSqlCache)
                {
                    if (!_AllColumnsSqlCache.ContainsKey(t))
                    {
                        _AllColumnsSqlCache.Add(t, sql);
                    }
                }
            }
            return _AllColumnsSqlCache[t];
        }

        public static string GetTableName(Type entityType)
        {
            EntityMeta metadata = EntityReflect.GetDefineInfoFromType(entityType);
            return metadata?.TableName;
        }
        #region 私有方法

        private static string GetInsertFullSql(BaseEntity model, ORMDBType dbType)
        {
            Type type = model.GetType();
            if (!_InsertSqlCache.ContainsKey(type))
            {
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildInsertSql(metadeta);
                lock (_InsertSqlCache)
                {
                    if (!_InsertSqlCache.ContainsKey(type))
                    {
                        _InsertSqlCache.Add(type, sql);
                    }
                }
            }
            return _InsertSqlCache[type];
        }

        private static string GetInsertChangeColumnsSql(BaseEntity model, ORMDBType dbTyp)
        {
            EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(model.GetType());
            return SQLBuilderFactory.Instance.GetSQLBuilder(dbTyp).BuildInsertSql(metadeta, model.GetPropertyChangedList());
        }


        private static string GetUpdateFullSql(BaseEntity model, ORMDBType dbType)
        {
            Type type = model.GetType();
            if (!_UpdateSqlCache.ContainsKey(type))
            {
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildUpdateSql(metadeta);
                lock (_UpdateSqlCache)
                {
                    if (!_UpdateSqlCache.ContainsKey(type))
                    {
                        _UpdateSqlCache.Add(type, sql);
                    }
                }
            }
            return _UpdateSqlCache[type];
        }

        private static string GetUpdateChangeColumnsSql(BaseEntity model, ORMDBType dbTyp)
        {
            EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(model.GetType());
            return SQLBuilderFactory.Instance.GetSQLBuilder(dbTyp).BuildUpdateSql(metadeta, model.GetPropertyChangedList());
        }

        #endregion
    }
}
