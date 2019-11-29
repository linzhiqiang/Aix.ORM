using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Aix.ORM
{
    /// <summary>
    /// 实体和表元数据机械
    /// </summary>
    public class EntityReflect
    {
        private static Dictionary<Type, EntityMeta> _cache = new Dictionary<Type, EntityMeta>();
        private static object lockobject = new object();

        public static EntityMeta GetDefineInfoFromType(Type type)
        {
            if (!_cache.ContainsKey(type))
            {
                lock (lockobject)
                {
                    if (!_cache.ContainsKey(type))
                    {
                        EntityMeta meta = GetEntityMeta(type);
                        _cache.Add(type, meta);
                    }
                }
            }
            return _cache[type];
        }

        private static EntityMeta GetEntityMeta(Type type)
        {
            EntityMeta meta = new EntityMeta();
            meta.TableName = GetTableName(type);

            PropertyInfo[] pinfos = type.GetProperties();
            foreach (PropertyInfo p in pinfos)
            {
                ColumnAttribute attr = (ColumnAttribute)Attribute.GetCustomAttribute(p, typeof(ColumnAttribute));
                if (attr != null)
                {
                    EntityColumnMeta ecmeta = new EntityColumnMeta();
                    ecmeta.PropertyName = p.Name;
                    ecmeta.ColumnName = attr.ColumnName;
                    ecmeta.Identity = Attribute.GetCustomAttribute(p, typeof(IdentityAttribute)) != null;
                    ecmeta.PrimaryKey = Attribute.GetCustomAttribute(p, typeof(PrimaryKeyAttribute)) != null;
                    meta.Columns.Add(ecmeta);
                }
            }

            return meta;
        }

        private static string GetTableName(Type type)
        {
            TableAttribute tableAttribute = (TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            if (tableAttribute != null)
            {
                return tableAttribute.TableName;
            }
            return type.FullName.Split('.').Last();
        }
    }

    public class EntityMeta
    {
        public string TableName { get; set; }

        private List<EntityColumnMeta> _Columns;

        public List<EntityColumnMeta> Columns
        {
            get
            {
                if (_Columns == null)
                {
                    _Columns = new List<EntityColumnMeta>();
                }
                return _Columns;
            }
        }
    }

    public class EntityColumnMeta
    {
        /// <summary>
        /// 实体属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 实体对应表的列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 是否主键 
        /// </summary>
        public bool PrimaryKey { get; set; }

       /// <summary>
       /// 是否自增列
       /// </summary>
        public bool Identity { get; set; }
    }
}
