using System;
using Windows.UI.Xaml.Data;

namespace AWPMetrologist.Client.Helpers
{
    public class TimeSpanFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            TimeSpan ts = TimeSpan.Parse(value.ToString());
            DateTime time = DateTime.MinValue + ts;


            return string.Format("{0} г {1} м {2} д", time.Year - 1, time.Month - 1, time.Day - 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
