# region Using Directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

# endregion

namespace WPFOfficeTheme
{
	public class HeaderedPanel : HeaderedContentControl
	{
		# region Static Constructor

        static HeaderedPanel()
		{
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeaderedPanel),
                new FrameworkPropertyMetadata(typeof(HeaderedPanel)));
		}
                
		# endregion
	}
}
