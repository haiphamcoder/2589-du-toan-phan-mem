using System;
using System.Globalization;
using System.Windows.Data;

namespace DuToanPhanMem.Converter
{
    class FloatConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float f = (value as float?) ?? 0;
            return f.ToString("N2", new CultureInfo("vi-VN"));
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float f=0f;
            if(value != null)
                f = float.Parse(value as string, new CultureInfo("vi-VN"));
            return f;
        }
    }
}
