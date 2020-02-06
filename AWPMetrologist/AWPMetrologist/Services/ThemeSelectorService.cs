using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace AWPMetrologist.Services
{
    public static class ThemeSelectorService
    {

        public static ElementTheme TrueTheme()
        {
            var frameworkElement = Window.Current.Content as FrameworkElement;
            return frameworkElement.ActualTheme;
        }

        // TODO: Для добавления красоты.
        public static Style GetHomeBackground()
        {
            return null;
        }

        public static ElementTheme GetHomeTheme()
        {
            if (Theme == ElementThemeExtended.Custom)
            {
                return ElementTheme.Light;
            }

            return TrueTheme();
        }

        /*
        public static string GetHomeImageSource()
        {
            return "";
        }
        */

        public static string GetLogoSource()
        {
            if (Theme == ElementThemeExtended.Dark)
            {
                return "ms-appx:///Assets/AWPMetDarkTheme.svg";
            }

            return "ms-appx:///Assets/AWPMet.svg";
        }

        public static void SetRequestedTheme()
        {
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                ElementTheme trueTheme;

                if (Theme == ElementThemeExtended.Custom)
                {
                    if (Application.Current.Resources.MergedDictionaries.Contains(_stockTheme))
                    {
                        Application.Current.Resources.MergedDictionaries.Remove(_stockTheme);
                    }

                    Application.Current.Resources.MergedDictionaries.Add(_customTheme);

                    trueTheme = ElementTheme.Dark;

                    if (frameworkElement.RequestedTheme == ElementTheme.Dark)
                    {
                        frameworkElement.RequestedTheme = ElementTheme.Light;
                    }
                }
                else
                {
                    if (Application.Current.Resources.MergedDictionaries.Contains(_customTheme))
                    {
                        Application.Current.Resources.MergedDictionaries.Remove(_customTheme);
                    }

                    if (!Application.Current.Resources.MergedDictionaries.Contains(_stockTheme))
                    {
                        Application.Current.Resources.MergedDictionaries.Add(_stockTheme);
                    }

                    trueTheme = (ElementTheme)Theme;

                    if (frameworkElement.RequestedTheme == ElementTheme.Dark)
                    {
                        frameworkElement.RequestedTheme = ElementTheme.Light;
                    }
                }

                frameworkElement.RequestedTheme = trueTheme;
            }

            SetupTitlebar();
        }

        public static async Task SetThemeAsync(ElementThemeExtended theme)
        {
            Theme = theme;

            SetRequestedTheme();
            await SaveThemeInSettingsAsync(Theme);

            OnThemeChanged(null, Theme);
        }

        public static async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync();
        }

        public static string GetSystemControlForgroundColorForThemeHex()
        {
            if (TrueTheme() == ElementTheme.Dark)
            {
                return "#FFFFFF";
            }
            else
            {
                return "#000000";
            }
        }

        private static void SetupTitlebar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Colors.Transparent;
                    if (TrueTheme() == ElementTheme.Dark)
                    {
                        titleBar.ButtonForegroundColor = Colors.White;
                        titleBar.ForegroundColor = Colors.White;
                    }
                    else
                    {
                        titleBar.ButtonForegroundColor = Colors.Black;
                        titleBar.ForegroundColor = Colors.Black;
                    }

                    titleBar.BackgroundColor = Colors.Black;

                    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                    titleBar.ButtonInactiveForegroundColor = Colors.LightGray;

                    CoreApplicationViewTitleBar coreTitlebar = TitleBarHelper.Instance.TitleBar;

                    coreTitlebar.ExtendViewIntoTitleBar = true;
                }
            }
        }

        private static async Task<ElementThemeExtended> LoadThemeFromSettingsAsync()
        {
            ElementThemeExtended cacheTheme = ElementThemeExtended.Default;
            string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);

            if (!string.IsNullOrEmpty(themeName))
            {
                Enum.TryParse(themeName, out cacheTheme);
            }

            return cacheTheme;
        }

        private static async Task SaveThemeInSettingsAsync(ElementThemeExtended theme)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString());
        }

        public static ElementThemeExtended Theme { get; set; } = ElementThemeExtended.Default;

        public static event EventHandler<ElementThemeExtended> OnThemeChanged = (sender, args) => { };

        private static ResourceDictionary _customTheme = new ResourceDictionary { Source = new Uri("ms-appx:///Themes/Branded.xaml", UriKind.Absolute) };
        private static ResourceDictionary _stockTheme = new ResourceDictionary { Source = new Uri("ms-appx:///Theme/Stock.xaml", UriKind.Absolute) };

        private const string SettingsKey = "RequestedTheme";
    }
}
