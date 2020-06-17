using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    internal enum MapConfigEnum
    {
        XMLSETTINGS,
        ATTRIBUTESETTINGS
    }

    public abstract class AdapterFactory<T> where T : class, new() 
    {
        public static Adapter<T> GetAdapter()
        {
            MapConfigEnum type = (MapConfigEnum)Enum.Parse(typeof(MapConfigEnum), (ConfigurationManager.AppSettings["MappingConfigStrategy"]));
            switch (type)
            {
                case MapConfigEnum.XMLSETTINGS:
                    {
                        return new Adapter<T>();
                    }
                case MapConfigEnum.ATTRIBUTESETTINGS:
                    {
                        return new AttributesAdapter<T>();
                    }
                default:
                    return new Adapter<T>();
            }

        }
    }
}
