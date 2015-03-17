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
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            ItemsSource.Source = MainViewModel.Instance.Groups;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.Groups[0].Items.Add(new Task { Detail = "Ceci est le détail de la tache à réaliser.Ceci est le détail de la tache à réaliser." , PersonAffected = "Diégo Da Costa Oliveira" });

        }
    }
}
