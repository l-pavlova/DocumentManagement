using System;

namespace DocManagement
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateAttribute : Attribute
    {

        public string Name { get; set; }

        public DateAttribute(string name)
        {
            Name = name;
        }
    }
}
