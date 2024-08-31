using System;
using System.Windows;
using System.Windows.Media;

namespace Globomantics.UI.WPF
{
    public sealed class Theme
    {
        static class dark
        {
            public const string CONTENT_BG = "#FFFFFFFF";
            public const string CONTENT_FG = "#FF000000";
        }

        static class light
        {
            public const string CONTENT_BG = "#FF000000";
            public const string CONTENT_FG = "#FFFFFFFF";
        }
        [ThreadStatic]
        private static ResourceDictionary resourceDictionary;

        internal static ResourceDictionary ResourceDictionary
        {
            get
            {
                if (resourceDictionary != null)
                {
                    return resourceDictionary;
                }

                resourceDictionary = new ResourceDictionary();
                LoadThemeType(ThemeType.Light);
                return resourceDictionary;
            }
        }
        public static ThemeType ThemeType { get; set; } = ThemeType.Light;

        public static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;

            // TODO: Add resources unaffected by theme

            switch (type)
            {
                case ThemeType.Light:
                    {
                        SetResource(nameof(ThemeResourceKey.ContentBackground), new SolidColorBrush(ColorFromHex(light.CONTENT_BG)));
                        SetResource(nameof(ThemeResourceKey.ContentForeground), new SolidColorBrush(ColorFromHex(light.CONTENT_FG)));
                        break;
                    }
                case ThemeType.Dark:
                    {
                        SetResource(nameof(ThemeResourceKey.ContentBackground), new SolidColorBrush(ColorFromHex(dark.CONTENT_BG)));
                        SetResource(nameof(ThemeResourceKey.ContentForeground), new SolidColorBrush(ColorFromHex(dark.CONTENT_FG)));
                        break;
                    }
            }
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
    }
}
