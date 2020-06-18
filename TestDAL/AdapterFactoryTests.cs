using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]
    public class AdapterFactoryTests
    {

        Dictionary<string, string> maps;
        [TestInitialize]
        public void TestInit()
        {
            maps = new Dictionary<string, string>();

            maps.Add("DocGuid", "DocGuid");
            maps.Add("StoreDate", "StoreDate");
            maps.Add("Size", "DocumentSize");
            maps.Add("Price", "Price");
            maps.Add("Contragent", "Contragent");
            maps.Add("MailAddress", "Mail");
            maps.Add("Description", "Description");
            maps.Add("Phone", "Phone");
            maps.Add("DocumentDate", "DocumentDate");
            maps.Add("FilePath", "FilePath");
            maps.Add("UserId", "UserId");
            maps.Add("Cabinet", "Cabinet");
        }
        [TestMethod]
        public void TestAdapterType()
        {
            TestInit();
            //todo:fix connection mock
            IAdapter<Document> adapter = AdapterFactory<Document>.GetAdapter(MapConfigEnum.XMLSETTINGS, maps);
           
            Assert.IsTrue(typeof(Adapter<Document>).IsInstanceOfType(adapter));
        }
        [TestMethod]
        public void TestAttributesAdapterType()
        {
            TestInit();
            //todo:fix connection mock
            IAdapter<Document> adapter = AdapterFactory<Document>.GetAdapter(MapConfigEnum.ATTRIBUTESETTINGS, maps);

            Assert.IsTrue(typeof(AttributesAdapter<Document>).IsInstanceOfType(adapter));
        }
    }
}
