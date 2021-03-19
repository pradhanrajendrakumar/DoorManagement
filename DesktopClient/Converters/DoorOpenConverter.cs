using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DesktopClient.Converters
{
    public class DoorOpenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            bool result = value is { } && bool.TryParse(value.ToString(), out val);
            if (val)
            {
                return "OPEN";
            }

            return "CLOSED";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is { })
            {
                string val = value.ToString();

                if (val == "OPEN")
                {
                    return true;
                }
            }

            return false;

        }
    }

    public class DoorLockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            bool result = value is { } && bool.TryParse(value.ToString(), out val);
            if (val)
            {
                return "LOCKED";
            }

            return "UNLOCKED";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is { })
            {
                string val = value.ToString();

                if (val == "LOCKED")
                {
                    return true;
                }
            }

            return false;

        }
    }

    public class DoorOpenContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            bool result = value is { } && bool.TryParse(value.ToString(), out val);
            if (val)
            {
                return "CLOSE";
            }

            return "OPEN";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DoorLockContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            bool result = value is { } && bool.TryParse(value.ToString(), out val);
            if (val)
            {
                return "UNLOCK";
            }

            return "LOCK";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DoorLockVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            bool result = value is { } && bool.TryParse(value.ToString(), out val);
            if (val)
            {
                return Visibility.Collapsed;

            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
