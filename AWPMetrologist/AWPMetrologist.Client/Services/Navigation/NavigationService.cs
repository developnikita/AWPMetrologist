using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using AWPMetrologist.Client.ViewModels;
using AWPMetrologist.Client.Views;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Client.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public NavigationService(IFrameAdapter frameAdapter, IComponentContext iocResolver)
        {
            Frame = frameAdapter;
            AutofacDependencyResolver = iocResolver;

            PageViewModels = new Dictionary<Type, NavigatedToViewModelDelegate>();
            RegisterPageViewModel<SettingsView, SettingsViewModel>();
            RegisterPageViewModel<AccountingView, AccountingViewModel>();
            RegisterPageViewModel<VerificationView, VerificationViewModel>();
            RegisterPageViewModel<SchedulesView, SchedulesViewModel>();
            RegisterPageViewModel<HandbookView, HandbookViewModel>();

            Frame.Navigated += Frame_Navigated;
        }

        public Task NavigateToSettingsAsync() => NavigateToPage<SettingsView>();

        public Task NavigateToAccountingAsync() => NavigateToPage<AccountingView>();

        public Task NavigateToVerificationAsync() => NavigateToPage<VerificationView>();

        public Task NavigateToSchedulesAsync() => NavigateToPage<SchedulesView>();

        public Task NavigateToHandbookAsync() => NavigateToPage<HandbookView>();

        public async Task GoBackAsync()
        {
            if (Frame.CanGoBack)
            {
                IsNavigating = true;

                Page navigatedPage = await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Frame.GoBack();
                    return Frame.Content as Page;
                });
            }
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            IsNavigating = false;
            if (PageViewModels.ContainsKey(e.SourcePageType))
            {
                var loadViewModelDelegate = PageViewModels[e.SourcePageType];
                var ignoredTask = loadViewModelDelegate(e.Content, e.Parameter, e);
            }
        }

        private void RegisterPageViewModel<TPage, TViewModel>()
            where TViewModel : class
        {
            NavigatedToViewModelDelegate navigatedTo = async (page, parameter, navArgs) =>
            {
                if (page is IPageWithViewModel<TViewModel> pageWithVM)
                {
                    pageWithVM.ViewModel = AutofacDependencyResolver.Resolve<TViewModel>();

                    if (pageWithVM.ViewModel is INavigableTo navVM)
                    {
                        await navVM.NavigatedTo(navArgs.NavigationMode, parameter);
                    }

                    pageWithVM.UpdateBindings();
                }
            };

            PageViewModels[typeof(TPage)] = navigatedTo;
        }

        /*
        private void RegisterUserControlViewModel<TUserControl, TViewModel>()
            where TViewModel : class
        {

        }
        */

        private Task NavigateToPage<TPage>()
        {
            return NavigateToPage<TPage>(parameter: null);
        }
        
        private async Task NavigateToPage<TPage>(object parameter)
        {
            if (_isNavigating)
            {
                return;
            }

            _isNavigating = true;

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Frame.Navigate(typeof(TPage), parameter: parameter);
            });
        }

        private delegate Task NavigatedToViewModelDelegate(object page, object parameter, NavigationEventArgs navigationArgs);

        public bool IsNavigating
        {
            get => _isNavigating;

            set
            {
                if (value != _isNavigating)
                {
                    _isNavigating = value;
                    IsNavigatingChanged?.Invoke(this, _isNavigating);

                    if (!_isNavigating)
                    {
                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanGoBack => Frame.CanGoBack;

        public event EventHandler<bool> IsNavigatingChanged;
        public event EventHandler Navigated;

        private IComponentContext AutofacDependencyResolver { get; }
        private IFrameAdapter Frame { get; }
        private Dictionary<Type, NavigatedToViewModelDelegate> PageViewModels { get; }

        private bool _isNavigating;
    }
}