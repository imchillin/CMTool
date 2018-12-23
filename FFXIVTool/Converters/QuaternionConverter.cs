using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace FFXIVTool.Converters
{
    public class QuaternionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values.Length < 4) || !(values[0] is float))
            {
                return new Quaternion();
            }
            return new Quaternion((float)values[0], (float)values[1], (float)values[2], (float)values[3]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Quaternion q = (Quaternion)value;
            return new object[] { q.X, q.Y, q.Z, q.W };
        }
    }
}

