using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace IoTPlanner.Avalonia.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isConnected)
            {
                return isConnected ? 
                    new SolidColorBrush(Color.Parse("#4CAF50")) :  // Green for connected
                    new SolidColorBrush(Color.Parse("#F44336"));   // Red for disconnected
            }
            
            return new SolidColorBrush(Color.Parse("#FFC107"));    // Amber for unknown status
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}