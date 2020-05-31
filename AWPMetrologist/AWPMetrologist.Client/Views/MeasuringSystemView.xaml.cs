using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views
{
    public sealed partial class MeasuringSystemView : UserControl
    {
        public MeasuringSystemView()
        {
            this.InitializeComponent();
            ViewModel = new MeasuringSystemViewModel();
            UpdateBindings();
        }

        public MeasuringSystemViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }
    }
}
