


using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Globomantics.UI.WPF.Converters
{
    public class ObjectToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public bool Invert { get; set; } = false;

        public Visibility NullVisibility { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is null) ^ Invert ? NullVisibility : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
