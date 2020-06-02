using AWPMetrologist.Client.ServiceReference;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace AWPMetrologist.Client.ViewModels
{
    public class VerificationResultViewModel
    {
        public VerificationResultViewModel()
        {
        }

        public void Initialize()
        {
            _ms = new ObservableCollection<Tuple<MeasuringSystem, TimeSpan?>>();
        }

        public async void LoadData(object sender, RoutedEventArgs args)
        {
            var data = await Connection.Instance.GetMeasuringSystemVerification();
            _ms.Clear();
            foreach (MeasuringSystem ms in data)
            {
                TimeSpan? time = null;
                if (ms.Exploitation.Verification != null)
                {
                    time = ms.Exploitation.Verification.NextDate.Subtract(ms.Exploitation.Verification.LastDate);
                }
                _ms.Add(new Tuple<MeasuringSystem, TimeSpan?>(ms, time));
            }
        }

        public ObservableCollection<Tuple<MeasuringSystem, TimeSpan?>> MS
        {
            get
            {
                return _ms;
            }

            private set { }
        }

        private ObservableCollection<Tuple<MeasuringSystem, TimeSpan?>> _ms;
    }
}
