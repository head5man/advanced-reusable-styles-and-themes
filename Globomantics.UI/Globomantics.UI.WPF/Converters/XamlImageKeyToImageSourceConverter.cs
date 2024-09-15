using Globomantics.UI.WPF.Controls;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Globomantics.UI.WPF.Converters
{
    public class XamlImageKeyToImageSourceConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Height <para/> default(16)
        /// </summary>
        public double Height { get; set; } = 16;
        /// <summary>
        /// Width <para/> default(16)
        /// </summary>
        public double Width { get; set; } = 16;
        /// <summary>
        /// ForegroundResourceKey <para/> default("WindowHeaderForeground")
        /// </summary>
        public string ForegroundResourceKey { get; set; } = "WindowHeaderForeground";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var keyParsed = Enum.TryParse(ForegroundResourceKey, out ThemeResourceKey foregroundKey);
            if ((value is string key) is false || !keyParsed)
            { 
                return null;
            }

            var element = new XamlImage
            {
                Template = (ControlTemplate)Application.Current.TryFindResource(key),
                Foreground = (Brush)Theme.GetResource(foregroundKey),
                Height = Height,
                Width = Width
            };
            var size = new Size((int)element.Width, (int)element.Height);
            element.Measure(size);
            element.Arrange(new Rect(size));

            var dpiScale = VisualTreeHelper.GetDpi(element);

            var rtb = new RenderTargetBitmap(
                (int)element.ActualWidth,
                (int)element.ActualHeight,
                dpiScale.PixelsPerInchX,
                dpiScale.PixelsPerInchY,
                PixelFormats.Pbgra32);
            
            rtb.Render(element);
            
            return rtb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
