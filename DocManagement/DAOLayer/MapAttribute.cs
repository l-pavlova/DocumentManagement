using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapAttribute:Attribute
    {
        
        public string Name { get; set; }

        public MapAttribute(string name)
        {
            Name = name;
        }
    }
}
