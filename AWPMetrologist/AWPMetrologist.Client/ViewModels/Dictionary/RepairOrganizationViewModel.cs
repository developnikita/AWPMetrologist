using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class RepairOrganizationViewModel : CommandViewModel
    {
        public RepairOrganizationViewModel()
        {
        }

        public void Initialize()
        {
            _organizations = new ObservableCollection<ServiceReference.RepairOrganization>();
            _changedOrganizations = new Dictionary<DataAction, List<ServiceReference.RepairOrganization>>();

            _changedOrganizations.Add(DataAction.Add, new List<ServiceReference.RepairOrganization>());
            _changedOrganizations.Add(DataAction.Delete, new List<ServiceReference.RepairOrganization>());
            _changedOrganizations.Add(DataAction.Update, new List<ServiceReference.RepairOrganization>());

            _selectedItems = new List<ServiceReference.RepairOrganization>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetRepairOrganizations();
            _organizations.Clear();
            ClearChangedData();
            foreach (ServiceReference.RepairOrganization ro in data)
            {
                _organizations.Add(ro);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.RepairOrganization organization = new ServiceReference.RepairOrganization()
            {
                Id = id + 1,
                Organization = "По умолчанию"
            };
            _organizations.Add(organization);
            _changedOrganizations[DataAction.Add].Add(organization);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.RepairOrganization o in _selectedItems)
            {
                _changedOrganizations[DataAction.Delete].Add(o);
            }
            foreach (ServiceReference.RepairOrganization o in _changedOrganizations[DataAction.Delete])
            {
                _organizations.Remove(o);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.RepairOrganization o in _changedOrganizations[DataAction.Add])
            {
                var result = await Connection.Instance.AddRepairOrganization(o);
            }
            foreach (ServiceReference.RepairOrganization o in _changedOrganizations[DataAction.Delete])
            {
                var result = Connection.Instance.DeleteRepairOrganization(o);
            }
            foreach (ServiceReference.RepairOrganization o in _changedOrganizations[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.RepairOrganization o in _organizations)
            {
                if (o.Id > max)
                {
                    max = o.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedOrganizations.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.RepairOrganization> Organizations
        {
            get
            {
                return _organizations;
            }
            
            private set { }
        }

        public List<ServiceReference.RepairOrganization> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.RepairOrganization> _organizations;
        private Dictionary<DataAction, List<ServiceReference.RepairOrganization>> _changedOrganizations;
        private List<ServiceReference.RepairOrganization> _selectedItems;
    }
}
