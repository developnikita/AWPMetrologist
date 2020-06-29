using AWPMetrologist.Client.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels.Dictionary
{
    public class VerificationMethodViewModel : CommandViewModel
    {
        public VerificationMethodViewModel()
        {
        }

        public void Initialize()
        {
            _methods = new ObservableCollection<ServiceReference.VerificationMethod>();
            _changedMethods = new Dictionary<DataAction, List<ServiceReference.VerificationMethod>>();

            _changedMethods.Add(DataAction.Add, new List<ServiceReference.VerificationMethod>());
            _changedMethods.Add(DataAction.Delete, new List<ServiceReference.VerificationMethod>());
            _changedMethods.Add(DataAction.Update, new List<ServiceReference.VerificationMethod>());

            _selectedItems = new List<ServiceReference.VerificationMethod>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetVerificationMethods();
            _methods.Clear();
            ClearChangedData();
            foreach (ServiceReference.VerificationMethod vm in data)
            {
                _methods.Add(vm);
            }
        }

        public override void Add(object sender, RoutedEventArgs args)
        {
            int id = GetHighestId();
            ServiceReference.VerificationMethod method = new ServiceReference.VerificationMethod()
            {
                Id = id + 1,
                Method = "По умолчанию"
            };
            _methods.Add(method);
            _changedMethods[DataAction.Add].Add(method);
        }

        public override void Delete(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.VerificationMethod m in _selectedItems)
            {
                _changedMethods[DataAction.Delete].Add(m);
            }
            foreach (ServiceReference.VerificationMethod m in _changedMethods[DataAction.Delete])
            {
                _methods.Remove(m);
            }
        }

        public async override void Save(object sender, RoutedEventArgs args)
        {
            foreach (ServiceReference.VerificationMethod m in _changedMethods[DataAction.Add])
            {
                var result = await Connection.Instance.AddVerificationMethod(m);
            }
            foreach (ServiceReference.VerificationMethod m in _changedMethods[DataAction.Delete])
            {
                var result = await Connection.Instance.DeleteVerificationMethod(m);
            }
            foreach (ServiceReference.VerificationMethod m in _changedMethods[DataAction.Update])
            {
                // Connection.AddMSCategory();
            }
            ClearChangedData();
        }

        private int GetHighestId()
        {
            int max = 0;
            foreach (ServiceReference.VerificationMethod m in _methods)
            {
                if (m.Id > max)
                {
                    max = m.Id;
                }
            }
            return max;
        }

        private void ClearChangedData()
        {
            foreach (var l in _changedMethods.Values)
            {
                l.Clear();
            }
        }

        public ObservableCollection<ServiceReference.VerificationMethod> Methods
        {
            get
            {
                return _methods;
            }

            private set { }
        }

        public List<ServiceReference.VerificationMethod> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            private set { }
        }

        private ObservableCollection<ServiceReference.VerificationMethod> _methods;
        private Dictionary<DataAction, List<ServiceReference.VerificationMethod>> _changedMethods;
        private List<ServiceReference.VerificationMethod> _selectedItems;
    }
}
