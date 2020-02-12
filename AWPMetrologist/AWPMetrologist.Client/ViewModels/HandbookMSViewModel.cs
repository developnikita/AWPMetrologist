using Microsoft.Toolkit.Uwp.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AWPMetrologist.Client.ViewModels
{
    public class HandbookMSViewModel : INotifyPropertyChanged
    {
        public HandbookMSViewModel()
        {
        }

        public void Initialize()
        {
            _measuringInstruments = new ObservableCollection<ServiceReference.MeasuringInstrument>();
        }

        public async Task LoadMeasuringInstruments()
        {
            await Task.Run(async () =>
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                {
                    foreach (ServiceReference.MeasuringInstrument mi in
                                await Connection.Instance.GetMeasuringInstruments())
                    {
                        MeasuringInstruments.Add(mi);
                    }
                });
            });
        }

        public ObservableCollection<ServiceReference.MeasuringInstrument> MeasuringInstruments
        {
            get
            {
                return _measuringInstruments;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ServiceReference.MeasuringInstrument> _measuringInstruments;
    }
}
