using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DocManagement.MappingConfig
{
    public class DBMapping
    {

        public List<DTmapping> DTmappings { get; set; }

        public DBMapping()
        {

        }
        public DBMapping(List<DTmapping> dtm)
        {
            DTmappings = new List<DTmapping>();
            foreach (var item in dtm)
            {
                DTmappings.Add(new DTmapping(item.TableName, item.Mappings));
            }
        }
        public void SerializeMaps()
        {
            string filename = string.Empty;
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Title = "Save Maps";
                saveFileDialog1.Filter = "Xml|*.xml";
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;
            }
            using (System.IO.FileStream fs = File.OpenWrite(filename))
            {
                XmlSerializer ser = new XmlSerializer(typeof(DBMapping));
                ser.Serialize(fs, this);
            }
        }
        public DBMapping DeserializeMaps()
        {
            DBMapping res;
            string filename = string.Empty;
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Open Maps";
                open.Filter = "Xml|*.xml";
                open.ShowDialog();
                filename = open.FileName;
            }
            using (System.IO.FileStream fs = File.OpenRead(filename))
            {
                XmlSerializer ser = new XmlSerializer(typeof(DBMapping));
                res=(DBMapping)ser.Deserialize(fs);
            }
            return res;
        }

    }

}

