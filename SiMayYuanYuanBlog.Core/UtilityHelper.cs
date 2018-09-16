using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SiMayYuanYuanBlog.Core
{
    public class UtilityHelper
    {
        public static List<T> GetModelEntity<T>(DataTable table)
        {
            if (table == null)
                return default(List<T>);

            List<T> entitys = new List<T>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                T entity = Activator.CreateInstance<T>();

                PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

                foreach (PropertyInfo property in propertyInfos)
                {
                    object o = row[property.Name];
                    switch (o.GetType().ToString())
                    {
                        case "String":
                            property.SetValue(entity, (String)o);
                            break;
                        case "Int32":
                            property.SetValue(entity, (Int32)o);
                            break;
                        case "Int64":
                            property.SetValue(entity, (Int64)o);
                            break;
                        case "Boolean":
                            property.SetValue(entity, (Boolean)o);
                            break;
                        case "Byte":
                            property.SetValue(entity, (Byte)o);
                            break;
                        case "DateTime":
                            property.SetValue(entity, (DateTime)o);
                            break;
                    }

                }

                entitys.Add(entity);
            }


            return entitys;
        }
    }
}
