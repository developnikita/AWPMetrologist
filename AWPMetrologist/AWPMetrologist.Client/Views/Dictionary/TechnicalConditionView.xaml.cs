using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class TechnicalConditionView : UserControl, IUserControlWithViewModel<TechnicalConditionViewModel>
    {
        public TechnicalConditionView()
        {
            this.InitializeComponent();
            ViewModel = new TechnicalConditionViewModel();
            UpdateBindings();
        }

        public TechnicalConditionViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems.Clear();
            foreach (ServiceReference.TechnicalCondition c in this.DataGrid.SelectedItems)
            {
                ViewModel.SelectedItems.Add(c);
            }
        }
    }
}
