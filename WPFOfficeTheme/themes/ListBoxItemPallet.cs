#region Using

using System;
using System.Windows.Media; 

#endregion

namespace WPFOfficeTheme
{
    #region ListBoxPallet

    public static class ListBoxItemPallet
    {
        #region Declare

        public static Color DisabledForeground;

        public static Color SelectedBackground1;
        public static Color SelectedBackground2;
        public static Color SelectedBackground3;
        public static Color SelectedBackground4;

        public static Color SelectedBorder;

        #endregion

        #region Constructor

        static ListBoxItemPallet()
        {
            ListBoxItemPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ListBoxItemPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            DisabledForeground = OfficeColors.Foreground.OfficeColor1;

            SelectedBackground1 = OfficeColors.HighLight.OfficeColor3;
            SelectedBackground2 = OfficeColors.HighLight.OfficeColor4;
            SelectedBackground3 = OfficeColors.HighLight.OfficeColor5;
            SelectedBackground4 = OfficeColors.HighLight.OfficeColor6;

            SelectedBorder = OfficeColors.HighLight.OfficeColor20;
        }

        #endregion
    } 

    #endregion
}
