using System;
using System.Windows.Data;

namespace Hackernator.Converters
{
    public class DataToLabel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case "points":
                    {
                        return ((int)value).ToString() + " points";
                    }
                case "comments":
                    {
                        return ((int)value).ToString() + " comments";
                    }
                default:
                    {
                        return (string)value;
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
