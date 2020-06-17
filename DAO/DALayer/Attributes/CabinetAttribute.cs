using System;

namespace DocManagement
{

    [AttributeUsage(AttributeTargets.Property)]
    public class CabinetAttribute:Attribute
    {
        public string Name { get; set; }

        public CabinetAttribute(string name)
        {
            Name = name;
        }
    }
}
