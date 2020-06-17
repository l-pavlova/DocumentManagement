using System;

namespace DocManagement
{
    public class InvalidNamesException : Exception
    {
        public InvalidNamesException() : base("No such user in the database")
        {

        }
    }
}
