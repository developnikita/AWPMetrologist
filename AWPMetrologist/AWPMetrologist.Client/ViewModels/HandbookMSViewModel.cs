using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ServiceReference.MeasuringInstrument> _measuringInstruments;
    }
}
