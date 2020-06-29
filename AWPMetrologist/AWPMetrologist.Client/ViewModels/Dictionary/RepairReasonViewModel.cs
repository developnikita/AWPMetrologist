using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class RepairReasonViewModel : CommandViewModel
    {
        public RepairReasonViewModel()
        {
        }

        public void Initialize()
        {
            _reasons = new ObservableCollection<ServiceReference.RepairReason>();
            _changedReasons = new Dictionary<DataAction, List<ServiceReference.RepairReason>>();

            _changedReasons.Add(DataAction.Add, new List<ServiceReference.RepairReason>());
            _changedReasons.Add(DataAction.Delete, new List<ServiceReference.RepairReason>());
            _changedReasons.Add(DataAction.Update, new List<ServiceReference.RepairReason>());

            _selectedItems = new List<ServiceReference.RepairReason>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetRepairReasons();
            _reasons.Clear();
            ClearChangedData();
            foreach (ServiceReference.RepairReason rr in data)
            {
                _reasons.Add(rr);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.RepairReason reason = new ServiceReference.RepairReason()
            {
                Id = id + 1,
                Reason = "По умолчанию"
            };
            _reasons.Add(reason);
            _changedReasons[DataAction.Add].Add(reason);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.RepairReason r in _selectedItems)
            {
                _changedReasons[DataAction.Delete].Add(r);
            }
            foreach (ServiceReference.RepairReason r in _changedReasons[DataAction.Delete])
            {
                _reasons.Remove(r);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.RepairReason r in _changedReasons[DataAction.Add])
            {
                var result = await Connection.Instance.AddRepairReason(r);
            }
            foreach (ServiceReference.RepairReason r in _changedReasons[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteRepairReason(r);
            }
            foreach (ServiceReference.RepairReason r in _changedReasons[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.RepairReason r in _reasons)
            {
                if (r.Id > max)
                {
                    max = r.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedReasons.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.RepairReason> Reasons
        {
            get
            {
                return _reasons;
            }

            private set { }
        }

        public List<ServiceReference.RepairReason> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.RepairReason> _reasons;
        private Dictionary<DataAction, List<ServiceReference.RepairReason>> _changedReasons;
        private List<ServiceReference.RepairReason> _selectedItems;
    }
}
