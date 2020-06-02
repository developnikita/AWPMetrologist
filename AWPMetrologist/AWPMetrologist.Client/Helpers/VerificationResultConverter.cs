using System;
using Windows.UI.Xaml.Data;

namespace AWPMetrologist.Client.Helpers
{
    public class VerificationResultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            bool result = (bool)value;

            if (result)
            {
                return "Годен";
            }
            return "Требует замены";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
