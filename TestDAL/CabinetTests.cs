using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]
    public class CabinetTests
    {
        [TestMethod]
        public void TestCabinetCreator()
        {
            var cab = new Cabinet();
            Assert.IsNotNull(cab);
        }
    }
}
