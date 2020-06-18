using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Tests
{
    [TestClass]
    public class ConditionsTests
    {
        [TestMethod]
        public void TestStatement()
        {
            IStatement statement = new Statement("1", "Id");
            Assert.AreEqual("1", statement.Value);
            Assert.AreEqual("Id", statement.ColumnName);
        }
        public void TestCondition()
        {
            ICondition condition = new Condition(Operator.Greater, DateTime.Now, "DocumentDate");
            Assert.AreEqual(Operator.Greater,condition.Op);
            Assert.AreEqual("DocumentDate",condition.ColumnName);
        }
    }
}
