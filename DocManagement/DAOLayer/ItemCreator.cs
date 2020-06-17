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

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                    catch
                    {

                    }
                }

                list.Add(obj);
            }
            return list;

        }
    }
}
