using System;
using Windows.UI.Xaml.Data;

namespace AWPMetrologist.Client.Helpers
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string enumString)
            {
                if (!Enum.IsDefined(EnumType, value))
                {
                    throw new ArgumentException("Value must be an Enum");
                }

                var enumValue = Enum.Parse(EnumType, enumString);

                return enumValue.Equals(value);
            }

            throw new ArgumentException("Parameter must be an Enum name!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string enumString)
            {
                return Enum.Parse(EnumType, enumString);
            }

            throw new ArgumentException("Parameter must be an Enum name!");
        }
    }
}