using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
// using AWPMetrologist.DataModels;
// using AWPMetrologist.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AWPMetrologist.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public event EventHandler Navigated;

        public Task NavigateToSettingsAsync()
        {
            throw new NotImplementedException();
        }

        private Dictionary<Type, NavigatedToViewModelDelegate> PageViewModels { get; }

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

        private bool _isNavigating;
    }
}