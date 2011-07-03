#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region TextBoxPallet

    public static class TextBoxPallet
    {
        #region Declare

        public static Color NormalBorderBrush;
        public static Color ControlsBackGroundBrush;
        public static Color DisabledBorderBrush;
        public static Color DisabledForegroundBrush;

        #endregion

        #region Constructor

        static TextBoxPallet()
        {
            TextBoxPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(TextBoxPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            NormalBorderBrush = OfficeColors.Background.OfficeColor82;
            ControlsBackGroundBrush = OfficeColors.EditableControlsBackground.OfficeColor1;
            DisabledBorderBrush = OfficeColors.Disabled.OfficeColor3;
            DisabledForegroundBrush = OfficeColors.Disabled.OfficeColor4;
        }

        #endregion
    } 

    #endregion
}
