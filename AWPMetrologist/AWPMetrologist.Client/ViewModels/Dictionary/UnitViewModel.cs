using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class UnitViewModel : CommandViewModel
    {
        public UnitViewModel()
        {
        }

        public void Initialize()
        {
            _units = new ObservableCollection<ServiceReference.Unit>();
            _changedUnits = new Dictionary<DataAction, List<ServiceReference.Unit>>();

            _changedUnits.Add(DataAction.Add, new List<ServiceReference.Unit>());
            _changedUnits.Add(DataAction.Delete, new List<ServiceReference.Unit>());
            _changedUnits.Add(DataAction.Update, new List<ServiceReference.Unit>());

            _selectedIems = new List<ServiceReference.Unit>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetUnits();
            _units.Clear();
            ClearChangedData();
            foreach (ServiceReference.Unit u in data)
            {
                _units.Add(u);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.Unit unit = new ServiceReference.Unit()
            {
                Id = id + 1,
                UnitValue = "По умолчанию"
            };
            _units.Add(unit);
            _changedUnits[DataAction.Add].Add(unit);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.Unit u in _selectedIems)
            {
                _changedUnits[DataAction.Delete].Add(u);
            }
            foreach (ServiceReference.Unit u in _changedUnits[DataAction.Delete])
            {
                _units.Remove(u);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.Unit u in _changedUnits[DataAction.Add])
            {
                var result = await Connection.Instance.AddUnit(u);
            }
            foreach (ServiceReference.Unit u in _changedUnits[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteUnit(u);
            }
            foreach (ServiceReference.Unit u in _changedUnits[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.Unit u in _units)
            {
                if (u.Id > max)
                {
                    max = u.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedUnits.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.Unit> Units
        {
            get
            {
                return _units;
            }

            private set { }
        }

        public List<ServiceReference.Unit> SelectedItems
        {
            get
            {
                return _selectedIems;
            }

            private set { }
        }


        private ObservableCollection<ServiceReference.Unit> _units;
        private Dictionary<DataAction, List<ServiceReference.Unit>> _changedUnits;
        private List<ServiceReference.Unit> _selectedIems;
    }
}
