using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace DocManagement
{
    public class ManagingDocsFacade
    {
        private IAdapter<Document> adapter;
        private IAdapter<User> userAdapter;
        private IAdapter<Cabinet> cabinetAdapter;
        private Mappings maps;
       
        public void InitializeAdapters()
        {
            maps = Mappings.GetMappings();
            adapter = AdapterFactory<Document>.GetAdapter(maps.ConfigStrategy.Value, maps.Mapping.Value);
            userAdapter = AdapterFactory<User>.GetAdapter(maps.ConfigStrategy.Value, maps.Mapping.Value);
            cabinetAdapter = AdapterFactory<Cabinet>.GetAdapter(maps.ConfigStrategy.Value, maps.Mapping.Value);
        }

        public ManagingDocsFacade()
        {
            InitializeAdapters();
        }
        public void AddItems(string tablename, List<Document> docs)
        {
            this.adapter.InsertItems(tablename, docs);
        }

        public Document ViewRecordByGuid(string tablename, Guid guid)
        {
            return this.adapter.GetItem(tablename, guid);
        }

        public IEnumerable<Document> ViewRecordsByDate(string tablename, DateTime date)
        {
            return this.adapter.GetItem(tablename, date);
        }
        public IEnumerable<Document> ViewAllRecords(string tablename)
        {
            return this.adapter.GetItems(tablename);
        }

        public IEnumerable<Document> OpenCabinet(string tablename, Guid cabinet)
        {

            List<Condition> Conditions = new List<Condition>();
            Conditions.Add(new Condition(Operator.Equal, cabinet, "Cabinet"));

            return this.adapter.GetItems(tablename, null, Conditions);

        }
        public List<Cabinet> ViewCabinets(string tablename, string userId)
        {
            var user = AuthenticationManager.ParseUserToken(userId);
            return this.cabinetAdapter.GetItem(tablename, user.Id);
        }

        public void Update(string tablename, Document document)
        {
            document.UserId = AuthenticationManager.ParseUserToken(document.UserId).Id;
            this.adapter.UpdateItem(tablename, document);
        }
        public void Delete(string tablename, string guid)
        {
            this.adapter.DeleteItem(tablename, Guid.Parse(guid));
        }
        public string GetUserToken(string tablename, User user)
        {
            var dbUser = this.userAdapter.GetItem(tablename, new MailAddress(user.Email)).FirstOrDefault();
            if (dbUser == null)
            {
                throw new InvalidNamesException();
            }
            if (!user.VerifyPassword(dbUser.Password))
            {
                throw new InvalidPasswordException(user.Password);
            }
            else
            {
                var token = AuthenticationManager.CreateUserToken(dbUser);
                return token;
            }

        }
        public void AddUser(string tablename, User user)
        {
            user.Password = user.HashPassword();
            var users = new List<User>();
            users.Add(user);
            var dbUser = this.userAdapter.GetItem(tablename, new MailAddress(user.Email)).FirstOrDefault();
            if (dbUser != null)
            {
                throw new UserAlreadyExistsException();
            }

            this.userAdapter.InsertItems(tablename, users);
        }

        public void AddCabinet(string tablename, Cabinet cabinet)
        {
            var cabinets = new List<Cabinet>();
            cabinets.Add(cabinet);
            this.cabinetAdapter.InsertItems(tablename, cabinets);
        }
        //populating the win form
        public string[] Populate(string tablename, Guid guid)
        {
            List<Condition> Conditions = new List<Condition>();
            Conditions.Add(new Condition(Operator.Equal, guid, "DocGuid"));
            List<Document> d = this.adapter.GetItems(tablename, null, Conditions);
            Document doc = d[0];
            string[] res = { doc.DocGuid.ToString(), doc.Price.ToString(), doc.Contragent, doc.MailAddress, doc.Phone, doc.Description, doc.FilePath };

            return res;
        }

    }
}
