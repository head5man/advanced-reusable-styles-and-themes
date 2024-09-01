using System.Windows.Media;

namespace Globomantics.UI.WPF
{
    public enum ThemeResourceKey
    {
        ContentBackground,
        ContentForeground,
        ControlForeground,
        ControlBorder,
        ControlBackground,
        ControlContentBackground,
        ControlDefaultBorder,
        ControlHighlightBackground,
        ControlMouseOverBackground,
        ControlMouseOverBorder,
        ControlPressedBackground,
        ControlPressedBorder,
        ControlDisabledOpacity,
        ControlFocusBorder,
        GlyphForeground,
        GroupBoxHeaderBorder,
        GroupBoxHeaderForeground,
        ListMouseOverBackground,
        ListMouseOverBorder,
        ListSelectedBackground,
        ListSelectedBorder,
        ListSelectedForeground,
        WindowBorder,
        WindowActiveBorder,
        WindowControlMouseOverBackground,
        WindowHeaderBackground,
        WindowHeaderForeground
    }

    /// <summary>
    /// A helper class to keep theme instances in sync with keys
    /// </summary>
    public abstract class ThemeResourceKeyGlue
    {
        protected abstract Brush ContentBackground { get; }
        protected abstract Brush ContentForeground { get; }
        protected abstract Brush ControlForeground { get; }
        protected abstract Brush ControlBorder { get; }
        protected abstract Brush ControlBackground { get; }
        protected abstract Brush ControlContentBackground { get; }
        protected abstract Brush ControlDefaultBorder { get; }
        protected abstract Brush ControlHighlightBackground { get; }
        protected abstract Brush ControlMouseOverBackground { get; }
        protected abstract Brush ControlMouseOverBorder { get; }
        protected abstract Brush ControlPressedBackground { get; }
        protected abstract Brush ControlPressedBorder { get; }
        protected abstract double ControlDisabledOpacity { get; }
        protected abstract Brush ControlFocusBorder { get; }
        protected abstract Brush GlyphForeground { get; }
        protected abstract Brush GroupBoxHeaderBorder { get; }
        protected abstract Brush GroupBoxHeaderForeground { get; }

        protected abstract Brush ListMouseOverBackground { get; }
        protected abstract Brush ListMouseOverBorder { get; }
        protected abstract Brush ListSelectedBackground { get; }
        protected abstract Brush ListSelectedBorder { get; }
        protected abstract Brush ListSelectedForeground { get; }

        protected abstract Brush WindowBorder { get; }
        protected abstract Brush WindowActiveBorder { get; }
        protected abstract Brush WindowControlMouseOverBackground { get; }
        protected abstract Brush WindowHeaderBackground { get; }
        protected abstract Brush WindowHeaderForeground { get; }
    }
}
