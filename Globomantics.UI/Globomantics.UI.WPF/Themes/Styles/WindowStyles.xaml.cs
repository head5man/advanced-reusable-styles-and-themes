using System.Windows;

namespace Globomantics.UI.WPF.Themes.Styles
{
    /// <summary>
    /// Implements MainWindow template's button handlers
    /// </summary>
    public partial class WindowStyles : ResourceDictionary
    {
        public WindowStyles()
        {
            InitializeComponent();
        }

        Window GetWindow(object sender) => (sender as FrameworkElement)?.TemplatedParent as Window;

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            GetWindow(sender).WindowState = WindowState.Minimized;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            GetWindow(sender).Close();
        }

        private void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(sender);
            window.WindowState = window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ThemeSwitchClick(object sender, RoutedEventArgs e)
        {
            var theme = Theme.ThemeType != ThemeType.Light ? ThemeType.Light : ThemeType.Dark;
            Theme.LoadThemeType(theme);
        }
    }
}
