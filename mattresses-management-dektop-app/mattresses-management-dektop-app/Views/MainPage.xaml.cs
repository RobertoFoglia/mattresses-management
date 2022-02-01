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
        private readonly IProductsService ProductsService;
        private Product SelectedProduct;
        private int PrevSelectedProductIndex;
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
                PrevSelectedProductIndex = ProductsGrid.SelectedIndex;
            }
            else
            {
                ProductsGrid.SelectedIndex = PrevSelectedProductIndex;
            }
        }

        private void SetProductDetails()
        {
            if (!(ProductsGrid.SelectedItem is Product product)) return;

            SelectedProduct = product;
            NameTextBox.Text = product.Name ?? String.Empty;

            DescriptionTextBox.Text = product.Description != null ? product.Description : String.Empty;

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

        private void ResetTheFormFields()
        {
            NameTextBox.Text = "";
            DescriptionTextBox.Text = "";
            UnitaryPriceTextBox.Text = "";
            MeasureUnitTextBox.Text = "";
        }

        private Boolean AreValidTheFields(out decimal price)
        {
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("it-IT");
            if (!decimal.TryParse(UnitaryPriceTextBox.Text, style, culture, out price))
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
                                         where product.Name.Equals(NameTextBox.Text) && (product.Id != SelectedProduct.Id ||
                                         ViewOperationModeTypes.ADDING.Equals(ViewMode))
                                         select product;

            if (productsHasTheSameName.Any())
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
            if (AreValidTheFields(out decimal price))
            {
                var productToSave = new Product
                {
                    Id = (SelectedProduct?.Id) ?? 0,
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = price,
                    MeasureUnit = MeasureUnitTextBox.Text
                };

                try
                {
                    int savedRowsCount = 0;
                    if (ViewOperationModeTypes.CHANGING.Equals(ViewMode))
                        savedRowsCount = ProductsService.Update(productToSave);
                    else // ViewOperationModeTypes.ADDING
                        savedRowsCount = ProductsService.Insert(productToSave);

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
                        var selectedIndex = ProductsGrid.SelectedIndex;
                        if (ViewOperationModeTypes.ADDING.Equals(ViewMode))
                        {
                            Products.Clear();
                            ProductsService.FindAll().ForEach(product => Products.Add(product));
                            selectedIndex = Products.IndexOf(ProductsService.FindByUniqueFieldsInAList(productToSave, Products));
                        }
                        else
                        {
                            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()).CreateMapper();
                            mapper.Map<Product, Product>(productToSave, SelectedProduct);
                        }

                        ProductsGrid.ItemsSource = null;
                        ProductsGrid.ItemsSource = Products;
                        ProductsGrid.SelectedIndex = selectedIndex;

                        EnterInTheReadingMode();
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
                        Content = "Il prodotto può non essere stato salvato.",
                        CloseButtonText = "Ok"
                    };
                    await dataErrorsDialog.ShowAsync();
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        private void TheCancelClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ViewOperationModeTypes.ADDING.Equals(ViewMode))
                ProductsGrid.SelectedIndex = PrevSelectedProductIndex;

            EnterInTheReadingMode();
        }

        private void EnterInTheReadingMode()
        {
            SetProductDetails();
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.DisableTheFormFiels(true);
            ViewMode = ViewOperationModeTypes.READING;

            if ((ProductsGrid.ItemsSource as ObservableCollection<Product>)?.Count == 0)
            {
                ResetTheFormFields();
                DeletingButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ChangingButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                DeletingButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ChangingButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void EnterInTheChangingMode()
        {
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            DisableTheFormFiels(false);
            ProductsGrid.IsReadOnly = true;
            ViewMode = ViewOperationModeTypes.CHANGING;
        }

        private void TheAddingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            EnterInTheChangingMode();
            ViewMode = ViewOperationModeTypes.ADDING;
            PrevSelectedProductIndex = ProductsGrid.SelectedIndex;
            ProductsGrid.SelectedIndex = -1;
            ResetTheFormFields();
        }

        private async void TheDeletingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ProductsService.BelongsToAMattress(ProductsGrid.SelectedItem as Product))
            {
                ContentDialog belongsToAMattressError = new ContentDialog
                {
                    Title = "Eliminazione prodotto.",
                    Content = "Non puoi eliminare il prodotto perchè appartiene ad un materasso.",
                    CloseButtonText = "OK"
                };
                await belongsToAMattressError.ShowAsync();
                return;
            }

            ContentDialog dataErrorsDialog = new ContentDialog
            {
                Title = "Eliminazione prodotto.",
                Content = "Sei sicuro di cancellare il prodotto?",
                PrimaryButtonText = "Elimina",
                CloseButtonText = "Annulla"
            };
            dataErrorsDialog.PrimaryButtonClick += OkButtonOfTheDeleting;
            await dataErrorsDialog.ShowAsync();
        }

        private void OkButtonOfTheDeleting(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ProductsService.Delete(ProductsGrid.SelectedItem as Product);
            var selectedIndex = ProductsGrid.SelectedIndex;
            Products.Remove(ProductsGrid.SelectedItem as Product);
            if (Products.Count >= selectedIndex)
            {
                ProductsGrid.SelectedIndex = selectedIndex;
            }
            else
            {
                ProductsGrid.SelectedIndex = Products.Count();
            }
            EnterInTheReadingMode();
        }
    }
}
