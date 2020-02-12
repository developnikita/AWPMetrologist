using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HandbookMSView : Page, IPageWithViewModel<HandbookMSViewModel>
    {
        public HandbookMSView()
        {
            this.InitializeComponent();
        }

        public HandbookMSViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private async void Handbook_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.LoadMeasuringInstruments();
        }
    }
}
