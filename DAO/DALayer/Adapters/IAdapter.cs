using DocManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public interface IAdapter<T> where T: class, new()
    {
        T GetItem(string tablename, Guid g);
        List<T> GetItem(string tablename, DateTime date);
        List<T> GetItem(string tablename, string Id);
        List<T> GetItem(string tablename, MailAddress address);
        List<T> GetItems(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null);
        DataTable Select(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null);
        void InsertItems(string table, IEnumerable<T> items);
        void Insert(string table, IEnumerable<string> columns = null, IEnumerable<IStatement> conditions = null);
        
        void DeleteItem(string table, Guid guid);
        void Delete(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null);
        
        void UpdateItem(string table, T item);
        void Update(string table, IEnumerable<IStatement> columns = null, IEnumerable<Condition> conditions = null);
    }
}
