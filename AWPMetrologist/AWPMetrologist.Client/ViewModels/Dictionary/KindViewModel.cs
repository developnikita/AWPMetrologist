using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class KindViewModel : CommandViewModel
    {
        public KindViewModel()
        {
        }

        public void Initialize()
        {
            _kinds = new ObservableCollection<ServiceReference.MSKind>();
            _changedKinds = new Dictionary<DataAction, List<ServiceReference.MSKind>>();

            _changedKinds.Add(DataAction.Add, new List<ServiceReference.MSKind>());
            _changedKinds.Add(DataAction.Delete, new List<ServiceReference.MSKind>());
            _changedKinds.Add(DataAction.Update, new List<ServiceReference.MSKind>());

            _selectedItems = new List<ServiceReference.MSKind>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMSKinds();
            _kinds.Clear();
            ClearChangedData();
            foreach (ServiceReference.MSKind k in data)
            {
                _kinds.Add(k);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.MSKind kind = new ServiceReference.MSKind()
            {
                Id = id + 1,
                Kind = "По умолчанию"
            };
            _kinds.Add(kind);
            _changedKinds[DataAction.Add].Add(kind);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MSKind k in _selectedItems)
            {
                _changedKinds[DataAction.Delete].Add(k);
            }
            foreach (ServiceReference.MSKind k in _changedKinds[DataAction.Delete])
            {
                _kinds.Remove(k);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MSKind k in _changedKinds[DataAction.Add])
            {
                var result = await Connection.Instance.AddMSKind(k);
            }
            foreach (ServiceReference.MSKind k in _changedKinds[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteMSKind(k);
            }
            foreach (ServiceReference.MSKind k in _changedKinds[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.MSKind k in _kinds)
            {
                if (k.Id > max)
                {
                    max = k.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedKinds.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.MSKind> Kinds
        {
            get
            {
                return _kinds;
            }

            private set { }
        }

        public List<ServiceReference.MSKind> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.MSKind> _kinds;
        private Dictionary<DataAction, List<ServiceReference.MSKind>> _changedKinds;
        private List<ServiceReference.MSKind> _selectedItems;
    }
}
