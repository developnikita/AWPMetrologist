using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class MeasuredParameterView : UserControl, IUserControlWithViewModel<MeasuredParameterViewModel>
    {
        public MeasuredParameterView()
        {
            this.InitializeComponent();
            ViewModel = new MeasuredParameterViewModel();
            UpdateBindings();
        }

        public MeasuredParameterViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItem.Clear();
            foreach (ServiceReference.MeasuredParameter p in this.DataGrid.SelectedItems)
            {
                ViewModel.SelectedItem.Add(p);
            }
        }
    }
}
