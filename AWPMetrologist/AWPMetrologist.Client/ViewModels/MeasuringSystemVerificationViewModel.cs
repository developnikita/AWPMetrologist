using AWPMetrologist.Client.Helpers;
using AWPMetrologist.Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AWPMetrologist.Client.ViewModels
{
    public class MeasuringSystemVerificationViewModel
    {
        public MeasuringSystemVerificationViewModel()
        {
        }

        public void Initialize()
        {
            _ms = new ObservableCollection<MeasuringSystem>();
            _methods = new List<VerificationMethod>();
            _selectedItem = new MeasuringSystem();
            _saveData = new Dictionary<DataAction, Exploitation>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMeasuringSystemVerification();
            _ms.Clear();
            foreach (MeasuringSystem ms in data)
            {
                _ms.Add(ms);
            }
            var methods = await Connection.Instance.GetVerificationMethods();
            _methods.Clear();
            foreach (VerificationMethod m in methods)
            {
                _methods.Add(m);
            }
        }

        public void SelectionChanged(object sender, RoutedEventArgs args)
        {
            MeasuringSystem selectedItem = (MeasuringSystem)((ListView)sender).SelectedItem;
            if (selectedItem.Exploitation.Verification == null)
            {
                selectedItem.Exploitation.Verification = new Verification();
                _update = new Tuple<DataAction, Exploitation>(DataAction.Add, selectedItem.Exploitation);
                _saveData.Add(DataAction.Add, selectedItem.Exploitation);
            }
            else
            {
                _update = new Tuple<DataAction, Exploitation>(DataAction.Update, selectedItem.Exploitation);
                _saveData.Add(DataAction.Update, selectedItem.Exploitation);
            }
            _selectedItem = selectedItem;
        }

        public async void Save(object sender, RoutedEventArgs args)
        {
            if (_update.Item1.Equals(DataAction.Add))
            {
                var result = await Connection.Instance.AddVerification(_update.Item2.Verification);
                _update.Item2.Verification.Id = result;
                await Connection.Instance.UpdateExploitation(_update.Item2);
            }
            if (_update.Item1.Equals(DataAction.Update))
            {
                await Connection.Instance.UpdateVerification(_update.Item2.Verification);
            }
        }

        public ObservableCollection<MeasuringSystem> MS
        {
            get
            {
                return _ms;
            }

            private set { }
        }

        public List<VerificationMethod> Methods
        {
            get
            {
                return _methods;
            }

            private set { }
        }

        public MeasuringSystem SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }

        private ObservableCollection<MeasuringSystem> _ms;
        private List<VerificationMethod> _methods;
        private MeasuringSystem _selectedItem;
        private Tuple<DataAction, Exploitation> _update;
        private Dictionary<DataAction, Exploitation> _saveData;
    }
}
