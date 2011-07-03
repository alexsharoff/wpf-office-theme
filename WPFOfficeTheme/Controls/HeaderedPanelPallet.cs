#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region HeaderedPanelPallet

    public static class HeaderedPanelPallet
    {
        #region Declare

        public static Color Foreground;
        public static Color NormalBorder;

        public static Color HeaderBackground1;
        public static Color HeaderBackground2;

        public static Color BodyBackground;

        #endregion

        #region Constructor

        static HeaderedPanelPallet()
        {
            HeaderedPanelPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(HeaderedPanelPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Foreground = OfficeColors.Foreground.OfficeColor1;
            NormalBorder = OfficeColors.Background.OfficeColor85;

            HeaderBackground1 = OfficeColors.Background.OfficeColor41;
            HeaderBackground2 = OfficeColors.Background.OfficeColor85;

            BodyBackground = OfficeColors.Background.OfficeColor47;
        }

        #endregion
    } 

    #endregion
}
