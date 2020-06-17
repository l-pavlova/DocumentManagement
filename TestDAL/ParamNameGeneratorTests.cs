using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocManagement
{
    [TestClass]
    public class ParamNameGeneratorTests
    {
        [TestMethod]
        public void TestGenerateParamName()
        {
            var generator = new ParamNameGenerator();
            var paramName = generator.GenerateParamName("Entity property");
            Assert.AreEqual("@Entity property", paramName);

        }
        [TestMethod]
        public void TestGenerateParamNameForColumnsWithEqualName()
        {
            var generator = new ParamNameGenerator();
            var paramName = generator.GenerateParamName("Entity property");
            var paramName1 = generator.GenerateParamName("Entity property");
            var paramName2 = generator.GenerateParamName("Entity property");
            Assert.AreEqual("@Entity property", paramName);
            Assert.AreEqual("@Entity property1", paramName1);
            Assert.AreEqual("@Entity property2", paramName2);
        }
    }
}
