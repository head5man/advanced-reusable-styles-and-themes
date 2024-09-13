


using Globomantics.UI.WPF.Commands;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Globomantics.UI.WPF.ViewModels
{
    public class MainWindowModel : MarkupExtension
    {
        public MainWindowModel()
        {
            ThemeSwitchCommand = new RelayCommand(ExecuteThemeSwitch);
            CloseCommand = new RelayCommand(_ => Window.Close());
            MaximizeCommand = new RelayCommand(_ => Window.WindowState = Window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
            MinimizeCommand = new RelayCommand(_ => Window.WindowState = WindowState.Minimized);
            Window = Application.Current.MainWindow;
        }

        public ICommand ThemeSwitchCommand { get; }

        public ICommand CloseCommand { get; }

        public ICommand MaximizeCommand { get; }

        public ICommand MinimizeCommand { get; }

        private Window Window { get; }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        private void ExecuteThemeSwitch(object _)
        {
            var theme = Theme.ThemeType != ThemeType.Light ? ThemeType.Light : ThemeType.Dark;
            Theme.LoadThemeType(theme);
        }
    }
}
