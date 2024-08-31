﻿using System;
using System.Windows;
using System.Windows.Media;

namespace Globomantics.UI.WPF
{
    public sealed class Theme
    {
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
                        // TODO: Add resources of light theme
                        break;
                    }
                case ThemeType.Dark:
                    {
                        // TODO: Add resources of dark theme
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
