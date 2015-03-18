using MyWhiteBoard.Common;
using MyWhiteBoard.Model;
using MyWhiteBoard.View;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // create a new instance of store data
            StoreData storeData = new StoreData();
            // set the source of the GridView to be the sample data
            TasksGridView.ItemsSource = storeData.Collection;

            //TasksGridView.ContainerContentChanging += GridView_ContainerContentChanging;
            //ItemsSource.Source = MainViewModel.Instance.Groups;
            //TasksGridView.ItemsSource = MainViewModel.Instance.Groups;
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

        private void GridView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            

            /*var item = e.Items.FirstOrDefault();
            if (item == null)
                return;

            e.Data.Properties.Add("item", item);
            e.Data.Properties.Add("gridSource", sender);*/
        }

        private void GridView_Drop(object sender, DragEventArgs e)
        {
            /*object gridSource;
            e.Data.Properties.TryGetValue("gridSource", out gridSource);

            if (gridSource == sender)
                return;

            object sourceItem;
            e.Data.Properties.TryGetValue("item", out sourceItem);
            if (sourceItem == null)
                return;*/

            //_mainViewModel.SwitchItem((DemoItem)sourceItem);
        }

        private void GridView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            ItemViewer iv = args.ItemContainer.ContentTemplateRoot as ItemViewer;

            if (args.InRecycleQueue == true)
            {
                iv.ClearData();
            }
            else if (args.Phase == 0)
            {
                iv.ShowPlaceholder(args.Item as Task);

                // Register for async callback to visualize Title asynchronously
                args.RegisterUpdateCallback(ContainerContentChangingDelegate);
            }
            else if (args.Phase == 1)
            {
                iv.ShowValues();
                args.RegisterUpdateCallback(ContainerContentChangingDelegate);
            }

            // For imporved performance, set Handled to true since app is visualizing the data item
            args.Handled = true;
        }

        private TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> ContainerContentChangingDelegate
        {
            get
            {
                if (_delegate == null)
                {
                    _delegate = new TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs>(GridView_ContainerContentChanging);
                }
                return _delegate;
            }
        }
        private TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> _delegate;
    }
}
