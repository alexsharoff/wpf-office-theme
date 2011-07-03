#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region ProgressBarPallet

    public static class ProgressBarPallet
    {
        #region Declare

        public static Color Foreground;
        public static Color NormalBorder;
        public static Color Background;
        public static Color AnimationHighLight;

        #endregion

        #region Constructor

        static ProgressBarPallet()
        {
            ProgressBarPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ProgressBarPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Foreground = OfficeColors.HighLight.OfficeColor2;
            NormalBorder = OfficeColors.Background.OfficeColor3;
            Background = OfficeColors.Background.OfficeColor85;
            AnimationHighLight = OfficeColors.HighLight.OfficeColor3;
            AnimationHighLight.A = 150;
        }

        #endregion
    } 

    #endregion
}
