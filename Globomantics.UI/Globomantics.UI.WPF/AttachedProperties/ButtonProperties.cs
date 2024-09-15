using System.Windows;

namespace Globomantics.UI.WPF.AttachedProperties
{
    public static class ButtonProperties
    {
        #region CornerRadius (Attached Property)
        /// <summary>
        /// Defines and registers CornerRadius property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached(
                "CornerRadius",
                typeof(double),
                typeof(ButtonProperties),
                new PropertyMetadata(0d));

        /// <summary>
        /// Get the corner radius.
        /// </summary>
        public static double GetCornerRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        /// Set the corner radius.
        /// </summary>
        public static void SetCornerRadius(DependencyObject obj, double value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        #endregion
    }
}
