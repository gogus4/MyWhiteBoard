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
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<State> States { get; set; }

        public MainViewModel()
        {
            _instance = this;
            Groups = new ObservableCollection<Group>();
            Users = new ObservableCollection<User>();
            States = new ObservableCollection<State>();

            Users.Add(new User() { Name = "Da Costa Oliveira", FirstName = "Diégo", Color = "Red" });
            Users.Add(new User() { Name = "Bricard", FirstName = "Emmanuel", Color = "Blue" });
            Users.Add(new User() { Name = "Grall", FirstName = "Yannick", Color = "Brown" });
            Users.Add(new User() { Name = "Flamant", FirstName = "Romain", Color = "Yellow" });

            States.Add(new State() { Libelle = "En cours", Color = "Gray" });
            States.Add(new State() { Libelle = "Terminer", Color = "Green" });
            States.Add(new State() { Libelle = "Tous",  Color = "White" });

            Group monday = new Group();
            monday.Title = "Lundi";

            Group tuesday = new Group();
            tuesday.Title = "Mardi";

            Group wednesday = new Group();
            wednesday.Title = "Mercredi";

            Group thursday = new Group();
            thursday.Title = "Jeudi";

            Group friday = new Group();
            friday.Title = "Vendredi";

            Task badBoy = new Task();
            badBoy.Detail = "Industrie 4.0";
            badBoy.PersonAffected = "Emmanuel Bricard";
            badBoy.Group = monday;
            monday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Thermibox 2";
            badBoy.PersonAffected = "Emmanuel Bricard";
            badBoy.Group = monday;
            monday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "statistiques CRM";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = tuesday;
            tuesday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "PC commercial";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = tuesday;
            tuesday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "CRM 2015";
            badBoy.PersonAffected = "Yannick Grall";
            badBoy.Group = wednesday;
            wednesday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Label ERP";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = wednesday;
            wednesday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Pavé étiquette";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = thursday;
            thursday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "Bad Boy";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = thursday;
            thursday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "E-dépanneur";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = friday;
            friday.Items.Add(badBoy);

            badBoy = new Task();
            badBoy.Detail = "GASS";
            badBoy.PersonAffected = "Diégo Da Costa Oliveira";
            badBoy.Group = friday;
            friday.Items.Add(badBoy);

            Groups.Add(monday);
            Groups.Add(tuesday);
            Groups.Add(wednesday);
            Groups.Add(thursday);
            Groups.Add(friday);
        }
    }
}