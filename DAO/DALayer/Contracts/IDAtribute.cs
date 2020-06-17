using System;

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
