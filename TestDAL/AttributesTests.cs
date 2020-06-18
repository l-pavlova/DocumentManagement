using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]
    public class AttributesTests
    {
        [TestMethod]
        public void TestCabinetAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(CabinetAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
        [TestMethod]
        public void TestDateAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(DateAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
        [TestMethod]
        public void TestFirstNameAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(FirstNameAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
        [TestMethod]
        public void TestLastNameAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(LastNameAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
        [TestMethod]
        public void TestMapAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(MapAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
        [TestMethod]
        public void TestUserAttribute()
        {
            var attributes = (IList<AttributeUsageAttribute>)typeof(UserAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }
    }

}