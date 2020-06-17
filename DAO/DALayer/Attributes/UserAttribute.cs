using System;

namespace DocManagement
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UserAttribute : Attribute
    {

        public string Name { get; set; }

        public UserAttribute(string name)
        {
            Name = name;
        }
    }
}
