using MyWhiteBoard.Model;
using Windows.UI.Xaml.Controls;

namespace MyWhiteBoard.View
{
    public sealed partial class ItemViewer : UserControl
    {
        private Task _task;

        public ItemViewer()
        {
            this.InitializeComponent();
        }

        public void ShowPlaceholder(Task task)
        {
            _task = task;
        }

        /// <summary>
        /// Visualize the Title by updating the TextBlock for Title and setting Opacity
        /// to 1.
        /// </summary>
        public void ShowValues()
        {
            Detail.Text = _task.Detail;
            Person.Text = _task.PersonAffected;
        }

        /// <summary>
        /// Drop all refrences to the data item
        /// </summary>
        public void ClearData()
        {
            _task = null;
            Detail.ClearValue(TextBlock.TextProperty);
            Person.ClearValue(TextBlock.TextProperty);
        }
    }
}
