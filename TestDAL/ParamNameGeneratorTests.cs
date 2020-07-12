using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocManagement.Tests
{
    [TestClass]
    public class ParamNameGeneratorTests
    {
        public const string testProp = "Entity property";
        [TestMethod]
        public void TestGenerateParamName()
        {
            var generator = new ParamNameGenerator();
            var paramName = generator.GenerateParamName(testProp);
            Assert.AreEqual($"@{testProp}", paramName);

        }
        [TestMethod]
        public void TestGenerateParamNameForColumnsWithEqualName()
        {
            var generator = new ParamNameGenerator();
            var paramName = generator.GenerateParamName(testProp);
            var paramName1 = generator.GenerateParamName(testProp);
            var paramName2 = generator.GenerateParamName(testProp);
            Assert.AreEqual($"@{testProp}", paramName);
            Assert.AreEqual($"@{testProp}1", paramName1);
            Assert.AreEqual($"@{testProp}2", paramName2);
        }
    }
}
