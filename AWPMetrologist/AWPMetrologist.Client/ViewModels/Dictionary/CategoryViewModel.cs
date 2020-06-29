using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class CategoryViewModel : CommandViewModel
    {
        public CategoryViewModel()
        {

        }

        public void Initialize()
        {
            _categories = new ObservableCollection<ServiceReference.MSCategory>();
            _changedCategory = new Dictionary<DataAction, List<ServiceReference.MSCategory>>();

            _changedCategory.Add(DataAction.Add, new List<ServiceReference.MSCategory>());
            _changedCategory.Add(DataAction.Delete, new List<ServiceReference.MSCategory>());
            _changedCategory.Add(DataAction.Update, new List<ServiceReference.MSCategory>());

            _selectedItems = new List<ServiceReference.MSCategory>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMSCategories();
            _categories.Clear();
            ClearChangedData();
            foreach (ServiceReference.MSCategory c in data)
            {
                _categories.Add(c);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.MSCategory category = new ServiceReference.MSCategory()
            {
                Id = id + 1,
                Category = "По умолчанию"
            };
            _categories.Add(category);
            _changedCategory[DataAction.Add].Add(category);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MSCategory c in _selectedItems)
            {
                _changedCategory[DataAction.Delete].Add(c);
            }
            foreach (ServiceReference.MSCategory c in _changedCategory[DataAction.Delete])
            {
                _categories.Remove(c);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.MSCategory c in _changedCategory[DataAction.Add])
            {
                var result = await Connection.Instance.AddMSCategory(c);
            }
            foreach (ServiceReference.MSCategory c in _changedCategory[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteMSCategory(c);
            }
            foreach (ServiceReference.MSCategory c in _changedCategory[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.MSCategory c in _categories)
            {
                if (c.Id > max)
                {
                    max = c.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedCategory.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.MSCategory> Categories
        {
            get
            {
                return _categories;
            }

            private set { }
        }

        public List<ServiceReference.MSCategory> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.MSCategory> _categories;
        private Dictionary<DataAction, List<ServiceReference.MSCategory>> _changedCategory;
        private List<ServiceReference.MSCategory> _selectedItems;
    }
}
