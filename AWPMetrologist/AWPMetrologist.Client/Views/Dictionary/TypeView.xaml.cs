using AWPMetrologist.Client.ServiceReference;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class TypeView : UserControl
    {
        public TypeView()
        {
            this.InitializeComponent();
            ViewModel = new TypeViewModel();
            UpdateBindings();
        }

        public TypeViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems.Clear();
            foreach (MSType c in this.DataGrid.SelectedItems)
            {
                ViewModel.SelectedItems.Add(c);
            }
        }
    }
}
