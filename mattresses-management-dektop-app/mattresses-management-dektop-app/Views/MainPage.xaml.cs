using System;
using System.Collections.ObjectModel;
using mattresses_management_dektop_app.Context;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Services.Api;
using mattresses_management_dektop_app.ViewModels;
using Microsoft.Practices.Unity;
using Windows.UI.Xaml.Controls;

namespace mattresses_management_dektop_app.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            var productsService = ApplicationContext.Container.Resolve<IProductsService>();

            var collection = new ObservableCollection<Product>(productsService.FindAll());
            
            ProductsGrid.ItemsSource = collection;
        }
    }
}
