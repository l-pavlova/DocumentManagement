using System;

namespace DocManagement
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("There is alredy a user with that email in the database!")
        {

        }
    }
}
