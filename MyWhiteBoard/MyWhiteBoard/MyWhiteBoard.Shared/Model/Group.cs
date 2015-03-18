using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace MyWhiteBoard.Model
{
    public class Group
    {
        public string Title { get; set; }
        public ObservableCollection<Task> Items { get; set; }

        public Group()
        {
            Items = new ObservableCollection<Task>();
        }
    }
}
