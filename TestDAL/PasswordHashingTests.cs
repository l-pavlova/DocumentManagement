using Microsoft.VisualStudio.TestTools.UnitTesting;

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
