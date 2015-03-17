using MyWhiteBoard.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWhiteBoard.ViewModel
{
    public class MainViewModel
    {
        private static MainViewModel _instance { get; set; }
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();

                return _instance;
            }
        }

        public ObservableCollection<Group> Groups { get; set; }

        public MainViewModel()
        {
            _instance = this;
            Groups = new ObservableCollection<Group>();

            for (int i = 0; i < 5; i++)
            {
                Group group = new Group();
                ObservableCollection<Task> folders = new ObservableCollection<Task>();
                for (int j = 0; j < 10; j++)
                {
                    folders.Add(new Task { Name = string.Concat("Folder ", j) });
                }
                group.Title = string.Concat("Group ", i);
                group.Items = folders;
                Groups.Add(group);
            }
        }
    }
}
