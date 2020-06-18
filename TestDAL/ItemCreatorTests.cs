using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;

namespace DocManagement.Tests
{
    [TestClass]
    public class ItemCreatorTests
    {
        /// <summary>
        /// This method contains magic strings because it tests mock data from the database, takes an example fake user entity from db
        /// The password testing is covered in AuthenticationManager test
        /// </summary>
        [TestMethod]
        public void TestDataTableToList()
        {
            
            var expectedUser = FakeModelObjects.GetUser();
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            DataRow dataRow = dt.NewRow();
            dataRow["Id"] = FakeModelObjects.FakeGuid.ToString();
            dataRow["FirstName"] = "Default";
            dataRow["LastName"] = "Userov";
            dataRow["Email"] = "email@mail.com";
            dataRow["Password"] = "hiddenPass";
            dt.Rows.Add(dataRow);
            var resUser = ItemCreator.DataTableToList<User>(dt).FirstOrDefault();
            Assert.AreEqual(expectedUser.Id, resUser.Id);
            Assert.AreEqual(expectedUser.FirstName, resUser.FirstName);
            Assert.AreEqual(expectedUser.LastName, resUser.LastName);
            Assert.AreEqual(expectedUser.Email, resUser.Email);

        }
       
    }
}
