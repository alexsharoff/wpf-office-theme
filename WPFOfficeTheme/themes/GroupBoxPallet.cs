#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region GroupBoxPallet

    public static class GroupBoxPallet
    {
        #region Declare

        public static Color Foreground;
        public static Color NormalBorder;

        #endregion

        #region Constructor

        static GroupBoxPallet()
        {
            GroupBoxPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(GroupBoxPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Foreground = OfficeColors.Foreground.OfficeColor1;
            NormalBorder = OfficeColors.Background.OfficeColor85;
        }

        #endregion
    } 

    #endregion
}
