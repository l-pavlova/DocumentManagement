using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void TestDocumentCreator()
        {
            var doc = new Document();
            Assert.IsNotNull(doc);
        }
        [TestMethod]
        public void TestDocumentToString()
        {
            var doc = new Document();
            Assert.IsNotNull(doc.ToString());
        }
    }
}
