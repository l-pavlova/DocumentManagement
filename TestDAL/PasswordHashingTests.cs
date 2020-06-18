using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocManagement.Tests
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
        [TestMethod]
        public void TestUserPasswordVerification()
        {
            var user = FakeModelObjects.GetUser();
            var currPass = user.Password;
            user.Password = user.HashPassword();
            try
            {

            Assert.IsTrue(user.VerifyPassword(currPass));
            }
            catch(BCrypt.Net.SaltParseException ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
