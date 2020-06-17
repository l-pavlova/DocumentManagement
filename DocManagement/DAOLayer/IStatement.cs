using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public interface IStatement
    {
        string ColumnName { get; set; }
        object Value { get; set; }
    }
}
