﻿using System;
using Windows.UI.Xaml.Data;

namespace AWPMetrologist.Client.Helpers
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.Now;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value != null)
                {
                    DateTimeOffset dto = (DateTimeOffset)value;
                    return dto.DateTime;
                }
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
    }
}
