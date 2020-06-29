using Autofac.Core;
using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class MeasuredParameterViewModel : CommandViewModel
    {
        public MeasuredParameterViewModel()
        {
        }

        public void Initialize()
        {
            _parameters = new ObservableCollection<ServiceReference.MeasuredParameter>();
            _changedParameters = new Dictionary<DataAction, List<ServiceReference.MeasuredParameter>>();

            _changedParameters.Add(DataAction.Add, new List<ServiceReference.MeasuredParameter>());
            _changedParameters.Add(DataAction.Delete, new List<ServiceReference.MeasuredParameter>());
            _changedParameters.Add(DataAction.Update, new List<ServiceReference.MeasuredParameter>());

            _selectedItems = new List<ServiceReference.MeasuredParameter>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMeasuredParameters();
            _parameters.Clear();
            ClearChangedData();
            foreach (ServiceReference.MeasuredParameter mp in data)
            {
                _parameters.Add(mp);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.MeasuredParameter parameter = new ServiceReference.MeasuredParameter()
            {
                Id = id + 1,
                Parameter = "По умолчанию"
            };
            _parameters.Add(parameter);
            _changedParameters[DataAction.Add].Add(parameter);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MeasuredParameter p in _selectedItems)
            {
                _changedParameters[DataAction.Delete].Add(p);
            }
            foreach (ServiceReference.MeasuredParameter p in _changedParameters[DataAction.Delete])
            {
                _parameters.Remove(p);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MeasuredParameter p in _changedParameters[DataAction.Add])
            {
                var result = await Connection.Instance.AddMeasuredParameter(p);
            }
            foreach (ServiceReference.MeasuredParameter p in _changedParameters[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteMeasuredParameter(p);
            }
            foreach (ServiceReference.MeasuredParameter p in _changedParameters[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.MeasuredParameter p in _parameters)
            {
                if (p.Id > max)
                {
                    max = p.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedParameters.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.MeasuredParameter> Parameters
        {
            get
            {
                return _parameters;
            }

            private set { }
        }

        public List<ServiceReference.MeasuredParameter> SelectedItem
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.MeasuredParameter> _parameters;
        private Dictionary<DataAction, List<ServiceReference.MeasuredParameter>> _changedParameters;
        private List<ServiceReference.MeasuredParameter> _selectedItems;
    }
}
