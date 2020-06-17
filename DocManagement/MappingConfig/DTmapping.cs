using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DocManagement.MappingConfig
{
    public class DTmapping
    {
        public string TableName { get; set; }
        public DictionaryMappings<string, string> Mappings { get; set; }

        public DTmapping()
        {

        }
        public DTmapping(string name, Dictionary<string, string> maps)
        {
            Mappings = new DictionaryMappings<string, string>();
            TableName = name;
            foreach (var item in maps)
            {
                Mappings.Add(item.Key, item.Value);
            }
        }

    }
}
