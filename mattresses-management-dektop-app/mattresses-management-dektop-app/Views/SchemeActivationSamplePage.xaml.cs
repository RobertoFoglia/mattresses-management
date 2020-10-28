using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using mattresses_management_dektop_app.Constants;
using mattresses_management_dektop_app.Context;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using mattresses_management_dektop_app.ViewModels;
using Microsoft.Practices.Unity;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Views
{
    // TODO WTS: Remove this sample page when/if it's not needed.
    // This page is an sample of how to launch a specific page in response to a protocol launch and pass it a value.
    // It is expected that you will delete this page once you have changed the handling of a protocol launch to meet
    // your needs and redirected to another of your pages.
    public sealed partial class SchemeActivationSamplePage : Page
    {
        private readonly IMattressesService MattressesService;
        private readonly IProductsService ProductsService;
        private readonly IAttributesService AttributesService;

        private ViewOperationModeTypes ViewMode;

        private SchemeActivationSampleViewModel ViewModel
        {
            get { return DataContext as SchemeActivationSampleViewModel; }
        }
            
        public SchemeActivationSamplePage()
        {
            InitializeComponent();

            MattressesService = ApplicationContext.Container.Resolve<IMattressesService>();
            ProductsService = ApplicationContext.Container.Resolve<IProductsService>();
            AttributesService = ApplicationContext.Container.Resolve<IAttributesService>();

            MattressesGrid.ItemsSource = new ObservableCollection<Mattress>(MattressesService.FindAll());
            MattressesGrid.SelectedIndex = 0;
            MattressesGrid.SelectionChanged += MattressesGrid_SelectionChanged;

            EnterInTheReadingMode();
        }

        private void MattressesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameTextBox.Text = (MattressesGrid.SelectedItem as Mattress).Name;
            SetProductsOnTheSelectedMattress();
            SetAttributesOnTheSelectedMattress();
        }

        private void SetAttributesOnTheSelectedMattress()
        {
            if ((MattressesGrid.SelectedItem as Mattress).Attributes == null)
                MattressesService.SetAttributes(MattressesGrid.SelectedItem as Mattress);
            AttributesRepeater.ItemsSource = new ObservableCollection<Attribute>((MattressesGrid.SelectedItem as Mattress).Attributes);
        }

        private void SetProductsOnTheSelectedMattress() {
            if ((MattressesGrid.SelectedItem as Mattress).Products == null)
                MattressesService.SetProducts(MattressesGrid.SelectedItem as Mattress);
            ProductsGrid.ItemsSource = new ObservableCollection<Product>((MattressesGrid.SelectedItem as Mattress).Products);
        }

        private void EnterInTheReadingMode()
        {
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ProductAddingButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ViewMode = ViewOperationModeTypes.READING;
            MattressesGrid.IsReadOnly = true;
            NameTextBox.IsReadOnly = true;
        }

        private void EnterInTheChangingMode()
        {
            this.ReadingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.ChangingActionLayout.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ProductAddingButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ViewMode = ViewOperationModeTypes.CHANGING;
            MattressesGrid.IsReadOnly = false;
            NameTextBox.IsReadOnly = false;
        }

        private void TheChangingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        { }

        private void DisableTheFormFiels(bool enable)
        {
        }

        private async void TheConfirmClick(object sender, Windows.UI.Xaml.RoutedEventArgs e) { }

        private void TheCancelClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        { }

        private void TheAddingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e) { }

        private async void TheDeletingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        { }

        private void OkButtonOfTheDeleting(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        { }

        private void TheProductAddingClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
    }
