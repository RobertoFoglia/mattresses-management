using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using mattresses_management_dektop_app.Activation;
using mattresses_management_dektop_app.Configurations;
using mattresses_management_dektop_app.Core.Logging;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Services.Api;
using mattresses_management_dektop_app.Services;
using mattresses_management_dektop_app.Views;

using Microsoft.Practices.Unity;

using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;
using Serilog;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Log = mattresses_management_dektop_app.Core.Logging.Log;

namespace mattresses_management_dektop_app
{
    [Windows.UI.Xaml.Data.Bindable]
    public sealed partial class App : PrismUnityApplication
    {

        private static readonly Log LOG = LogFactory.CreateNewIstance(typeof(App));

        public static IUnityContainer IOCContainer { get { return App._container; } }
        private static IUnityContainer _container;
        public App()
        {
            InitializeComponent();
            UnhandledException += OnAppUnhandledException;
    }

        protected override void ConfigureContainer()
        {
            LoggerConfigurator.Initialization();
            // register a singleton using Container.RegisterType<IInterface, Type>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();
            App._container = Container;
            Container.RegisterType<ILiveTileService, LiveTileService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IToastNotificationsService, ToastNotificationsService>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));

            new RepositoriesConfig(Container);
            new ServiceConfig(Container);
            LOG.Information("Dependency injections are configured");
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            await LaunchApplicationAsync(PageTokens.MainPage, null);
        }

        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
            await ThemeSelectorService.SetRequestedThemeAsync();
            NavigationService.Navigate(page, launchParam);
            Window.Current.Activate();
            Container.Resolve<ILiveTileService>().SampleUpdate();
            //Container.Resolve<IToastNotificationsService>().ShowToastNotificationSample();

            // TODO WTS: This is a sample to demonstrate how to add a UserActivity. Please adapt and move this method call to where you consider convenient in your app.
            await UserActivityService.AddSampleUserActivity();
        }

        protected override async Task OnActivateApplicationAsync(IActivatedEventArgs args)
        {
            if (args.Kind == ActivationKind.ToastNotification && args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Handle a toast notification here
                // Since dev center, toast, and Azure notification hub will all active with an ActivationKind.ToastNotification
                // you may have to parse the toast data to determine where it came from and what action you want to take
                // If the app isn't running then launch the app here
                await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
            }

            // By default, this handler expects URIs of the format 'wtsapp:sample?paramName1=paramValue1&paramName2=paramValue2'
            if (args.Kind == ActivationKind.Protocol && args is ProtocolActivatedEventArgs protocolArgs && protocolArgs.Uri != null)
            {
                // Create data from activation Uri in ProtocolActivatedEventArgs
                var data = new SchemeActivationData(protocolArgs.Uri);
                if (data.IsValid)
                {
                    await LaunchApplicationAsync(data.PageToken, data.Parameters);
                }
                else if (args.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    // If the app isn't running and not navigating to a specific page based on the URI, navigate to the home page
                    await OnLaunchApplicationAsync(args as LaunchActivatedEventArgs);
                }
            }

        }

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await base.OnInitializeAsync(args);
            await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);

            // We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
            // gain better code reuse with other frameworks and pages within Windows Template Studio
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "mattresses_management_dektop_app.ViewModels.{0}ViewModel, mattresses_management_dektop_app", viewType.Name.Substring(0, viewType.Name.Length - 4));
                return Type.GetType(viewModelTypeName);
            });
            await WindowManagerService.Current.InitializeAsync();
            await Container.Resolve<ILiveTileService>().EnableQueueAsync().ConfigureAwait(false);
        }

        protected override IDeviceGestureService OnCreateDeviceGestureService()
        {
            var service = base.OnCreateDeviceGestureService();
            service.UseTitleBarBackButton = false;
            return service;
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        public void SetNavigationFrame(Frame frame)
        {
            var sessionStateService = Container.Resolve<ISessionStateService>();
            CreateNavigationService(new FrameFacadeAdapter(frame), sessionStateService);
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = Container.Resolve<ShellPage>();
            shell.SetRootFrame(rootFrame);
            return shell;
        }
    }
}
