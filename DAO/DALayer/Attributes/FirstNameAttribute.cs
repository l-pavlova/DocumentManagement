using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FirstNameAttribute: Attribute
    {

        public string Name { get; set; }

        public FirstNameAttribute(string name)
        {
            Name = name;
        }
    }
}
