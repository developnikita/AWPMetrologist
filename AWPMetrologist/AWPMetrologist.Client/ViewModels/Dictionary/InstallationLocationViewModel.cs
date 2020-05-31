using AWPMetrologist.Client.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class InstallationLocationViewModel : CommandViewModel
    {
        public InstallationLocationViewModel()
        {
        }

        public void Initialize()
        {
            _locations = new ObservableCollection<ServiceReference.InstallationLocation>();
            _changedLocations = new Dictionary<DataAction, List<ServiceReference.InstallationLocation>>();

            _changedLocations.Add(DataAction.Add, new List<ServiceReference.InstallationLocation>());
            _changedLocations.Add(DataAction.Delete, new List<ServiceReference.InstallationLocation>());
            _changedLocations.Add(DataAction.Update, new List<ServiceReference.InstallationLocation>());

            _selectedItems = new List<ServiceReference.InstallationLocation>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetInstallationLocations();
            _locations.Clear();
            ClearChangedData();
            foreach (ServiceReference.InstallationLocation il in data)
            {
                _locations.Add(il);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.InstallationLocation location = new ServiceReference.InstallationLocation()
            {
                Id = id + 1,
                Location = "По умолчанию"
            };
            _locations.Add(location);
            _changedLocations[DataAction.Add].Add(location);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.InstallationLocation l in _selectedItems)
            {
                _changedLocations[DataAction.Delete].Add(l);
            }
            foreach (ServiceReference.InstallationLocation l in _changedLocations[DataAction.Delete])
            {
                _locations.Remove(l);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.InstallationLocation l in _changedLocations[DataAction.Add])
            {
                var result = await Connection.Instance.AddInstallationLocation(l);
            }
            foreach (ServiceReference.InstallationLocation l in _changedLocations[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteInstallationLocation(l);
            }
            foreach (ServiceReference.InstallationLocation l in _changedLocations[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.InstallationLocation l in _locations)
            {
                if (l.Id > max)
                {
                    max = l.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedLocations.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.InstallationLocation> InstallationLocations
        {
            get
            {
                return _locations;
            }

            private set { }
        }

        public List<ServiceReference.InstallationLocation> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            private set { }
        }

        private ObservableCollection<ServiceReference.InstallationLocation> _locations;
        private Dictionary<DataAction, List<ServiceReference.InstallationLocation>> _changedLocations;
        private List<ServiceReference.InstallationLocation> _selectedItems;
    }
}
