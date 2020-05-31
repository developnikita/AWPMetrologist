using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views
{
    public sealed partial class ReferenceData : UserControl
    {
        public ReferenceData()
        {
            this.InitializeComponent();
            ViewModel = new ReferenceDataViewModel();
            UpdateBindings();
        }

        public ReferenceDataViewModel ViewModel { get; set; }


        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }
    }
}
