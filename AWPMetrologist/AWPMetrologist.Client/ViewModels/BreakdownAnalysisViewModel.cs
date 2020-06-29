using AWPMetrologist.Client.DataModels;
using AWPMetrologist.Client.ServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class BreakdownAnalysisViewModel
    {
        public BreakdownAnalysisViewModel()
        {
        }

        public void Initialize()
        {
            _conditions = new List<TechnicalCondition>();
            _types = new List<MSType>();
            _deviceStatuses = new ObservableCollection<DeviceStatus>();
            _analyzs = new ObservableCollection<Analyz>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var conditions = await Connection.Instance.GetTechnicalConditions();
            _conditions.Clear();
            foreach (TechnicalCondition c in conditions)
            {
                _conditions.Add(c);
            }
            var types = await Connection.Instance.GetMSTypes();
            _types.Clear();
            foreach (MSType t in types)
            {
                _types.Add(t);
            }
        }

        public async void Click(object sender, RoutedEventArgs args)
        {
            var devicesStatuses = await Connection.Instance.GetDeviceStatusesForAnalyz(SelectedType, SelectedCondition);
            _deviceStatuses.Clear();
            foreach (DeviceStatus ds in devicesStatuses)
            {
                _deviceStatuses.Add(ds);
            }
        }

        public List<TechnicalCondition> Conditions
        {
            get
            {
                return _conditions;
            }

            private set { }
        }

        public List<MSType> Types
        {
            get
            {
                return _types;
            }

            private set { }
        }

        public MSType SelectedType { get; set; }
        public TechnicalCondition SelectedCondition { get; set; }

        private List<TechnicalCondition> _conditions;
        private List<MSType> _types;
        private ObservableCollection<DeviceStatus> _deviceStatuses;
        private ObservableCollection<Analyz> _analyzs;
    }
}
