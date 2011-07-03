#region Using

using System;
using System.Windows.Media;

#endregion

namespace WPFOfficeTheme
{
    #region ExpanderPallet

    public static class ExpanderPallet
    {
        #region Declare

        public static Color Foreground;
        public static Color NormalBorder;
        public static Color Glyph;
        public static Color ButtonExternalBorder;
        public static Color ButtonInternalBorder;

        public static Color ButtonBackground1;
        public static Color ButtonBackground2;

        public static Color ButtonLightBackground1;
        public static Color ButtonLightBackground2;

        public static Color ButtonPlusLightBackground1;
        public static Color ButtonPlusLightBackground2;

        public static Color HeaderBackground1;
        public static Color HeaderBackground2;

        public static Color BodyBackground;

        #endregion

        #region Constructor

        static ExpanderPallet()
        {
            ExpanderPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ExpanderPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Foreground = OfficeColors.Foreground.OfficeColor1;
            NormalBorder = OfficeColors.Background.OfficeColor85;
            Glyph = OfficeColors.Foreground.OfficeColor3;
            ButtonExternalBorder = OfficeColors.Background.OfficeColor8;
            ButtonInternalBorder = OfficeColors.Background.OfficeColor7;

            ButtonBackground1 = OfficeColors.Background.OfficeColor53;
            ButtonBackground2 = OfficeColors.Background.OfficeColor85;

            ButtonLightBackground1 = OfficeColors.HighLight.OfficeColor10;
            ButtonLightBackground2 = OfficeColors.Background.OfficeColor85;

            ButtonPlusLightBackground1 = OfficeColors.HighLight.OfficeColor11;
            ButtonPlusLightBackground2 = OfficeColors.Background.OfficeColor85;
                        
            HeaderBackground1 = OfficeColors.Background.OfficeColor41;
            HeaderBackground2 = OfficeColors.Background.OfficeColor85;

            BodyBackground = OfficeColors.Background.OfficeColor47;
        }

        #endregion
    }

    #endregion
}
