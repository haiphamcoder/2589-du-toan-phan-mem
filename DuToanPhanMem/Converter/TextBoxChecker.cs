using System;
using System.Globalization;
using System.Windows.Data;

namespace DuToanPhanMem.Converter
{
    class TextBoxChecker:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var l = (long) value;
            if (l>0)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
