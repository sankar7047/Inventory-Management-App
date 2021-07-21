using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace InventoryManagementApp.Converters
{
    /// <summary>
    /// Converter class to convert the multiple values and returns thier multipled value.
    /// </summary>
    public class MultiplyingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values.Length > 0)
            {
                double result = System.Convert.ToDouble(values[0]);
                for (int i = 1; i < values.Length; i++)
                {
                    result *= System.Convert.ToDouble(values[i]);
                }
                return result;
            }
            
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // Ignoring the convert back
            return default(object[]);
        }
    }
}
