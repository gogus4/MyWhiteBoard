using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Collections;

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

        public Group(string Title, ObservableCollection<Task> Items)
        {
            this.Title = Title;
            this.Items = new ObservableCollection<Task>();

            foreach (Task task in Items)
            {
                this.Items.Add(new Task() { Day = task.Day, Detail = task.Detail, Group = task.Group, PersonAffected = task.PersonAffected, Urgent = task.Urgent });
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
