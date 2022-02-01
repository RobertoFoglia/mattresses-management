using mattresses_management_dektop_app.Configurations;
using mattresses_management_dektop_app.Context;
using mattresses_management_dektop_app.ViewModels;
using Microsoft.Practices.Unity;
using Windows.UI.Xaml.Controls;

namespace mattresses_management_dektop_app.Views
{
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
        private SettingsViewModel ViewModel => DataContext as SettingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();

            DBFilePath.Text = ApplicationContext.Container.Resolve<SQLiteConfig>().DatabasePath;
        }
    }
}
