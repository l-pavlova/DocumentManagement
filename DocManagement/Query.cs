using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class Query
    {
        private static List<Condition> conditions;

        public Query()
        {
            conditions = new List<Condition>();
        }
        public Query Add(Condition s)
        {
            conditions.Add(s);
            return this;
        }
       
    }
}
