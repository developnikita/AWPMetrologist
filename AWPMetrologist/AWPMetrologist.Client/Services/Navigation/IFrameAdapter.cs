﻿using System;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Client.Services.Navigation
{
    public interface IFrameAdapter
    {
        event NavigatedEventHandler Navigated;

        event NavigatingCancelEventHandler Navigating;

        event NavigationFailedEventHandler NavigationFailed;

        event NavigationStoppedEventHandler NavigationStopped;

        object Content { get; }

        bool CanGoBack { get; }

        bool CanGoForward { get; }

        string GetNavigationState();

        void GoBack();

        void GoForward();

        bool Navigate(Type sourcePageType, object parameter);

        void SetNavigationState(string navigationState);
    }
}