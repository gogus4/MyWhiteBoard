using System;
using System.Collections.Generic;
using System.Text;

namespace MyWhiteBoard.Model
{
    public class Task
    {
        public string Day { get; set; }
        public string Detail { get; set; }
        public string PersonAffected { get; set; }
        public string Color
        {
            get
            {
                switch (PersonAffected)
                {
                    case "Diégo Da Costa Oliveira":
                        return "Red";

                    case "Emmanuel Bricard":
                        return "Blue";

                    case "Yannick Grall":
                        return "Brown";

                    default:
                        return "White";
                }
            }
            set
            {
                Color = value;
            }
        }
        public Boolean Urgent { get; set; }

        public Task()
        {
            Urgent = false;
        }
    }
}
