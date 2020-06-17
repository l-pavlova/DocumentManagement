using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Schema;
using System.Xml;
using System.Data;
using System.Reflection;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace DocManagement
{
    public static class ItemMappings
    {
        public static Dictionary<string, string> GetConfigurationUsingSection()
        {
            var Settings = new Dictionary<string, string>();
            var applicationSettings = WebConfigurationManager.GetSection("ApplicationSettings")
               as NameValueCollection;

            if (applicationSettings.Count == 0)
            {

            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    Settings.Add(key, applicationSettings[key]);
                }
            }
            return Settings;

        }
        /*https://www.codeproject.com/Articles/11589/Read-Write-Configuration-in-XML-file*/
        /*https://social.msdn.microsoft.com/Forums/vstudio/en-US/fb3a207d-7157-461c-8fbd-a253197dce2f/how-to-read-keyvalue-from-our-custom-created-xml-file-instead-of-appconfig-file?forum=csharpgeneral*/

    }
}
