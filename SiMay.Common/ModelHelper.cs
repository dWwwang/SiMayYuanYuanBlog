using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiMay.Common
{
    public class ModelHelper<T> where T : new()
    {
        public static List<T> ConvertToModelEntitys(DataTable table)
        {
            if (table == null)
                return default(List<T>);

            List<T> entitys = new List<T>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                T entity = new T();

                PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

                foreach (PropertyInfo property in propertyInfos)
                {
                    if (table.Columns.Contains(property.Name))
                    {
                        if (!property.CanWrite) continue;

                        object o = row[property.Name];
                        if (o != DBNull.Value)
                            property.SetValue(entity, o);
                    }
                }

                entitys.Add(entity);
            }
            return entitys;
        }

        public static T ConvertToModelEntity(DataTable table)
        {
            if (table == null && table.Rows.Count <= 0)
                return default(T);

            DataRow row = table.Rows[0];

            T entity = new T();

            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                if (table.Columns.Contains(property.Name))
                {
                    if (!property.CanWrite) continue;

                    object o = row[property.Name];
                    if (o != DBNull.Value)
                        property.SetValue(entity, o);
                }
            }

            return entity;
        }
    }
}
