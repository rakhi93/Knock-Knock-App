using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace KnockKnock.WPF
{
    public class ButtonStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int status && parameter is string buttonType)
            {
                // If status is 1 (Approved), disable both buttons
                if (status == 1)
                {
                    return new Style(typeof(Button))
                    {
                        Setters =
                        {
                            new Setter(Button.BackgroundProperty, Brushes.Gray),
                            new Setter(Button.ForegroundProperty, Brushes.White),
                            new Setter(Button.OpacityProperty, 0.5) // ✅ Fix: Ensure Opacity is a double (0.5)
                        }
                    };
                }

                // Default button style (enabled)
                return new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter(Button.BackgroundProperty, buttonType == "Approve" ? Brushes.LightGreen : Brushes.LightCoral),
                        new Setter(Button.ForegroundProperty, Brushes.White),
                        new Setter(Button.OpacityProperty, 1.0) // ✅ Fix: Use 1.0 instead of 1
                    }
                };
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
