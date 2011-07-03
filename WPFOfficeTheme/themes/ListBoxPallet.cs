#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region ListBoxPallet

    public static class ListBoxPallet
    {
        #region Declare

        public static Color NormalBorder;
        public static Color WindowBackground;

        public static Color DisabledBorder;

        public static Color DisableBackGround1;
        public static Color DisableBackGround2;

        #endregion

        #region Constructor

        static ListBoxPallet()
        {
            ListBoxPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ListBoxPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            NormalBorder = OfficeColors.Background.OfficeColor82;
            WindowBackground = OfficeColors.EditableControlsBackground.OfficeColor1;

            DisabledBorder = OfficeColors.Disabled.OfficeColor3;

            DisableBackGround1 = OfficeColors.Disabled.OfficeColor1;
            DisableBackGround2 = OfficeColors.Disabled.OfficeColor2;
        }

        #endregion
    } 

    #endregion
}
