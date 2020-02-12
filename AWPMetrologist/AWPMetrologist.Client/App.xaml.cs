using System;
using System.Threading.Tasks;
using Autofac;
using AWPMetrologist.Client.Services;
using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using AWPMetrologist.Client.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Client
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        public NavigationRootView GetNavigationRoot()
        {
            if (Window.Current.Content is NavigationRootView)
            {
                return Window.Current.Content as NavigationRootView;
            }
            else if (Window.Current.Content is Frame)
            {
                return ((Frame)Window.Current.Content).Content as NavigationRootView;
            }

            throw new Exception("Window content is unknown type");
        }

        public Frame GetFrame()
        {
            var root = GetNavigationRoot();
            return root.AppFrame;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            await InitializeAsync();
            InitWindow(skipWindowCreation: e.PrelaunchActivated);

            await StartUpAsync();
        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            await InitializeAsync();
            InitWindow(skipWindowCreation: false);

            if (args.Kind == ActivationKind.Protocol)
            {
                Window.Current.Activate();

                await StartUpAsync();
            }
        }

        private void InitWindow(bool skipWindowCreation)
        {
            var builder = new ContainerBuilder();

            rootPage = Window.Current.Content as NavigationRootView;
            bool initApp = rootPage == null && !skipWindowCreation;

            if (initApp)
            {
                rootPage = new NavigationRootView();

                FrameAdapter adapter = new FrameAdapter(rootPage.AppFrame);

                builder.RegisterInstance(adapter)
                    .AsImplementedInterfaces();

                builder.RegisterType<SettingsViewModel>();
                builder.RegisterType<AccountingViewModel>();
                builder.RegisterType<SchedulesViewModel>();
                builder.RegisterType<VerificationViewModel>();
                builder.RegisterType<HandbookMSViewModel>();

                builder.RegisterType<NavigationService>()
                    .AsImplementedInterfaces()
                    .SingleInstance();

                _container = builder.Build();
                rootPage.InitializeNavigationService(_container.Resolve<INavigationService>());

                adapter.NavigationFailed += OnNavigationFailed;

                Window.Current.Content = rootPage;

                Window.Current.Activate();
            }
        }

        private async Task InitializeAsync()
        {
            await ThemeSelectorService.InitializeAsync();
            await Task.CompletedTask;
        }

        private async Task StartUpAsync()
        {
            ThemeSelectorService.SetRequestedTheme();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private IContainer _container;
        private BackgroundTaskDeferral appServiceDeferral;
        private NavigationRootView rootPage;
    }
}
