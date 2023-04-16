using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GUI03
{
    public class BGColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(type.Good))
            {
                return Brushes.LightGreen;
            }
            else if (value.Equals(type.Bad))
            {
                return Brushes.LightPink;
            }
            else
            {
                return Brushes.LightYellow;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
