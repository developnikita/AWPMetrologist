using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RepairMeasuringSystemView : Page, IPageWithViewModel<RepairMeasuringSystemViewModel>
    {
        public RepairMeasuringSystemView()
        {
            this.InitializeComponent();
        }

        public RepairMeasuringSystemViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }
    }
}
