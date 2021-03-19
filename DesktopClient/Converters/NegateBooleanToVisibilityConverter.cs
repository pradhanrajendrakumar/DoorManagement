using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DesktopClient.Converters
{
    public class NegateBooleanToVisibilityConverter : IValueConverter
    {
        public NegateBooleanToVisibilityConverter()
        {
            CollapsedVisibility = Visibility.Collapsed;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = bool.TryParse(value.ToString(), out var outerValue);
            if (!result) return value;
            if (outerValue && !Negate) return Visibility.Visible;
            if (outerValue && Negate) return CollapsedVisibility;
            if (!outerValue && Negate) return Visibility.Visible;
            if (!outerValue && !Negate) return CollapsedVisibility;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool Negate { get; set; }

        public Visibility CollapsedVisibility { get; set; }
    }
}
