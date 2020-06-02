using AWPMetrologist.Client.Helpers;
using AWPMetrologist.Client.ServiceReference;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class MeasuringSystemVerificationViewModel : INotifyPropertyChanged
    {
        public MeasuringSystemVerificationViewModel()
        {
        }

        public void Initialize()
        {
            _ms = new ObservableCollection<MeasuringSystem>();
            _methods = new ObservableCollection<VerificationMethod>();
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
            MeasuringSystem selectedItem = ((DataGrid)sender).SelectedItem as MeasuringSystem;
            if (selectedItem.Exploitation.Verification == null)
            {
                selectedItem.Exploitation.Verification = new Verification();
                _update = new Tuple<DataAction, Exploitation>(DataAction.Add, selectedItem.Exploitation);
            }
            else
            {
                _update = new Tuple<DataAction, Exploitation>(DataAction.Update, selectedItem.Exploitation);
            }
            _selectedItem = selectedItem;
            _selectedMethod = selectedItem.Exploitation.Verification.VerificationMethod;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMethod)));
        }

        public async void Save(object sender, RoutedEventArgs args)
        {
            if (_update.Item1.Equals(DataAction.Add))
            {
                _update.Item2.Verification.VerificationMethod = _selectedMethod;
                var result = await Connection.Instance.AddVerification(_update.Item2.Verification);
                _update.Item2.Verification.Id = result;
                await Connection.Instance.UpdateExploitation(_update.Item2);
            }
            if (_update.Item1.Equals(DataAction.Update))
            {
                _update.Item2.Verification.VerificationMethod = _selectedMethod;
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

        public ObservableCollection<VerificationMethod> Methods
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
        }

        public VerificationMethod SelectedMethod
        {
            get
            {
                VerificationMethod result = _selectedMethod != null ? _methods.ToList().Find(x => x.Id == _selectedMethod.Id) : null;

                return result;
            }

            set
            {
                if (_selectedMethod != value)
                {
                    _selectedMethod = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMethod)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<MeasuringSystem> _ms;
        private ObservableCollection<VerificationMethod> _methods;
        private MeasuringSystem _selectedItem;
        private VerificationMethod _selectedMethod;
        private Tuple<DataAction, Exploitation> _update;
    }
}
