using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DocManagement.Tests
{
    [TestClass]
    public class FacadeTests
    {
        //todo:fix not passing
        [TestMethod]
        public void TestAddItems()
        {
            var facade = new Mock<ManagingDocsFacade>();
            var doc = new Document();
            var list = new List<Document>();
            list.Add(doc);
            facade.Setup(o => o.AddItems(DatabaseTables.FileCabinet, list));
            Mock.VerifyAll();
        }

        [TestMethod]
        public void TestViewAllRecords()
        {
            var facade = new Mock<ManagingDocsFacade>();
            var list = new List<Document>();
            facade.Setup(o => o.ViewAllRecords(DatabaseTables.FileCabinet)).Returns(list);
            Mock.VerifyAll();
        }
        [TestMethod]
        public void TestAddUser()
        {
            var facade = new Mock<ManagingDocsFacade>();
            var user = FakeModelObjects.GetUser();
            facade.Setup(o => o.AddUser(DatabaseTables.Users, user)).Throws(new UserAlreadyExistsException ());
            Mock.VerifyAll();
        }
        [TestMethod]
        public void TestDelete()
        {
            var facade = new Mock<ManagingDocsFacade>();
            var guid = Guid.NewGuid();
            facade.Setup(o => o.Delete(DatabaseTables.FileCabinet, guid.ToString()));
            Mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdate()
        {
            var facade = new Mock<ManagingDocsFacade>();
            var doc = new Document();
            facade.Setup(o => o.Update(DatabaseTables.FileCabinet, doc));
            Mock.VerifyAll();
        }
    }
}
