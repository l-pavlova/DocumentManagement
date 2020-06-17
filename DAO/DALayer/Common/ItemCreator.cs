using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                    //try
                    {
                        if (mapAttr != null)
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[mapAttr.Name], prop.PropertyType), null);
                        }
                    }
                    /*catch
                    {

                    }*/
                }

                list.Add(obj);
            }
            return list;

        }
    }
}
