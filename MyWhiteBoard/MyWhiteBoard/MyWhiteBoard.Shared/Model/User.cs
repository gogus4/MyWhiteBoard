using System;
using System.Collections.Generic;
using System.Text;

namespace MyWhiteBoard.Model
{
    public class User
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Color { get; set; }

        public User()
        {
            
        }

        public override String ToString()
        {
            return FirstName + " " + Name;
        }
    }
}
