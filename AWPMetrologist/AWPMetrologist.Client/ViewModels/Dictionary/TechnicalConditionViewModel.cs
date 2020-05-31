using Autofac.Core;
using AWPMetrologist.Client.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class TechnicalConditionViewModel : CommandViewModel
    {
        public TechnicalConditionViewModel()
        {
        }

        public void Initialize()
        {
            _conditions = new ObservableCollection<ServiceReference.TechnicalCondition>();
            _changedCondition = new Dictionary<DataAction, List<ServiceReference.TechnicalCondition>>();

            _changedCondition.Add(DataAction.Add, new List<ServiceReference.TechnicalCondition>());
            _changedCondition.Add(DataAction.Delete, new List<ServiceReference.TechnicalCondition>());
            _changedCondition.Add(DataAction.Update, new List<ServiceReference.TechnicalCondition>());

            _selectedItems = new List<ServiceReference.TechnicalCondition>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetTechnicalConditions();
            _conditions.Clear();
            ClearChangedData();
            foreach (ServiceReference.TechnicalCondition tc in data)
            {
                _conditions.Add(tc);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.TechnicalCondition condition = new ServiceReference.TechnicalCondition()
            {
                Id = id + 1,
                Condition = "По умолчанию"
            };
            _conditions.Add(condition);
            _changedCondition[DataAction.Add].Add(condition);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.TechnicalCondition c in _selectedItems)
            {
                _changedCondition[DataAction.Delete].Add(c);
            }
            foreach (ServiceReference.TechnicalCondition c in _changedCondition[DataAction.Delete])
            {
                _conditions.Remove(c);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.TechnicalCondition c in _changedCondition[DataAction.Add])
            {
                var result = await Connection.Instance.AddTechnicalCondition(c);
            }
            foreach (ServiceReference.TechnicalCondition c in _changedCondition[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteTechnicalCondition(c);
            }
            foreach (ServiceReference.TechnicalCondition c in _changedCondition[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.TechnicalCondition c in _conditions)
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
            foreach (var l in _changedCondition.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.TechnicalCondition> Conditions
        { 
            get
            {
                return _conditions;
            }

            private set { }
        }

        public List<ServiceReference.TechnicalCondition> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.TechnicalCondition> _conditions;
        private Dictionary<DataAction, List<ServiceReference.TechnicalCondition>> _changedCondition;
        private List<ServiceReference.TechnicalCondition> _selectedItems;
    }
}
