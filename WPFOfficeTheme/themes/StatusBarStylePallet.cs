#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region StatusBarStylePallet

    public static class StatusBarStylePallet
    {
        #region Declare

        public static Color ForegroundColorBrush;

        #endregion

        #region Constructor

        static StatusBarStylePallet()
        {
            StatusBarStylePallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(StatusBarStylePallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            ForegroundColorBrush = OfficeColors.Foreground.OfficeColor1;
        }

        #endregion
    } 

    #endregion
}
