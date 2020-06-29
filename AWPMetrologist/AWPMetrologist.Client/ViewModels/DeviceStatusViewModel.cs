using AWPMetrologist.Client.ServiceReference;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class DeviceStatusViewModel
    {
        public DeviceStatusViewModel()
        {

        }

        public void Initialize()
        {
            _ms = new ObservableCollection<MeasuringSystem>();
            _deviceStatus = new DeviceStatus();
            _conditions = new List<TechnicalCondition>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMeasuringSystemVerification();
            _ms.Clear();
            foreach (MeasuringSystem ms in data)
            {
                _ms.Add(ms);
            }
            var conditions = await Connection.Instance.GetTechnicalConditions();
            _conditions.Clear();
            foreach (TechnicalCondition c in conditions)
            {
                _conditions.Add(c);
            }
        }

        public void Save(object sender, RoutedEventArgs args)
        {
            _deviceStatus.MS = _selectedItem;
            var result = Connection.Instance.AddDeviceStatus(_deviceStatus);
        }

        public void SelectionChanged(object sender, RoutedEventArgs args)
        {
            MeasuringSystem ms = (MeasuringSystem)((DataGrid)sender).SelectedItem;
            _selectedItem = ms;
        }

        public ObservableCollection<MeasuringSystem> MS
        {
            get
            {
                return _ms;
            }

            private set { }
        }

        public MeasuringSystem SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }

        public DeviceStatus DeviceStatus
        {
            get
            {
                return _deviceStatus;
            }

            set
            {
                if (_deviceStatus != value)
                {
                    _deviceStatus = value;
                }
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

        private ObservableCollection<MeasuringSystem> _ms;
        private List<TechnicalCondition> _conditions;
        private MeasuringSystem _selectedItem;
        private DeviceStatus _deviceStatus;
    }
}
