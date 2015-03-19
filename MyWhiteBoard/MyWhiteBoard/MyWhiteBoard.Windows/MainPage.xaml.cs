using MyWhiteBoard.Common;
using MyWhiteBoard.Model;
using MyWhiteBoard.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyWhiteBoard
{
    public sealed partial class MainPage : LayoutAwarePage
    {
        private Task draggedItem;
        private Task clickedItem;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            listTasksViewSource.Source = MainViewModel.Instance.Groups;
            ColorSelected.Background = new SolidColorBrush(PickerColor.SelectedColor);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.Groups[0].Items.Add(new Task { Detail = "Ceci est le détail de la tache à réaliser.Ceci est le détail de la tache à réaliser.", PersonAffected = "Diégo Da Costa Oliveira" });
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HiddenPage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowStoryboard.Stop();
            Animation.Visibility = Visibility.Collapsed;
            HiddenPage.Visibility = Visibility.Collapsed;
            PopupConfiguration.IsOpen = false;
            PopupUpdateTask.IsOpen = false;
        }

        private void DisplayMenu_Click(object sender, RoutedEventArgs e)
        {
            Animation.Visibility = Visibility.Visible;
            HiddenPage.Visibility = Visibility.Visible;
            ShowStoryboard.Begin();
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
        }

        private void ActionAddTask_Click(object sender, RoutedEventArgs e)
        {
            Group group = MainViewModel.Instance.Groups.Where(x => x.Title == DayTask.SelectedValue.ToString()).FirstOrDefault();
            Task task = new Task() { Detail = LibelleTask.Text, Group = group, PersonAffected = PersonTask.SelectedValue.ToString() };

            group.Items.Add(task);

            PopupAddTask.IsOpen = false;
            HiddenPage.Visibility = Visibility.Collapsed;
        }

        private void TasksGridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            clickedItem = TasksGridView.SelectedItem as Task;

            LibelleUpdateTask.Text = clickedItem.Detail;
            PersonUpdateTask.SelectedValue = clickedItem.PersonAffected;
            DayUpdateTask.SelectedValue = clickedItem.Group.Title;

            PopupUpdateTask.IsOpen = true;
            HiddenPage.Visibility = Visibility.Visible;
        }

        private void ActionUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            // A MODIFIER

            var group = MainViewModel.Instance.Groups.Where(x => x.Title == clickedItem.Group.Title).FirstOrDefault();
            var task = group.Items.Where(x => x.Detail == clickedItem.Detail && x.Group == group && x.PersonAffected == clickedItem.PersonAffected).FirstOrDefault();

            task.Detail = LibelleUpdateTask.Text;
            task.PersonAffected = PersonUpdateTask.SelectedValue.ToString();
            task.Day = DayUpdateTask.SelectedValue.ToString();

            var groupUpdated = MainViewModel.Instance.Groups.Where(x => x.Title == DayUpdateTask.SelectedValue.ToString()).FirstOrDefault();

            task.Group = groupUpdated;

            PopupUpdateTask.IsOpen = false;
            HiddenPage.Visibility = Visibility.Collapsed;
        }
    }
}