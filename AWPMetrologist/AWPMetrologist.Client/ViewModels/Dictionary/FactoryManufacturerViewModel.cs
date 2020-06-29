using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class FactoryManufacturerViewModel : CommandViewModel
    {
        public FactoryManufacturerViewModel()
        {
        }

        public void Initialize()
        {
            _factoryManufacturers = new ObservableCollection<ServiceReference.FactoryManufacturer>();
            _changedManufacturesr = new Dictionary<DataAction, List<ServiceReference.FactoryManufacturer>>();

            _changedManufacturesr.Add(DataAction.Add, new List<ServiceReference.FactoryManufacturer>());
            _changedManufacturesr.Add(DataAction.Delete, new List<ServiceReference.FactoryManufacturer>());
            _changedManufacturesr.Add(DataAction.Update, new List<ServiceReference.FactoryManufacturer>());

            _selectedItems = new List<ServiceReference.FactoryManufacturer>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetFactoryManufactirers();
            _factoryManufacturers.Clear();
            ClearChangedData();
            foreach (ServiceReference.FactoryManufacturer fm in data)
            {
                _factoryManufacturers.Add(fm);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.FactoryManufacturer manufacturer = new ServiceReference.FactoryManufacturer()
            {
                Id = id + 1,
                Factory = "По умолчанию"
            };
            _factoryManufacturers.Add(manufacturer);
            _changedManufacturesr[DataAction.Add].Add(manufacturer);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.FactoryManufacturer f in _selectedItems)
            {
                _changedManufacturesr[DataAction.Delete].Add(f);
            }
            foreach (ServiceReference.FactoryManufacturer f in _changedManufacturesr[DataAction.Delete])
            {
                _factoryManufacturers.Remove(f);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.FactoryManufacturer f in _changedManufacturesr[DataAction.Add])
            {
                var result = await Connection.Instance.AddFactoryManufacturer(f);
            }
            foreach (ServiceReference.FactoryManufacturer f in _changedManufacturesr[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteFactureManufacturer(f);
            }
            foreach (ServiceReference.FactoryManufacturer f in _changedManufacturesr[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.FactoryManufacturer f in _factoryManufacturers)
            {
                if (f.Id > max)
                {
                    max = f.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedManufacturesr.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.FactoryManufacturer> FactoryManufacturers
        {
            get
            {
                return _factoryManufacturers;
            }

            private set { }
        }

        public List<ServiceReference.FactoryManufacturer> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.FactoryManufacturer> _factoryManufacturers;
        private Dictionary<DataAction, List<ServiceReference.FactoryManufacturer>> _changedManufacturesr;
        private List<ServiceReference.FactoryManufacturer> _selectedItems;
    }
}
