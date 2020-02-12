using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView : Page, IPageWithViewModel<SettingsViewModel>
    {
        public SettingsView()
        {
            this.InitializeComponent();
        }
        
        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }
        public SettingsViewModel ViewModel { get; set; }
    }
}
