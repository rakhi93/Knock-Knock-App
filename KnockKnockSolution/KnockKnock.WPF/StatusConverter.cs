using System;
using System.Globalization;
using System.Windows.Data;

namespace KnockKnock.WPF
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int status)
            {
                if (parameter?.ToString() == "Button") // ✅ Handles Button Enable/Disable
                {
                    return status == 0; // Enable button only if status is "Pending" (0)
                }

                // ✅ Return the correct Status string
                return status switch
                {
                    0 => "Pending",
                    1 => "Approved",
                    2 => "Rejected",
                    _ => "Unknown"
                };
            }
            return "Unknown"; // ✅ Default case to prevent "false" being displayed
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
