using System;
using System.Collections.Generic;
using System.Text;

namespace MyWhiteBoard.Model
{
    public class Task
    {
        public string Day { get; set; }

        public string Detail { get; set; }

        public User PersonAffected { get; set; }

        public Group Group { get; set; }

        public string Color
        {
            get
            {
                return PersonAffected.Color;
            }
        }
        public Boolean Urgent { get; set; }

        public Task()
        {
            Urgent = false;
        }
    }
}
