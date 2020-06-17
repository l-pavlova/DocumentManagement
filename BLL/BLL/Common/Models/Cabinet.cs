using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement
{
    public class Cabinet
    {
        [Map("Name")]
        [Cabinet("Name")]
        public string Name { get; set; }
        [Map("Color")]
        public string Color { get; set; }

        [Map("UserId")]
        [User("UserId")]
        public string UserId { get; set; }

        [Map("Id")]
      
        public Guid Id { get; set; }

    }
}
