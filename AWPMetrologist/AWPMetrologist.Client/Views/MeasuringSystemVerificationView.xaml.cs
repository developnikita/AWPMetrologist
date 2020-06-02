using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views
{
    public sealed partial class MeasuringSystemVerificationView : UserControl
    {
        public MeasuringSystemVerificationView()
        {
            this.InitializeComponent();
            ViewModel = new MeasuringSystemVerificationViewModel();
            UpdateBindinds();
        }

        public MeasuringSystemVerificationViewModel ViewModel { get; set; }

        public void UpdateBindinds()
        {
            ViewModel.Initialize();
        }
    }
}
