using AWPMetrologist.Services;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;

namespace AWPMetrologist.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementThemeExtended>(
                        async (param) =>
                        {
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public ElementThemeExtended ElementThemeExtended
        {
            get
            {
                return _elementTheme;
            }

            set
            {
                if (_elementTheme != value)
                {
                    _elementTheme = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ElementThemeExtended)));
                }
            }
        }

        public string VersionDescription
        {
            get
            {
                return _versionDescription;
            }

            set
            {
                if (_versionDescription != value)
                {
                    _versionDescription = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VersionDescription)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ElementThemeExtended _elementTheme = ThemeSelectorService.Theme;
        private string _versionDescription;
        private ICommand _switchThemeCommand;
        // TODO: Command for save ip:port.
    }
}
