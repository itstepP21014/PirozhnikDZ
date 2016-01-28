using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Example5ValueConverter
{
   public class MyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Преобразовать значение double в int.
            double temp = (double)value;
            return (int)temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Поскольку заботиться о "двунаправленной" привязке
            // не нужно, просто вернуть value.

            return value;
        }
    }
}
