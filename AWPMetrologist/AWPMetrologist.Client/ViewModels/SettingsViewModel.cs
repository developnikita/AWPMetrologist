using AWPMetrologist.Client.Helpers;
using AWPMetrologist.Client.Services;
using System.ComponentModel;
using System.Windows.Input;
using Windows.ApplicationModel;

namespace AWPMetrologist.Client.ViewModels
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

        /*
        public ICommand SaveIpPortCommand
        {
            get
            {
                if (_saveIpPortCommand == null)
                {
                    _saveIpPortCommand = new RelayCommand(async ())
                }
            }
        }
        */

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
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

        public string Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                if (_ip != value)
                {
                    _ip = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ip)));
                }
            }
        }

        public string Port
        {
            get
            {
                return _port;
            }

            set
            {
                if (_port != value)
                {
                    _port = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _switchThemeCommand;
        private ICommand _saveIpPortCommand;

        private ElementThemeExtended _elementTheme = ThemeSelectorService.Theme;
        private string _ip = IpAddressService.Ip;
        private string _port = IpAddressService.Port;
        private string _versionDescription;
    }
}
