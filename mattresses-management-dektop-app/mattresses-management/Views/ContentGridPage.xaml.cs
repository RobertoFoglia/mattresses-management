using System;

using mattresses_management.ViewModels;

using Windows.UI.Xaml.Controls;

namespace mattresses_management.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel => DataContext as ContentGridViewModel;

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
