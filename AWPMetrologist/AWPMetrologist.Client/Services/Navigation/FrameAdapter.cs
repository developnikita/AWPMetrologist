using System;
using AWPMetrologist.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Services.Navigation
{
    public class FrameAdapter : IFrameAdapter
    {

        public FrameAdapter(Frame internalFrame)
        {
            _internalFrame = internalFrame;
        }

        public string GetNavigationState() => _internalFrame.GetNavigationState();

        public void SetNavigationState(string navigationState) => _internalFrame.SetNavigationState(navigationState);

        public void GoBack() => _internalFrame.GoBack();

        public void GoForward() => _internalFrame.GoForward();

        public bool Navigate(Type sourcePageType, object parameter)
        {
            // TODO: Добавить возможность навигации с анимацией.
            return _internalFrame.Navigate(sourcePageType, parameter);
        }

        public bool IsNavigating { get; private set; }
        public object Content => _internalFrame.Content;
        public bool CanGoBack => _internalFrame.CanGoBack;
        public bool CanGoForward => _internalFrame.CanGoForward;

        public event NavigatedEventHandler Navigated { add => _internalFrame.Navigated += value; remove => _internalFrame.Navigated -= value; }
        public event NavigatingCancelEventHandler Navigating { add => _internalFrame.Navigating += value; remove => _internalFrame.Navigating -= value; }
        public event NavigationFailedEventHandler NavigationFailed { add => _internalFrame.NavigationFailed += value; remove => _internalFrame.NavigationFailed -= value; }
        public event NavigationStoppedEventHandler NavigationStopped { add => _internalFrame.NavigationStopped += value; remove => _internalFrame.NavigationStopped -= value; }

        private Frame _internalFrame;
    }
}