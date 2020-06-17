using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DocManagement
{
    public class ManagingDocsFacade
    {
        private Adapter<Document> adapter;

        public ManagingDocsFacade()
        {

            adapter = AdapterFactory<Document>.GetAdapter();
        }
        public void AddItems(string tablename, List<Document> docs)
        {
            this.adapter.InsertItems(tablename, docs);
        }

        public List<Document> ViewRecordsByGuid(string tablename, Guid guid)
        {

            return this.adapter.SelectItem(tablename, guid);
        }
        public List<Document> ViewRecordsByDate(string tablename, DateTime date)
        {
            return this.adapter.SelectItem(tablename, date);
        }
        public IEnumerable<Document> ViewAllRecords(string tablename)
        {
            return this.adapter.SelectItems(tablename);
        }
        //populating the win form
        public string[] Populate(string tablename, Guid guid)
        {
            List<Condition> Conditions = new List<Condition>();
            Conditions.Add(new Condition(Operator.Equal, guid, "DocGuid"));
            List<Document> d = this.adapter.SelectItems(tablename, null, Conditions);
            Document doc = d[0];
            string[] res = { doc.DocGuid.ToString(), doc.Price.ToString(), doc.Contragent, doc.MailAddress, doc.Phone, doc.Description, doc.FilePath };

            return res;
        }

      
        public void Update(string tablename, Document document)
        {
            this.adapter.UpdateItem(tablename, document);
        }
        public void Delete(string tablename, string guid)
        {
            this.adapter.DeleteItem(tablename, Guid.Parse(guid));
        }
    }
}
