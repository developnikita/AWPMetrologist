using AWPMetrologist.Client.Helpers;
using AWPMetrologist.Client.Services.Navigation;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationRootView : Page
    {
        public NavigationRootView()
        {
            _instance = this;
            this.InitializeComponent();

            var nav = SystemNavigationManager.GetForCurrentView();
            nav.BackRequested += Nav_BackRequested;
        }

        public void InitializeNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, System.EventArgs e)
        {
            var ignored = DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                var nav = SystemNavigationManager.GetForCurrentView();
                nav.AppViewBackButtonVisibility = _navigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            });
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_hasLoadedPreviously)
            {
                // TODO: Выбрать домашнюю страницу
                // _navigationService.NavigatedTo();
                _hasLoadedPreviously = true;
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                _navigationService.NavigateToSettingsAsync();
                return;
            }

            // NOTE: as не вызовет исключение, не повлияет ли на тестирование и отладку.
            switch (args.InvokedItemContainer.Tag as string)
            {
                case "Handbook":
                    {
                        _navigationService.NavigateToHandbookAsync();
                    } break;
                case "Accounting":
                    {
                        _navigationService.NavigateToAccountingAsync();
                    }
                    break;
                case "Verification":
                    {
                        _navigationService.NavigateToVerificationAsync();
                    }
                    break;
                case "Schedules":
                    {
                        _navigationService.NavigateToSchedulesAsync();
                    }
                    break;

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AppNavFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {

        }

        private void Nav_BackRequested(object sender, BackRequestedEventArgs e)
        {
            var ignored = _navigationService.GoBackAsync();
            e.Handled = true;
        }

        public static NavigationRootView Instance
        {
            get
            {
                return _instance;
            }
        }

        public TitleBarHelper TitleHelper
        {
            get
            {
                return TitleBarHelper.Instance;
            }
        }

        public Frame AppFrame
        {
            get
            {
                return AppNavFrame;
            }
            // NOTE: Временное решение
            set
            {
                AppNavFrame = value;
            }
        }

        private static NavigationRootView _instance;
        private INavigationService _navigationService;
        private bool _hasLoadedPreviously;
    }
}
