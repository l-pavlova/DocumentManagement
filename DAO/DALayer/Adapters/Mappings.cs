using System;
using System.Collections.Generic;
using System.Web.Configuration;

namespace DocManagement
{
    public class Mappings
    {
        private static volatile Mappings instance; //volatile for thread safety add locks if time 
        public  Lazy<Dictionary<string, string>> Mapping { get; private set; }
        public  Lazy<MapConfigEnum> ConfigStrategy { get; private set; }
        private Mappings()
        {
            Mapping = new Lazy<Dictionary<string, string>>(() =>
            {
                return ItemMappings.GetConfigurationUsingSection();

            });
            ConfigStrategy = new Lazy<MapConfigEnum>(() =>
            {
                return (MapConfigEnum)Enum.Parse(typeof(MapConfigEnum), (WebConfigurationManager.AppSettings["MappingConfigStrategy"]));
            });
        }
        public static Mappings GetMappings()
        {
            if (instance == null)
            {
                instance = new Mappings();
            }
            return instance;
        }
    }
}
