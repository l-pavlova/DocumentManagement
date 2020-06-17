using System;

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
