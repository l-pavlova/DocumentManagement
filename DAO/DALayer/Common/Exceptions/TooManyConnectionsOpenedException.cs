using System;

namespace DocManagement
{
    public class TooManyConnectionsOpenedException : Exception
    {
        public TooManyConnectionsOpenedException() : base("Attempting to open too many connections to the database")
        {
            //todo999: implement waiting queue to add users to wait for data
        }
    }
}
