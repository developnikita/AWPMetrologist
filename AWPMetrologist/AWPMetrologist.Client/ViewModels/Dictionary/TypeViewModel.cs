using AWPMetrologist.Client.Helpers;
using AWPMetrologist.Client.ServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class TypeViewModel : CommandViewModel
    {
        public TypeViewModel()
        {
        }

        public void Initialize()
        {
            _types = new ObservableCollection<MSType>();
            _changedTypes = new Dictionary<DataAction, List<MSType>>();

            _changedTypes.Add(DataAction.Add, new List<MSType>());
            _changedTypes.Add(DataAction.Delete, new List<MSType>());
            _changedTypes.Add(DataAction.Update, new List<MSType>());

            _selectedItems = new List<MSType>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMSTypes();
            _types.Clear();
            ClearChangedData();
            foreach (MSType t in data)
            {
                _types.Add(t);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            MSType type = new MSType()
            { 
                Id = id + 1,
                Type = "По умолчанию"
            };
            _types.Add(type);
            _changedTypes[DataAction.Add].Add(type);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (MSType t in _selectedItems)
            {
                _changedTypes[DataAction.Delete].Add(t);
            }
            foreach (MSType t in _changedTypes[DataAction.Delete])
            {
                _types.Remove(t);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (MSType t in _changedTypes[DataAction.Add])
            {
                var result = await Connection.Instance.AddMSType(t);
            }
            foreach (MSType t in _changedTypes[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteMSType(t);
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (MSType t in _types)
            {
                if (t.Id > max)
                {
                    max = t.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach(var l in _changedTypes.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<MSType> Types
        {
            get
            {
                return _types;
            }

            private set { }
        }

        public List<MSType> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        public ObservableCollection<MSType> _types;
        private Dictionary<DataAction, List<MSType>> _changedTypes;
        private List<MSType> _selectedItems;
    }
}
