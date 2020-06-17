using System;

namespace DocManagement
{
    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {

        }

        public InvalidPasswordException(string pass) : base(String.Format("Entered invalid password: {0}", pass))
        {

        }

    }
}
