using AWPMetrologist.Client.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class StorageViewModel : CommandViewModel
    {
        public StorageViewModel()
        {
        }

        public void Initialize()
        {
            _storages = new ObservableCollection<ServiceReference.Storage>();
            _changedStorage = new Dictionary<DataAction, List<ServiceReference.Storage>>();

            _changedStorage.Add(DataAction.Add, new List<ServiceReference.Storage>());
            _changedStorage.Add(DataAction.Delete, new List<ServiceReference.Storage>());
            _changedStorage.Add(DataAction.Update, new List<ServiceReference.Storage>());

            _selectedItems = new List<ServiceReference.Storage>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetStorages();
            _storages.Clear();
            ClearChangedData();
            foreach (ServiceReference.Storage s in data)
            {
                _storages.Add(s);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.Storage storage = new ServiceReference.Storage()
            {
                Id = id + 1,
                StorageValue = "По умолчанию"
            };
            _storages.Add(storage);
            _changedStorage[DataAction.Add].Add(storage);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.Storage s in _selectedItems)
            {
                _changedStorage[DataAction.Delete].Add(s);
            }
            foreach (ServiceReference.Storage s in _changedStorage[DataAction.Delete])
            {
                _storages.Remove(s);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.Storage s in _changedStorage[DataAction.Add])
            {
                var resut = await Connection.Instance.AddStorage(s);
            }
            foreach (ServiceReference.Storage s in _changedStorage[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteStorage(s);
            }
            foreach (ServiceReference.Storage s in _changedStorage[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.Storage s in _storages)
            {
                if (s.Id > max)
                {
                    max = s.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedStorage.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.Storage> Storages
        {
            get
            {
                return _storages;
            }

            private set { }
        }

        public List<ServiceReference.Storage> SelectedItems
        {
            get 
            { 
                return _selectedItems; 
            }

            private set { }
        }


        private ObservableCollection<ServiceReference.Storage> _storages;
        private Dictionary<DataAction, List<ServiceReference.Storage>> _changedStorage;
        private List<ServiceReference.Storage> _selectedItems;
    }
}
