using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{

    [AttributeUsage(AttributeTargets.Property)]
    public class IDAttribute : Attribute
    {
        public string Name { get; set; }

        public IDAttribute(string name)
        {
            Name = name;
        }
    }
}
