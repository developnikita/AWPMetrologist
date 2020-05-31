using AWPMetrologist.Client.Services.Navigation;
using AWPMetrologist.Client.ViewModels;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AWPMetrologist.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HandbookView : Page, IPageWithViewModel<HandbookViewModel>, INotifyPropertyChanged
    {
        public HandbookView()
        {
            this.InitializeComponent();
            ReferenceData = new ReferenceData();
            ReferenceData.UpdateBindings();
        }

        public HandbookViewModel ViewModel { get; set; }

        public ReferenceData ReferenceData { get; set; }

        public Visibility V { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateBindings()
        {
            ViewModel.Initialize();
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReferenceData.ViewModel.ControlViewModel.Add(sender, e);
        }

        private void AppBarButton_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReferenceData.ViewModel.ControlViewModel.Save(sender, e);
        }

        private void AppBarButton_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ReferenceData.ViewModel.ControlViewModel.Delete(sender, e);
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot p = (Pivot)sender;
            PivotItem item = (PivotItem)p.SelectedItem;
            switch (item.Header)
            {
                case "Системы измерения":
                    V = Visibility.Collapsed;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(V)));
                    break;
                case "Справочные данные":
                    V = Visibility.Visible;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(V)));
                    break;
            }
        }
    }
}
