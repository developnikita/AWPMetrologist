using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class InstallationLocationView : UserControl, IUserControlWithViewModel<InstallationLocationViewModel>
    {
        public InstallationLocationView()
        {
            this.InitializeComponent();
            ViewModel = new InstallationLocationViewModel();
            UpdateBindings();
        }

        public InstallationLocationViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems.Clear();
            foreach (ServiceReference.InstallationLocation l in this.DataGrid.SelectedItems)
            {
                ViewModel.SelectedItems.Add(l);
            }
        }
    }
}
