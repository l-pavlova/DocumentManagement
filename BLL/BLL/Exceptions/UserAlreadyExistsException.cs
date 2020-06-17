using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("There is alredy a user with that email in the database!")
        {

        }
    }
}
