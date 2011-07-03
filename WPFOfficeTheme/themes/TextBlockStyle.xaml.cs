using System;
using System.Windows.Media; 

namespace WPFOfficeTheme
{
    public static class TextBlockStyle
    {
        public static Color ForegroundColorBrush;

        static TextBlockStyle()
        {
            TextBlockStyle.Reset();
			OfficeColors.RegistersTypes.Add(typeof(TextBlockStyle));
        }

        public static void Reset()
        {
            TextBlockStyle.ForegroundColorBrush = OfficeColors.Foreground.OfficeColor1;
        }
    } 
}
