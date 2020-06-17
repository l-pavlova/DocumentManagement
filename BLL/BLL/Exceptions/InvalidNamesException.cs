using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class InvalidNamesException : Exception
    {
        public InvalidNamesException() : base("No such user in the database")
        {

        }
    }
}
