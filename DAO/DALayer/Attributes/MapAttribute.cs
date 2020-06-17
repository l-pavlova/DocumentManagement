using System;

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
