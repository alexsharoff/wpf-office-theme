# region Using

using System;
using System.Windows.Media; 

# endregion

namespace WPFOfficeTheme
{
    # region ButtonPallet

    public static class ButtonPallet
    {
        #region Declare

        public static Color Font;
        public static Color NormalBorderBrush;
        public static Color LightBorderBrush;
        public static Color PlusLightBorderBrush;
        public static Color DisabledBorderBrush;
        public static Color DisabledForegroundBrush;

        public static Color NormalBackGroundBrush1;
        public static Color NormalBackGroundBrush2;
        public static Color NormalBackGroundBrush3;
        public static Color NormalBackGroundBrush4;

        public static Color DefaultControlMouseOver1;
        public static Color DefaultControlMouseOver2;
        public static Color DefaultControlMouseOver3;
        public static Color DefaultControlMouseOver4;

        public static Color DefaultControlPressed1;
        public static Color DefaultControlPressed2;
        public static Color DefaultControlPressed3;
        public static Color DefaultControlPressed4;
        public static Color DefaultControlPressed5;

        public static Color DisableBackGroundBrush1;
        public static Color DisableBackGroundBrush2;

        #endregion

        #region Constructor

        static ButtonPallet()
        {
            ButtonPallet.Reset();
            OfficeColors.RegistersTypes.Add(typeof(ButtonPallet));
        }

        #endregion

        #region Reset

        public static void Reset()
        {
            Font = OfficeColors.Foreground.OfficeColor1;
            NormalBorderBrush = OfficeColors.Background.OfficeColor82;
            LightBorderBrush = OfficeColors.HighLight.OfficeColor20;
            PlusLightBorderBrush = OfficeColors.HighLight.OfficeColor21;
            DisabledBorderBrush = OfficeColors.Disabled.OfficeColor3;
            DisabledForegroundBrush = OfficeColors.Disabled.OfficeColor3;

            NormalBackGroundBrush1 = OfficeColors.Background.OfficeColor1;
            NormalBackGroundBrush2 = OfficeColors.Background.OfficeColor2;
            NormalBackGroundBrush3 = OfficeColors.Background.OfficeColor3;
            NormalBackGroundBrush4 = OfficeColors.Background.OfficeColor4;

            DefaultControlMouseOver1 = OfficeColors.HighLight.OfficeColor3;
            DefaultControlMouseOver2 = OfficeColors.HighLight.OfficeColor4;
            DefaultControlMouseOver3 = OfficeColors.HighLight.OfficeColor5;
            DefaultControlMouseOver4 = OfficeColors.HighLight.OfficeColor6;

            DefaultControlPressed1 = OfficeColors.HighLight.OfficeColor8;
            DefaultControlPressed2 = OfficeColors.HighLight.OfficeColor9;
            DefaultControlPressed3 = OfficeColors.HighLight.OfficeColor10;
            DefaultControlPressed4 = OfficeColors.HighLight.OfficeColor11;
            DefaultControlPressed5 = OfficeColors.HighLight.OfficeColor12;

            DisableBackGroundBrush1 = OfficeColors.Disabled.OfficeColor1;
            DisableBackGroundBrush2 = OfficeColors.Disabled.OfficeColor2;
        }

        #endregion
    } 

    # endregion
}
