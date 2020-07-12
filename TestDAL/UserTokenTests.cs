using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DocManagement.Tests
{
    [TestClass]
    public class UserTokenTests
    {
        [TestMethod]
        public void TryGetUserFromDbThrowsNoSuchUserException()
        {
            try
            {
                var facade = new ManagingDocsFacade();
                //todo stub the adapter because tests don't work on data from the database
                facade.GetUserToken(DatabaseTables.FileCabinet, FakeModelObjects.GetUser());
            }
            catch (ArgumentNullException)
            {

            }
        }
    }
}
