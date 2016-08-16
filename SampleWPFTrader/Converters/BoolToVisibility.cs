using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SampleWPFTrader.Converters
{
	public class BoolToVisibility : IValueConverter
	{
        public bool DownloadingData { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool inveter = false;
            if (parameter != null)
            {
                bool.TryParse((string)parameter, out inveter);
            }

            return value is bool
                       ? (DownloadingData == (bool)value ^ inveter ? Visibility.Visible : Visibility.Collapsed)
                       : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

	}
}
