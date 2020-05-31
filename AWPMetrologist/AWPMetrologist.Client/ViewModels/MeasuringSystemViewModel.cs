using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class MeasuringSystemViewModel
    {
        public MeasuringSystemViewModel()
        {

        }

        public void Initialize()
        {
            _measuringSystems = new ObservableCollection<ServiceReference.MeasuringSystem>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetHandbookMeasuringSystem();
            _measuringSystems.Clear();
            foreach (ServiceReference.MeasuringSystem ms in data)
            {
                _measuringSystems.Add(ms);
            }
        }

        public ObservableCollection<ServiceReference.MeasuringSystem> MS
        {
            get
            {
                return _measuringSystems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.MeasuringSystem> _measuringSystems;
    }
}
