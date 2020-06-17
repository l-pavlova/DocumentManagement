using System;

namespace DocManagement
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LastNameAttribute : Attribute
    {
        public string Name { get; set; }

        public LastNameAttribute(string name)
        {
            Name = name;
        }
    }
}

