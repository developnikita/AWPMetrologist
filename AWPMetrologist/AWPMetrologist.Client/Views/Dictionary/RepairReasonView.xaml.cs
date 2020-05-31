using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class RepairReasonView : UserControl, IUserControlWithViewModel<RepairReasonViewModel>
    {
        public RepairReasonView()
        {
            this.InitializeComponent();
            ViewModel = new RepairReasonViewModel();
            UpdateBindings();
        }

        public RepairReasonViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems.Clear();
            foreach (ServiceReference.RepairReason r in this.DataGird.SelectedItems)
            {
                ViewModel.SelectedItems.Add(r);
            }
        }
    }
}
