# region Using

using System;
using System.Windows.Media; 

# endregion

namespace WPFOfficeTheme
{
	#region ListViewPallet

	public static class ListViewPallet
	{
		#region Declare

		public static Color Foreground;
		public static Color NormalBorder;
		public static Color BodyBackground;
		public static Color DisableBackGround;
		public static Color LightBorder;

		public static Color ButtonBackground1;
		public static Color ButtonBackground2;
		public static Color ButtonBackground3;
		public static Color ButtonBackground4;

		public static Color ButtonLightBackground1;
		public static Color ButtonLightBackground2;
		public static Color ButtonLightBackground3;
		public static Color ButtonLightBackground4;

		public static Color ControlsBackbround;
		public static Color DisabledBorder;
		public static Color DisabledForeground;

		#endregion

		#region Constructor

		static ListViewPallet()
		{
			ListViewPallet.Reset();
			OfficeColors.RegistersTypes.Add(typeof(ListViewPallet));
		}

		#endregion

		#region Reset

		public static void Reset()
		{
			Foreground = OfficeColors.Foreground.OfficeColor1;
			NormalBorder = OfficeColors.Background.OfficeColor82;
			BodyBackground = OfficeColors.Background.OfficeColor47;
			LightBorder = OfficeColors.HighLight.OfficeColor20;

			ButtonBackground1 = OfficeColors.Background.OfficeColor1;
			ButtonBackground2 = OfficeColors.Background.OfficeColor2;
			ButtonBackground3 = OfficeColors.Background.OfficeColor3;
			ButtonBackground4 = OfficeColors.Background.OfficeColor4;

			ButtonLightBackground1 = OfficeColors.HighLight.OfficeColor3;
			ButtonLightBackground2 = OfficeColors.HighLight.OfficeColor4;
			ButtonLightBackground3 = OfficeColors.HighLight.OfficeColor5;
			ButtonLightBackground4 = OfficeColors.HighLight.OfficeColor6;

			ControlsBackbround = OfficeColors.EditableControlsBackground.OfficeColor1;
			DisableBackGround = OfficeColors.Foreground.OfficeColor1;
			DisabledBorder = OfficeColors.Disabled.OfficeColor3;
			DisabledForeground = OfficeColors.Disabled.OfficeColor4;
		}

		#endregion
	}

	#endregion
}
