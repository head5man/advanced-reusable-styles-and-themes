using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Globomantics.UI.WPF.Converters
{
    public class BoolToVisibilityFlexConverter : MarkupExtension, IValueConverter
    {
        public bool Inverted { get; set; } = false;

        public Visibility FalseVisibility { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertValue = false;
            if (value is bool b)
            {
                convertValue = b;
            }

            return (convertValue ^ Inverted) ? Visibility.Visible : FalseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility vis) 
            {
                return (vis == Visibility.Visible) ^ Inverted;
            }

            return false;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
