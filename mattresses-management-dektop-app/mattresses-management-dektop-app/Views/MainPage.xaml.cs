using System;
using System.Collections.ObjectModel;
using System.Linq;
using mattresses_management_dektop_app.Context;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Services.Api;
using mattresses_management_dektop_app.ViewModels;
using Microsoft.Practices.Unity;
using Windows.Foundation.Metadata;
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
            ProductsGrid.SelectedIndex = 0;

            SetProductDetails();
            ProductsGrid.SelectionChanged += ProductsGrid_SelectionChanged;
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetProductDetails();
        }

        private void SetProductDetails()
        {
            var product = (ProductsGrid.SelectedItem as Product);
            NameTextBox.Text = product.Name;
            if (product.Description != null)
                DescriptionTextBox.Text = product.Description;
            else
                DescriptionTextBox.Text = String.Empty;

            UnitaryPriceTextBox.Text = product.Price.ToString();
            if (product.MeasureUnit != null)
                MeasureUnitTextBox.Text = product.MeasureUnit;
            else
                DescriptionTextBox.Text = String.Empty;
        }
    }
}
