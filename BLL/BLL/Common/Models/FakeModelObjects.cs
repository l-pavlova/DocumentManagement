using DocManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement { 
    public static class FakeModelObjects
    {
        public static readonly Guid FakeGuid = Guid.NewGuid();
        public static User GetUser()
        {
            
            return new User
            {
                Id = FakeGuid.ToString(),
                FirstName = "Default",
                LastName = "Userov",
                Email = "email@mail.com",
                Password = "hiddenPass"
            };
        }
        public static Cabinet GetCabinet(User user)
        {
            return new Cabinet
            {
                Id = Guid.NewGuid(),
                Name = "Default cabinet",
                Color = "Blue",
                UserId = user.Id
            };
        }
    }
}
