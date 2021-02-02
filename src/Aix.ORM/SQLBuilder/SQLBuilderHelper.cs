using Aix.ORM.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aix.ORM.SQLBuilder
{
    public static class SQLBuilderHelper
    {
        private static ConcurrentDictionary<Type, string> _InsertSqlCache = new ConcurrentDictionary<Type, string>();
        private static ConcurrentDictionary<Type, string> _UpdateSqlCache = new ConcurrentDictionary<Type, string>();
        private static ConcurrentDictionary<Type, string> _GetByPkSqlCache = new ConcurrentDictionary<Type, string>();
        private static ConcurrentDictionary<Type, string> _DeleteByPkSqlCache = new ConcurrentDictionary<Type, string>();
        private static ConcurrentDictionary<Type, string> _ReplaceSqlCache = new ConcurrentDictionary<Type, string>();
        private static ConcurrentDictionary<string, string> _AllColumnsSqlCache = new ConcurrentDictionary<string, string>();


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
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                _GetByPkSqlCache.TryAdd(type, SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildSelectByPkSql(metadeta));
            }
            return _GetByPkSqlCache[type];
        }

        public static string GetDeleteByPkSql(BaseEntity model, ORMDBType dbType)
        {
            Type type = model.GetType();
            if (!_DeleteByPkSqlCache.ContainsKey(type))
            {
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(type);
                _DeleteByPkSqlCache.TryAdd(type, SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildDeleteByPkSql(metadeta));
            }
            return _DeleteByPkSqlCache[type];
        }

        public static string GetDeleteSqlByChangeProperty(BaseEntity model, ORMDBType dbType)
        {
            EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(model.GetType());
            return SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildDeleteSqlByColumns(metadeta, model.GetPropertyChangedList());
        }

        public static string GetReplaceInsertSQL(BaseEntity model, ORMDBType dbType)
        {
            Type t = model.GetType();
            if (!_ReplaceSqlCache.ContainsKey(t))
            {
                EntityMeta metadeta = EntityReflect.GetDefineInfoFromType(t);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).BuildReplaceInsertSQL(metadeta);
                if (!_ReplaceSqlCache.ContainsKey(t))
                {
                    _ReplaceSqlCache.TryAdd(t, sql);
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

            string t = entityType.FullName + prefix;
            if (!_AllColumnsSqlCache.ContainsKey(t))
            {
                EntityMeta metadata = EntityReflect.GetDefineInfoFromType(entityType);
                string sql = SQLBuilderFactory.Instance.GetSQLBuilder(dbType).GetAllColumns(metadata, prefix);
                _AllColumnsSqlCache.TryAdd(t, sql);
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
                _InsertSqlCache.TryAdd(type, sql);
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
                _UpdateSqlCache.TryAdd(type, sql);
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
