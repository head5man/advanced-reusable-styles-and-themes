using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Globomantics.UI.WPF
{
    public sealed class Theme
    {
        internal class ThemeResourceBase : ThemeResourceKeyGlue
        {
            public virtual string CONTENT_BACKGROUND { get; set; }
            public virtual string CONTENT_FOREGROUND { get; set; }

            public virtual double CONTROL_DISABLED_OPACITY { get; set; } = 0.4;
            public virtual string CONTROL_FOCUS_BORDER { get; set; } = "#FF833AB4";
            public virtual string CONTROL_FOREGROUND { get; set; }
            public virtual string CONTROL_BACKGROUND { get; set; }
            public virtual string CONTROL_BORDER { get; set; }
            public virtual string CONTROL_DEFAULT_BORDER { get; set; } = "#FFC12B68";
            public virtual string CONTROL_CONTENT_BACKGROUND { get; set; }
            public virtual string CONTROL_HIGHLIGHT_BACKGROUND { get; set; }
            public virtual string CONTROL_MOUSE_OVER_BACKGROUND { get; set; }
            public virtual string CONTROL_MOUSE_OVER_BORDER { get; set; } = "#FFA53289";
            public virtual string CONTROL_PRESSED_BACKGROUND { get; set; }
            public virtual string CONTROL_PRESSED_BORDER { get; set; }
            public virtual string CONTROL_GLYPH_FOREGROUND { get; set; }
            public virtual string GROUPBOX_HEADER_BORDER { get; set; }
            public virtual string GROUPBOX_HEADER_FOREGROUND { get; set; }

            public virtual string LIST_MOUSE_OVER_BACKGROUND { get; set; } = "#22833AB4";
            public virtual string LIST_MOUSE_OVER_BORDER { get; set; } = "#FFA53289";
            public virtual string LIST_SELECTED_BACKGROUND { get; set; } = "#FF833AB4";
            public virtual string LIST_SELECTED_BORDER { get; set; } = "#FFA53289";
            public virtual string LIST_SELECTED_FOREGROUND { get; set; } = "#FFFFFFFF";

            public virtual string WINDOW_BORDER { get; set; } = "#FF616D7B";
            public virtual string WINDOW_ACTIVE_BORDER { get; set; } = "#FF833AB4";
            public virtual string WINDOW_CONTROL_MOUSE_OVER_BACKGROUND { get; set; } = "#FF000000";
            public virtual string WINDOW_HEADER_BACKGROUND_GRADIENT_0 { get; set; } = "#FF833AB4";
            public virtual string WINDOW_HEADER_BACKGROUND_GRADIENT_1 { get; set; } = "#FFFD1D1D";
            public virtual string WINDOW_HEADER_FOREGROUND { get; set; } = "#FFFFFFFF";

            protected override double ControlDisabledOpacity => CONTROL_DISABLED_OPACITY;

            protected override Brush ContentBackground => new SolidColorBrush(ColorFromHex(CONTENT_BACKGROUND));
            protected override Brush ContentForeground => new SolidColorBrush(ColorFromHex(CONTENT_FOREGROUND));

            protected override Brush ControlForeground => new SolidColorBrush(ColorFromHex(CONTROL_FOREGROUND));
            protected override Brush ControlBackground => new SolidColorBrush(ColorFromHex(CONTROL_BACKGROUND));
            protected override Brush ControlBorder => new SolidColorBrush(ColorFromHex(CONTROL_BORDER));
            protected override Brush ControlContentBackground => new SolidColorBrush(ColorFromHex(CONTROL_CONTENT_BACKGROUND));
            protected override Brush ControlHighlightBackground => new SolidColorBrush(ColorFromHex(CONTROL_HIGHLIGHT_BACKGROUND));
            protected override Brush ControlMouseOverBackground => new SolidColorBrush(ColorFromHex(CONTROL_MOUSE_OVER_BACKGROUND));
            protected override Brush ControlMouseOverBorder => new SolidColorBrush(ColorFromHex(CONTROL_MOUSE_OVER_BORDER));
            protected override Brush ControlPressedBackground => new SolidColorBrush(ColorFromHex(CONTROL_PRESSED_BACKGROUND));
            protected override Brush ControlPressedBorder => new SolidColorBrush(ColorFromHex(CONTROL_PRESSED_BORDER));
            protected override Brush ControlFocusBorder => new SolidColorBrush(ColorFromHex(CONTROL_FOCUS_BORDER));
            protected override Brush GlyphForeground => new SolidColorBrush(ColorFromHex(CONTROL_GLYPH_FOREGROUND));
            protected override Brush GroupBoxHeaderBorder => new SolidColorBrush(ColorFromHex(GROUPBOX_HEADER_BORDER));
            protected override Brush GroupBoxHeaderForeground => new SolidColorBrush(ColorFromHex(GROUPBOX_HEADER_FOREGROUND));

            protected override Brush ControlDefaultBorder => new SolidColorBrush(ColorFromHex(CONTROL_DEFAULT_BORDER));
            protected override Brush ListMouseOverBackground => new SolidColorBrush(ColorFromHex(LIST_MOUSE_OVER_BACKGROUND));
            protected override Brush ListMouseOverBorder => new SolidColorBrush(ColorFromHex(LIST_MOUSE_OVER_BORDER));
            protected override Brush ListSelectedBackground => new SolidColorBrush(ColorFromHex(LIST_SELECTED_BACKGROUND));
            protected override Brush ListSelectedBorder => new SolidColorBrush(ColorFromHex(LIST_SELECTED_BORDER));
            protected override Brush ListSelectedForeground => new SolidColorBrush(ColorFromHex(LIST_SELECTED_FOREGROUND));

            protected override Brush WindowBorder => new SolidColorBrush(ColorFromHex(WINDOW_BORDER));

            protected override Brush WindowActiveBorder => new SolidColorBrush(ColorFromHex(WINDOW_ACTIVE_BORDER));

            protected override Brush WindowControlMouseOverBackground => new SolidColorBrush(ColorFromHex(WINDOW_CONTROL_MOUSE_OVER_BACKGROUND));

            protected override Brush WindowHeaderBackground =>
                new LinearGradientBrush 
                {
                    StartPoint = new Point(0, 0.5),
                    EndPoint = new Point(1, 0.5),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop { Offset = 0, Color = ColorFromHex(WINDOW_HEADER_BACKGROUND_GRADIENT_0)},
                        new GradientStop { Offset = 1, Color = ColorFromHex(WINDOW_HEADER_BACKGROUND_GRADIENT_1)},
                    }
                };

            protected override Brush WindowHeaderForeground => new SolidColorBrush(ColorFromHex(WINDOW_HEADER_FOREGROUND));

            private Dictionary<string, object> _keyValuePairs = null;

            public Dictionary<string, object> ThemeResourceKeyMap
            {
                get
                {
                    if (_keyValuePairs == null) 
                    {
                        _keyValuePairs = new Dictionary<string, object>();
                        var properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
                        foreach (var key in Enum.GetNames(typeof(ThemeResourceKey)))
                        {
                            var property = properties.First(p => p.Name.Equals(key));
                            _keyValuePairs.Add(key, property.GetValue(this));
                        }
                    }

                    return _keyValuePairs;
                }
            }

            public object this[string key] { get { return ThemeResourceKeyMap[key]; } }
        }

        internal class LightTheme : ThemeResourceBase
        {
            public override string CONTENT_BACKGROUND { get; set; } = "#FFFFFFFF";
            public override string CONTENT_FOREGROUND { get; set; } = "#FF3f3f3f";

            public override string CONTROL_FOREGROUND { get; set; } = "#FF3f3f3f";
            public override string CONTROL_BACKGROUND { get; set; } = "#FFDBE0E4";
            public override string CONTROL_BORDER { get; set; } = "#FF8192A1";
            public override string CONTROL_CONTENT_BACKGROUND { get; set; } = "#FFFFFFFF";
            public override string CONTROL_HIGHLIGHT_BACKGROUND { get; set; } = "#77833AB4";
            public override string CONTROL_MOUSE_OVER_BACKGROUND { get; set; } = "#FFEDEFF2";
            public override string CONTROL_PRESSED_BACKGROUND { get; set; } = "#FFBFC2C4";
            public override string CONTROL_PRESSED_BORDER { get; set; } = "#FF3CC0FF";
            public override string CONTROL_GLYPH_FOREGROUND { get; set; } = "#FF646769";
            public override string GROUPBOX_HEADER_BORDER { get; set; } = "#FFA53289";
            public override string GROUPBOX_HEADER_FOREGROUND { get; set; } = "#FFA53289";
        }

        internal class DarkTheme : ThemeResourceBase
        {
            public override string CONTENT_BACKGROUND { get; set; } = "#FF222529";
            public override string CONTENT_FOREGROUND { get; set; } = "#FFF4f6f9";

            public override string CONTROL_FOREGROUND { get; set; } = "#FFF4f6f9";
            public override string CONTROL_BACKGROUND { get; set; } = "#FF2D3136";
            public override string CONTROL_BORDER { get; set; } = "#FF616D7B";
            public override string CONTROL_CONTENT_BACKGROUND { get; set; } = "#FF1C1E22";
            public override string CONTROL_HIGHLIGHT_BACKGROUND { get; set; } = "#FF833AB4";
            public override string CONTROL_MOUSE_OVER_BACKGROUND { get; set; } = "#FF4C525E";
            public override string CONTROL_PRESSED_BACKGROUND { get; set; } = "#FF222529";
            public override string CONTROL_PRESSED_BORDER { get; set; } = "#FF00ACE0";
            public override string CONTROL_GLYPH_FOREGROUND { get; set; } = "#FFEBECED";
            public override string GROUPBOX_HEADER_BORDER { get; set; } = "#FFBF399E";
            public override string GROUPBOX_HEADER_FOREGROUND { get; set; } = "#FFBF399E";
        }

        [ThreadStatic]
        private static ResourceDictionary _resourceDictionary;

        internal static ResourceDictionary ResourceDictionary
        {
            get
            {
                if (_resourceDictionary != null)
                {
                    return _resourceDictionary;
                }

                _resourceDictionary = new ResourceDictionary();

                // LoadThemeResource will recurse the previously set field
                // via SetResource's use of property ResourceDictionary
                LoadThemeResource(ThemeType);
                return _resourceDictionary;
            }
        }
        public static ThemeType ThemeType { get; set; } = ThemeType.Light;

        public static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;
            
            LoadThemeResource(type);
        }

        public static object GetResource(ThemeResourceKey resourceKey)
        {
            return ResourceDictionary.Contains(resourceKey.ToString()) ? ResourceDictionary[resourceKey.ToString()] : null;
        }

        internal static void SetResource(object key, object resource)
        {
            ResourceDictionary[key] = resource;
        }

        internal static Color ColorFromHex(string colorHex)
        {
            return (Color?)ColorConverter.ConvertFromString(colorHex) ?? Colors.Transparent;
        }

        internal static bool LoadThemeResource(ThemeType type)
        {
            bool ret = true;
            // TODO: Load from json file if available
            ThemeResourceBase theme = (type == ThemeType.Dark) ? (ThemeResourceBase)new DarkTheme() : new LightTheme();
            try
            {
                foreach (var key in Enum.GetNames(typeof(ThemeResourceKey)))
                {
                    SetResource(key, theme[key]);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
