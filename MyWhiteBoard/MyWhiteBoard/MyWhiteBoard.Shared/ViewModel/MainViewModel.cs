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

            Group novel = new Group();
            novel.Title = "Lundi";

            Group fairyTale = new Group();
            fairyTale.Title = "Mardi";

            Group management = new Group();
            management.Title = "Mercredi";

            Group computerScience = new Group();
            computerScience.Title = "Jeudi";

            Group vendredi = new Group();
            vendredi.Title = "Vendredi";

            Task badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Emmanuel Bricard";
            badBoy.Group = novel;
            novel.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Emmanuel Bricard";
            badBoy.Group = novel;
            novel.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = fairyTale;
            fairyTale.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = fairyTale;
            fairyTale.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = management;
            management.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = management;
            management.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = computerScience;
            computerScience.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = computerScience;
            computerScience.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = vendredi;
            vendredi.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = vendredi;
            vendredi.Items.Add(badBoy);

            Groups.Add(novel);
            Groups.Add(fairyTale);
            Groups.Add(management);
            Groups.Add(computerScience);
            Groups.Add(vendredi);

            /*for (int i = 0; i < 5; i++)
            {
                Group group = new Group();
                ObservableCollection<Task> folders = new ObservableCollection<Task>();
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                        folders.Add(new Task { Detail = "Bug E-dépanneur.", PersonAffected = "Diégo Da Costa Oliveira" });

                    else if (j == 1)
                        folders.Add(new Task { Detail = "Bug E-dépanneur.", PersonAffected = "Emmanuel Bricard" });
                    else
                        folders.Add(new Task { Detail = "Bug E-dépanneur.", PersonAffected = "Yannick Grall" });
                }

                String day = "";

                switch (i)
                {
                    case 0:
                        day = "Lundi";
                        break;
                    case 1:
                        day = "Mardi";
                        break;
                    case 2:
                        day = "Mercredi";
                        break;
                    case 3:
                        day = "Jeudi";
                        break;
                    case 4:
                        day = "Vendredi";
                        break;
                }

                group.Title = string.Concat(day);
                group.Items = folders;
                Groups.Add(group);*/


        }
    }
}