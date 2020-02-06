using AWPMetrologist.Services.Navigation;
using AWPMetrologist.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountingView : Page, IPageWithViewModel<AccountingViewModel>
    {
        public AccountingView()
        {
            this.InitializeComponent();
        }

        public AccountingViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            // TODO: ViewModel init
        }
    }
}
