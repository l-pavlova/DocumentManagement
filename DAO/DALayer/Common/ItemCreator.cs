using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DocManagement
{
    public static class ItemCreator
    {
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {

            List<T> list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T obj = new T();

                PropertyInfo[] propertyInfos = null;

                if (propertyInfos == null)
                {
                    propertyInfos = typeof(T).GetProperties();
                }
                foreach (var prop in obj.GetType().GetProperties())
                {
                    MapAttribute mapAttr = (MapAttribute)Attribute.GetCustomAttribute(prop, typeof(MapAttribute));
                    if (mapAttr != null)
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[mapAttr.Name], prop.PropertyType), null);
                    }

                }

                list.Add(obj);
            }
            return list;

        }
    }
}
