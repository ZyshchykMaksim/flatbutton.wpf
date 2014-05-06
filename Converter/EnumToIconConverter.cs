using System;
using System.Linq;
using System.Windows.Data;

namespace FlatUIWPF.Converter
{
    public class EnumToIconConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = null;
            AwesomeIcon iconValue = (AwesomeIcon)value;
            if (iconValue != AwesomeIcon.none)
            {
                foreach (var icon in FlatInformation.Instance.CollectionIcon.Where(icon => icon.Key == iconValue))
                {
                    result = icon.Value;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Empty;
        }
    }
}
