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

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            listTasksViewSource.Source = MainViewModel.Instance.Groups;
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
    }
}
