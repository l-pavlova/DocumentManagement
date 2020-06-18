using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{

    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void TestSelect()
        {
            var adapter = new Mock<Adapter<Document>>();
            var doc = new Document();
            adapter.Setup(o => o.GetItem(DatabaseTables.FileCabinet, It.IsAny<Guid>())).Returns(doc);
        }
        [TestMethod]
        public void TestSelectById()
        {
            var adapter = new Mock<Adapter<Document>>();
            var doc = new Document();
            var list = new List<Document>();
            list.Add(doc);
            adapter.Setup(o => o.GetItem(DatabaseTables.FileCabinet, It.IsAny<String>())).Returns(list);
        }
        [TestMethod]
        public void TestDelete()
        {
            var adapter = new Mock<Adapter<Document>>();         
            adapter.Setup(o => o.DeleteItem(DatabaseTables.FileCabinet, It.IsAny<Guid>()));
        }
        [TestMethod]
        public void TestUpdate()
        {
            var adapter = new Mock<Adapter<Document>>();
            var doc = new Document();
            adapter.Setup(o => o.UpdateItem(DatabaseTables.FileCabinet, doc));
        }
        [TestMethod]
        public void TestInsertItems()
        {
            var adapter = new Mock<Adapter<Document>>();
            var doc = new Document();
            var list = new List<Document>();
            list.Add(doc);
            adapter.Setup(o => o.InsertItems(DatabaseTables.FileCabinet, list));
        }


    }
}
