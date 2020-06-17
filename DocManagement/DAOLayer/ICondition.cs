using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public enum Operator
    {
        Unknown,
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual,
        Equal,
        NotEqual

    }

    public interface ICondition : IStatement
    {
        Operator Op { get; set; }

    }
}
