using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyEmployee.Converter
{
   public class ValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value.ToString() == "IT")
            //    return Color.Red;
            //else
                return Color.Green;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
