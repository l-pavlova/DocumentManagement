using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class Document
    {
        [Map("DocGuid")]
        [ID("DocGuid")]
        public Guid DocGuid { get; set; }

        [Map("StoreDate")]
        public DateTime StoreDate { get; set; }

        [Map("DocumentSize")]
        public long Size { get; set; }

        [Map("Price")]
        public double Price { get; set; }

        [Map("Contragent")]
        public string Contragent { get; set; }

        [Map("Mail")]
        public string MailAddress { get; set; }


        [Map("Description")]
        public string Description { get; set; }

        [Map("Phone")]
        public string Phone { get; set; }

        [Map("DocumentDate")]
        [Date("DocumentDate")]
        public DateTime DocumentDate { get; set; }


        [Map("Filepath")]
        public string FilePath { get; set; }


        [Map("UserId")]
        public string UserId { get; set; }

        [Map("Cabinet")]
        public Guid Cabinet { get; set; }
        public Document()
        {

        }

        private PropertyInfo[] propertyInfos = null;

        public override string ToString()
        {

            if (propertyInfos == null)
            {
                propertyInfos = this.GetType().GetProperties();
            }

            var sb = new StringBuilder();

            foreach (var info in propertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + " " + value.ToString());
            }
            return sb.ToString();

        }


    }
}
