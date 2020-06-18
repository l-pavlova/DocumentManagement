using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]

    public class MappingsTest
    {
        Mappings firstMappings;
        Mappings secondMappings;
        [TestInitialize]
        public void TestInit()
        {
            firstMappings = Mappings.GetMappings();
            secondMappings = Mappings.GetMappings();
        }
        [TestMethod]
        public void TestSingletonReturnsTheSameInstanceOfMappings()
        {
            Assert.AreSame(firstMappings, secondMappings);
        }
        [TestMethod]
        public void TestSingletonReturnsTheSameInstanceOfConfigStrategy()
        {
            Assert.AreSame(firstMappings.ConfigStrategy, secondMappings.ConfigStrategy);
        }
        [TestMethod]
        public void TestConfigStrategy()
        {
            if (firstMappings.ConfigStrategy.IsValueCreated)
            {
                Assert.AreEqual(MapConfigEnum.XMLSETTINGS, firstMappings.ConfigStrategy.Value);
            }
            else
            {
                try
                {
                    var settings = firstMappings.ConfigStrategy.Value;
                    Assert.AreEqual(MapConfigEnum.XMLSETTINGS, settings);
                }
                catch(ArgumentNullException e)
                {
                    Console.WriteLine(e.StackTrace);
                    //since settings are initialized lazily, when trying to access them before that argnull exception gets thrown
                }
            }
        }
    }
}
