using System.ComponentModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;

namespace AWPMetrologist.Helpers
{
    public class TitleBarHelper : INotifyPropertyChanged
    {
        public TitleBarHelper()
        {
            _coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            _coreTitleBar.LayoutMetricsChanged += _coreTitleBar_LayoutMetricsChanged;
            _titlePosition = CalculateTitlebarOffset(_coreTitleBar.SystemOverlayLeftInset, _coreTitleBar.Height);
            _titleVisibility = Visibility.Visible;
        }

        private Thickness CalculateTitlebarOffset(double leftPosition, double heigth)
        {
            var correctHeight = heigth / 32 * 6;

            return new Thickness(leftPosition + 12, correctHeight, 0, 0);
        }

        private void _coreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            TitlePosition = CalculateTitlebarOffset(_coreTitleBar.SystemOverlayLeftInset, _coreTitleBar.Height);
        }

        public static TitleBarHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public CoreApplicationViewTitleBar TitleBar
        {
            get
            {
                return _coreTitleBar;
            }
        }

        public Thickness TitlePosition
        {
            get
            {
                return _titlePosition;
            }

            set
            {
                if (value.Left != _titlePosition.Left || value.Top != _titlePosition.Top)
                {
                    _titlePosition = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitlePosition)));
                }
            }
        }

        public Visibility TitleVisibility
        {
            get
            {
                return _titleVisibility;
            }

            set
            {
                _titleVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleVisibility)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static TitleBarHelper _instance = new TitleBarHelper();
        private static CoreApplicationViewTitleBar _coreTitleBar;
        private Thickness _titlePosition;
        private Visibility _titleVisibility;
    }
}
