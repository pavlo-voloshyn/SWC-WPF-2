using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PP.UI.Converters
{
    public class ControlVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value != 0 && (string)parameter == "Orders")
            {
                return Visibility.Visible;
            } 
            else if ((int)value == 0 && (string)parameter == "Employees")
            {
                return Visibility.Visible;
            }
            else 
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
