using System.Globalization;

namespace _253504Novikov.UI.ValueConverters
{
    public class InspectionDateToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((DateTime)value < (DateTime.Now.AddYears(-1)))
                return Colors.LightPink;
            return Colors.WhiteSmoke;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
