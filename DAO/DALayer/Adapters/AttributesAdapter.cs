using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class AttributesAdapter<T> : Adapter<T>, IAdapter<T> where T : class, new()
    {
        public AttributesAdapter()
        {


        }


        public override List<T> GetItem(string tablename, MailAddress address)
        {
            List<Condition> conditions = new List<Condition>();

            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(T).GetProperties();
            }

            foreach (var info in propertyInfos)
            {
                //10.todo:
                UserAttribute userAttr = (UserAttribute)Attribute.GetCustomAttribute(info, typeof(UserAttribute));
                if (userAttr != null)
                {
                    conditions.Add(new Condition(Operator.Equal, address, userAttr.Name));
                }

            }
            return Select(tablename, null, conditions).DataTableToList<T>();
        }
        public override void InsertItems(string table, IEnumerable<T> items)
        {
            List<Condition> conditions = new List<Condition>();
            foreach (var item in items)
            {
                PropertyInfo[] propertyInfos = null;

                if (propertyInfos == null)
                {
                    propertyInfos = item.GetType().GetProperties();
                }
                foreach (var info in propertyInfos)
                {
                    var value = info.GetValue(item) ?? "(null)";

                    object[] attrs = info.GetCustomAttributes(true);
                    if (attrs.Length == 0)
                    {
                        base.InsertItems(table, items);
                        return;
                    }
                    foreach (object attr in attrs)
                    {
                        MapAttribute mapAttr = attr as MapAttribute;
                        if (mapAttr != null)
                        {
                            conditions.Add(new Condition(Operator.Equal, value, mapAttr.Name));
                        }
                    }
                }
                Insert(table, null, conditions);
                conditions.Clear();
            }
        }
        public override void UpdateItem(string table, T item)
        {
            List<Condition> conditions = new List<Condition>();
            List<Condition> columns = new List<Condition>();
            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = item.GetType().GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                var value = info.GetValue(item) ?? "(null)";

                object[] attrs = info.GetCustomAttributes(true);
                if (attrs.Length == 0)
                {
                    base.UpdateItem(table, item);
                    return;
                }
                IDAttribute idAttr = (IDAttribute)Attribute.GetCustomAttribute(info, typeof(IDAttribute));
                if (idAttr != null)
                {
                    string id = idAttr.Name;
                    conditions.Add(new Condition(Operator.Equal, value, id));
                }
                foreach (object attr in attrs)
                {
                    MapAttribute mapAttr = attr as MapAttribute;
                    if (mapAttr != null)
                    {
                        columns.Add(new Condition(Operator.Equal, value, mapAttr.Name));
                    }
                }
            }
            Update(table, columns, conditions);
        }
    }
}
