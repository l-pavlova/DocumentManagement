using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DocManagement
{
    public enum MapConfigEnum
    {
        XMLSETTINGS,
        ATTRIBUTESETTINGS
    }

    public abstract class AdapterFactory<T> where T : class, new()
    {
      
        public static Adapter<T> GetAdapter(Lazy<MapConfigEnum> type, Dictionary<string, string> maps)
        {
           
            switch (type.Value)
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
