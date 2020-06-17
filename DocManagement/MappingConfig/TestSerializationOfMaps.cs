using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.MappingConfig
{
    public class TestSerializationOfMaps
    {
        public void TestSer()
        {
            DictionaryMappings<string, string> MapsTableOne = new DictionaryMappings<string, string>();
            MapsTableOne.Add("Guid", "DocGuid");
            MapsTableOne.Add("Name", "FileName");
            DTmapping tableOne = new DTmapping("tableOne", MapsTableOne);

            DictionaryMappings<string, string> MapsTableTwo = new DictionaryMappings<string, string>();
            MapsTableTwo.Add("Name", "StockName");
            MapsTableTwo.Add("Price", "Price");
            DTmapping tableTwo = new DTmapping("tableTwo", MapsTableTwo);

            List<DTmapping> tables = new List<DTmapping>();
            tables.Add(tableOne);
            tables.Add(tableTwo);

            DBMapping dB = new DBMapping(tables);
            dB.SerializeMaps();
        }
        public void TestDeser()
        {
            DBMapping dB = new DBMapping();
            var res=dB.DeserializeMaps();


        }


    }
}
