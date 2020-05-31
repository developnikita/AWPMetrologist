using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels.Dictionary;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AWPMetrologist.Client.Views.Dictionary
{
    public sealed partial class CategoryView : UserControl, IUserControlWithViewModel<CategoryViewModel>
    {
        public CategoryView()
        {
            this.InitializeComponent();
            ViewModel = new CategoryViewModel();
            UpdateBindings();
        }

        public CategoryViewModel ViewModel { get; set; }

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems.Clear();
            foreach (ServiceReference.MSCategory c in this.DataGrid.SelectedItems)
            {
                ViewModel.SelectedItems.Add(c);
            }
        }
    }
}
