using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views
{
    public sealed partial class DeviceStatusView : UserControl
    {
        public DeviceStatusView()
        {
            this.InitializeComponent();
            ViewModel = new DeviceStatusViewModel();
            UpdateBindings();
        }

        public DeviceStatusViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }
    }
}
