using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    [TestClass]
   
    public class PasswordHashingTests
    {
        [TestMethod]
        public void TestUserPasswordHashing()
        {
            var user = FakeModelObjects.GetUser();
            var currPass = user.Password;
            user.Password = user.HashPassword();
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(currPass, user.Password));
        }
    }
}
