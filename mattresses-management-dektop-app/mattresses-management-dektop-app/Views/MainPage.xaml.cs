using AutoMapper;
using mattresses_management_dektop_app.Constants;
using mattresses_management_dektop_app.Context;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Services.Api;
using mattresses_management_dektop_app.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace mattresses_management_dektop_app.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;
        private ObservableCollection<Product> Products;
        private IProductsService ProductsService;
        private Product SelectedProduct;
        private int SelectedIndex;
        private ViewOperationModeTypes ViewMode;

        public MainPage()
        {
            InitializeComponent();

            ProductsService = ApplicationContext.Container.Resolve<IProductsService>();
            ProductsGrid.SelectionChanged += ProductsGrid_SelectionChanged;

            Products = new ObservableCollection<Product>(ProductsService.FindAll());
            ProductsGrid.ItemsSource = Products;
            ProductsGrid.SelectedIndex = 0;
            SetProductDetails();

            EnterInTheReadingMode();
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewMode.Equals(ViewOperationModeTypes.READING))
            {
                SetProductDetails();
                SelectedIndex = ProductsGrid.SelectedIndex;
            }
            else
            {
                ProductsGrid.SelectedIndex = SelectedIndex;
            }
        }

        private void SetProductDetails()
        {
            var product = (ProductsGrid.SelectedItem as Product);
            SelectedProduct = product;
            if (product.Name != null)
                NameTextBox.Text = product.Name;
            else
                NameTextBox.Text = String.Empty;

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

        private void TheChangingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EnterInTheChangingMode();
        }

        private void DisableTheFormFiels(bool enable)
        {
            NameTextBox.IsReadOnly = enable;
            DescriptionTextBox.IsReadOnly = enable;
            UnitaryPriceTextBox.IsReadOnly = enable;
            MeasureUnitTextBox.IsReadOnly = enable;
        }

        private Boolean areValidateTheFields(out Double price)
        {
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("it-IT");
            if (!Double.TryParse(UnitaryPriceTextBox.Text, style, culture, out price))
            {
                ContentDialog dataErrorsDialog = new ContentDialog
                {
                    Title = "Errore nei dati.",
                    Content = "Il campo prezzo unitario ha un formato invalido.",
                    CloseButtonText = "Ok"
                };
                dataErrorsDialog.ShowAsync();
                return false;
            }

            var productsHasTheSameName = from product in Products
                                         where product.Name.Equals(NameTextBox.Text) && product.Id != SelectedProduct.Id
                                         select product;

            if (productsHasTheSameName.Count() != 0)
            {
                ContentDialog dataErrorsDialog = new ContentDialog
                {
                    Title = "Errore nei dati.",
                    Content = "Il campo nome esiste già in tabella.",
                    CloseButtonText = "Ok"
                };
                dataErrorsDialog.ShowAsync();
                return false;
            }

            return true;
        }

        private async void TheConfirmClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Double price;
            if (areValidateTheFields(out price))
            {
                var productToSave = new Product
                {
                    Id = SelectedProduct.Id,
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = price,
                    MeasureUnit = MeasureUnitTextBox.Text
                };

                try
                {
                    var savedRowsCount = ProductsService.Update(productToSave);
                    if (savedRowsCount == 0)
                    {
                        ContentDialog dataErrorsDialog = new ContentDialog
                        {
                            Title = "Operazione conclusa in modo anomalo.",
                            Content = "Il prodotto non è stato salvato.",
                            CloseButtonText = "Ok"
                        };
                        await dataErrorsDialog.ShowAsync();
                    }
                    else
                    {
                        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()).CreateMapper();
                        mapper.Map<Product, Product>(productToSave, SelectedProduct);
                        EnterInTheReadingMode();
                        var selectedIndex = ProductsGrid.SelectedIndex;
                        ProductsGrid.ItemsSource = null;
                        ProductsGrid.ItemsSource = Products;
                        ProductsGrid.SelectedIndex = selectedIndex;
                        ContentDialog confirmDialog = new ContentDialog
                        {
                            Title = "Operazione conclusa con successo.",
                            Content = "Il prodotto è stato salvato con successo.",
                            CloseButtonText = "Ok"
                        };
                        await confirmDialog.ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    ContentDialog dataErrorsDialog = new ContentDialog
                    {
                        Title = "Operazione conclusa in modo anomalo.",
                        Content = "Il prodotto non è stato salvato.",
                        CloseButtonText = "Ok"
                    };
                    await dataErrorsDialog.ShowAsync();
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        private void TheCancelClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EnterInTheReadingMode();
        }

        private void EnterInTheReadingMode()
        {
            SetProductDetails();
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.DisableTheFormFiels(true);
            ViewMode = ViewOperationModeTypes.READING;
        }

        private void EnterInTheChangingMode()
        {
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            DisableTheFormFiels(false);
            ProductsGrid.IsReadOnly = true;
            ViewMode = ViewOperationModeTypes.CHANGING;
        }
    }
}
