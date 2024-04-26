using System;
using System.Globalization;
using System.Windows.Data;

namespace DuToanPhanMem.Converter
{
    class LongConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:N0}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long l;
            if (value is string && long.TryParse(value as string, NumberStyles.AllowThousands, new CultureInfo("vi-VN"), out l))
            {
                return l;
            }

            return 0;
        }
    }
}
