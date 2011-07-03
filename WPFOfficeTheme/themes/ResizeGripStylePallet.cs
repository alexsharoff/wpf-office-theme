#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region ResizeGripStylePallet

    public static class ResizeGripStylePallet
    {
        #region Declare

        public static Color ResizeGripDark;
        public static Color ResizeGripLight;

        #endregion

        #region Constructor

        static ResizeGripStylePallet()
        {
            ResizeGripStylePallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ResizeGripStylePallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            ResizeGripDark = OfficeColors.Background.OfficeColor27;
	        ResizeGripLight = OfficeColors.Background.OfficeColor28;
        }

        #endregion
    } 

    #endregion
}
