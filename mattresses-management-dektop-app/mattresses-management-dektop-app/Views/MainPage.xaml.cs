using System;

using mattresses_management_dektop_app.ViewModels;

using Windows.UI.Xaml.Controls;

namespace mattresses_management_dektop_app.Views
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
