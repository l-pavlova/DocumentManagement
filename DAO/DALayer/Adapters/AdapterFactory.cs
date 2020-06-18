using System;
using System.Collections.Generic;

namespace DocManagement
{
    public enum MapConfigEnum
    {
        XMLSETTINGS,
        ATTRIBUTESETTINGS
    }

    public abstract class AdapterFactory<T> where T : class, new()
    {
      
        public static Adapter<T> GetAdapter(MapConfigEnum type, Dictionary<string, string> maps)
        {
           
            switch (type)
            {
                case MapConfigEnum.XMLSETTINGS:
                    {
                        return new Adapter<T>(maps);
                    }
                case MapConfigEnum.ATTRIBUTESETTINGS:
                    {
                        return new AttributesAdapter<T>();
                    }
                default:
                    return new Adapter<T>(maps);
            }

        }
    }
}
