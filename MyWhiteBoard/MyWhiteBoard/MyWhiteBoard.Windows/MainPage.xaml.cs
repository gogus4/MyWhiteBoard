using MyWhiteBoard.Common;
using MyWhiteBoard.Model;
using MyWhiteBoard.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.Live;

namespace MyWhiteBoard
{
    public sealed partial class MainPage : LayoutAwarePage
    {
        private Task draggedItem;
        private Task clickedItem;

        private static readonly string[] _scopes =
        new[] { 
        "wl.signin", 
        "wl.basic", 
        "wl.calendars", 
        "wl.calendars_update", 
        "wl.contacts_calendars", 
        "wl.events_create" };

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            listTasksViewSource.Source = MainViewModel.Instance.Groups;
            ColorSelected.Background = new SolidColorBrush(PickerColor.SelectedColor);

            listFilterUserViewSource.Source = MainViewModel.Instance.Users;
            listFilterStateViewSource.Source = MainViewModel.Instance.States;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.Groups[0].Items.Add(new Task { Detail = "Ceci est le détail de la tache à réaliser.Ceci est le détail de la tache à réaliser.", PersonAffected = MainViewModel.Instance.Users[0] });
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HiddenPage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Animation.Visibility = Visibility.Collapsed;
            HiddenPage.Visibility = Visibility.Collapsed;
            PopupConfiguration.IsOpen = false;
            PopupUpdateTask.IsOpen = false;
            PopupAddTask.IsOpen = false;
        }

        private void DisplayMenu_Click(object sender, RoutedEventArgs e)
        {
            Animation.Visibility = Visibility.Visible;
            HiddenPage.Visibility = Visibility.Visible;
        }

        private void TasksGridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            draggedItem = e.Items[0] as Task;
        }

        private void VariableSizedWrapGrid_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (draggedItem != null)
                {
                    var sourceCategory = draggedItem.Group;
                    var child = (((VariableSizedWrapGrid)sender).Children[0] as GridViewItem).Content as Task;
                    draggedItem.Group = child.Group;

                    child.Group.Items.Add(draggedItem);
                    sourceCategory.Items.Remove(draggedItem);
                    draggedItem = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Config_Click(object sender, RoutedEventArgs e)
        {
            HiddenPage.Visibility = Visibility.Visible;

            this.PopupConfiguration.VerticalOffset = 0;
            GridPopupConfiguration.Width = 500;
            GridPopupConfiguration.Height = Window.Current.Bounds.Height;
            PopupConfiguration.HorizontalOffset = Window.Current.Bounds.Width - 500;
            this.PopupConfiguration.IsOpen = true;
        }

        private void PickerColor_colorChanged(object sender, EventArgs e)
        {
            ColorSelected.Background = new SolidColorBrush(PickerColor.SelectedColor);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            PopupAddTask.IsOpen = true;
            HiddenPage.Visibility = Visibility.Visible;

            calendar();
        }

        private void ActionAddTask_Click(object sender, RoutedEventArgs e)
        {
            var userSelected = PersonTask.SelectedItem as User;

            Group group = MainViewModel.Instance.Groups.Where(x => x.Title == DayTask.SelectedValue.ToString()).FirstOrDefault();
            Task task = new Task() { Detail = LibelleTask.Text, Group = group, PersonAffected = userSelected };

            group.Items.Add(task);

            PopupAddTask.IsOpen = false;
            HiddenPage.Visibility = Visibility.Collapsed;
        }

        private void ActionUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            var group = MainViewModel.Instance.Groups.Where(x => x.Title == clickedItem.Group.Title).FirstOrDefault();
            var task = group.Items.Where(x => x.Detail == clickedItem.Detail && x.Group == group && x.PersonAffected == clickedItem.PersonAffected).FirstOrDefault();

            group.Items.Remove(task);

            var userSelected = PersonUpdateTask.SelectedItem as User;

            var newTask = new Task();
            newTask.Detail = LibelleUpdateTask.Text;
            newTask.PersonAffected = MainViewModel.Instance.Users.Where(x => x.FirstName == userSelected.FirstName && x.Name == userSelected.Name).FirstOrDefault();
            newTask.Day = DayUpdateTask.SelectedValue.ToString();

            var groupUpdated = MainViewModel.Instance.Groups.Where(x => x.Title == DayUpdateTask.SelectedValue.ToString()).FirstOrDefault();
            newTask.Group = groupUpdated;

            groupUpdated.Items.Add(newTask);

            PopupUpdateTask.IsOpen = false;
            HiddenPage.Visibility = Visibility.Collapsed;
        }

        private void VariableSizedWrapGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            clickedItem = TasksGridView.SelectedItem as Task;

            LibelleUpdateTask.Text = clickedItem.Detail;
            PersonUpdateTask.SelectedValue = clickedItem.PersonAffected;
            DayUpdateTask.SelectedValue = clickedItem.Group.Title;

            PopupUpdateTask.IsOpen = true;
            HiddenPage.Visibility = Visibility.Visible;
        }

        private void ActionAddUser_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.Users.Add(new User() { FirstName = FirstName.Text, Name = Name.Text, Color = PickerColor.SelectedColor.ToString() });
        }

        private void FilterUserList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var user = FilterUserList.SelectedItem as User;
            var groups = new ObservableCollection<Group>();

            var groupsCopy = new ObservableCollection<Group>();

            foreach (Group g in MainViewModel.Instance.Groups)
            {
                groupsCopy.Add(new Group(g.Title, g.Items));
            }

            foreach (var group in groupsCopy)
            {
                var toRemove = group.Items.Where(x => x.PersonAffected != user).ToList();

                foreach (var item in toRemove)
                    group.Items.Remove(item);

                groups.Add(group);
            }

            listTasksViewSource.Source = groups;
        }

        public async void calendar()
        {
            LiveAuthClient auth = new LiveAuthClient();
            LiveLoginResult loginResult = await auth.InitializeAsync(new string[] { "wl.basic" });
            if (loginResult.Status == LiveConnectSessionStatus.Connected)
            { }

            // Turn off the display of the connection button in the UI.
            //connectButton.Visibility = connected ? Visibility.Collapsed : Visibility.Visible;
            /*try
            {
                LiveConnectClient liveClient = new LiveConnectClient();
                LiveOperationResult operationResult =
                    await liveClient.GetAsync("calendar.8c8ce076ca27823f.9690899aeeae4e97be18cdc75b644454");
                dynamic result = operationResult.Result;
                this.infoTextBlock.Text = "Calendar name: " + result.name;
            }
            catch (LiveConnectException exception)
            {
                this.infoTextBlock.Text = "Error getting calendar info: " + exception.Message;
            }*/
        }
    }
}