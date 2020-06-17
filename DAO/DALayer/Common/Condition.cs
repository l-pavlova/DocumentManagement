using DocManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{

    public class Condition : ICondition
    {

        public Operator Op { get; set; }
        public string ColumnName { get; set; }
        public object Value { get; set; }

        public Condition(Operator op, object value, string colName = "")
        {
            ColumnName = colName;
            Op = op;
            Value = value;
        }


    }
}
