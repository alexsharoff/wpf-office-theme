#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region TabControlPallet

    public static class TabControlPallet
    {
        #region Declare

        public static Color Foreground;
        public static Color NormalBorder;
        public static Color BodyBackground;
        public static Color DisableBackGround;

        public static Color ButtonBackground1;
        public static Color ButtonBackground2;
        public static Color ButtonBackground3;
        public static Color ButtonBackground4;

        public static Color ButtonLightBackground1;
        public static Color ButtonLightBackground2;
        public static Color ButtonLightBackground3;
        public static Color ButtonLightBackground4;

        #endregion

        #region Constructor

        static TabControlPallet()
        {
            TabControlPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(TabControlPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Foreground = OfficeColors.Foreground.OfficeColor1;
            NormalBorder = OfficeColors.Background.OfficeColor82;
            BodyBackground = OfficeColors.Background.OfficeColor47;
            DisableBackGround = OfficeColors.Foreground.OfficeColor1;

            ButtonBackground1 = OfficeColors.Background.OfficeColor1;
            ButtonBackground2 = OfficeColors.Background.OfficeColor2;
            ButtonBackground3 = OfficeColors.Background.OfficeColor3;
            ButtonBackground4 = OfficeColors.Background.OfficeColor4;

            ButtonLightBackground1 = OfficeColors.HighLight.OfficeColor3;
            ButtonLightBackground2 = OfficeColors.HighLight.OfficeColor4;
            ButtonLightBackground3 = OfficeColors.HighLight.OfficeColor5;
            ButtonLightBackground4 = OfficeColors.HighLight.OfficeColor6;
        }

        #endregion
    } 

    #endregion
}
