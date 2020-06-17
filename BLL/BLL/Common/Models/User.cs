using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DocManagement
{

    public class User
    {
        [Map("Id")]
        public string Id { get; set; }
        [Map("FirstName")]
        [FirstName("FirstName")]
        public string FirstName { get; set; }
        [Map("LastName")]
        [LastName("LastName")]
        public string LastName { get; set; }

        [Map("Email")]
        public string Email { get; set; }


        [Map("Password")]
        public string Password { get; set; }
        public string HashPassword()
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(Password, salt);
        }
        public bool VerifyPassword(string pass)
        {
            return BCrypt.Net.BCrypt.Verify(this.Password, pass);
        }

    }
}