using System;

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
