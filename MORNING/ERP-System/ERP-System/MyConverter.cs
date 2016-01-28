using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;

namespace ERP_System
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = value.ToString();
            return temp.Split(' ')[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    class StatusOfProjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = value.ToString();
            return temp + " %";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    class PerformanceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                QualityMetrics a = ((Person)value).Performance;
                KeyValuePair<string, int>[] result = new KeyValuePair<string, int>[]
                {
                    new KeyValuePair<string, int>(a.metrics[0], a.indexes[0]),
                    new KeyValuePair<string, int>(a.metrics[1], a.indexes[1]),
                    new KeyValuePair<string, int>(a.metrics[2], a.indexes[2]),
                    new KeyValuePair<string, int>(a.metrics[3], a.indexes[3]),
                    new KeyValuePair<string, int>(a.metrics[4], a.indexes[4])
                };
                return result;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    class SalaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = value.ToString();
            return temp + '$';
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
