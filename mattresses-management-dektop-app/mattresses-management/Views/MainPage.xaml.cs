using System;

using mattresses_management.ViewModels;

using Windows.UI.Xaml.Controls;

namespace mattresses_management.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
