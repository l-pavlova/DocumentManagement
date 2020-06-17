﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web.Configuration;

namespace DocManagement
{
    public class ManagingDocsFacade
    {
        private IAdapter<Document> adapter;
        private IAdapter<User> userAdapter;
        private IAdapter<Cabinet> cabinetAdapter;
        private Mappings maps;
        //todo: 2.pass config only once
        //do a singleton pattern for mapping config and then for configstratwgy
        //lazy design pattern
        //check lazy class
        public void TestSingleton()
        {
            maps = Mappings.GetMappings();
            adapter = AdapterFactory<Document>.GetAdapter(maps.ConfigStrategy, maps.Mapping.Value);
            userAdapter = AdapterFactory<User>.GetAdapter(maps.ConfigStrategy, maps.Mapping.Value);
            cabinetAdapter = AdapterFactory<Cabinet>.GetAdapter(maps.ConfigStrategy, maps.Mapping.Value);
        }

        public ManagingDocsFacade()
        {
            
            TestSingleton();

            //adapter = AdapterFactory<Document>.GetAdapter();
            //userAdapter = AdapterFactory<User>.GetAdapter();
            //cabinetAdapter = AdapterFactory<Cabinet>.GetAdapter();
        }
        public void AddItems(string tablename, List<Document> docs)
        {
            for (int i = 0; i < docs.Count; i++)
            {
                docs[i].UserId = AuthenticationManager.ParseUserToken(docs[i].UserId).Id;
            }
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
            var user = DocManagement.AuthenticationManager.ParseUserToken(userId);
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