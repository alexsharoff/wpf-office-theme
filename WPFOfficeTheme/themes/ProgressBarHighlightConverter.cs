#region Using

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Animation;
using System.Globalization; 

#endregion

namespace WPFOfficeTheme
{
    public class ProgressBarHighlightConverter : IMultiValueConverter
    {
        #region Convert

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Type type = typeof(double);
            if ((((values == null) || (values.Length != 3)) || ((values[0] == null) || (values[1] == null))) || (((values[2] == null) || !typeof(Brush).IsAssignableFrom(values[0].GetType())) || (!type.IsAssignableFrom(values[1].GetType()) || !type.IsAssignableFrom(values[2].GetType()))))
            {
                return null;
            }
            Brush brush = (Brush)values[0];
            double d = (double)values[1];
            double num2 = (double)values[2];
            if ((((d <= 0) || double.IsInfinity(d)) || (double.IsNaN(d) || (num2 <= 0))) || (double.IsInfinity(num2) || double.IsNaN(num2)))
            {
                return null;
            }
            DrawingBrush brush2 = new DrawingBrush();
            double width = d * 2;
            brush2.Viewport = brush2.Viewbox = new Rect(-d, 0, width, num2);
            brush2.ViewportUnits = brush2.ViewboxUnits = BrushMappingMode.Absolute;
            brush2.TileMode = TileMode.None;
            brush2.Stretch = Stretch.None;
            DrawingGroup group = new DrawingGroup();
            DrawingContext context = group.Open();
            context.DrawRectangle(brush, null, new Rect(-d, 0, d, num2));
            TimeSpan keyTime = TimeSpan.FromSeconds(width / 200);
            TimeSpan span2 = TimeSpan.FromSeconds(1);
            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            animation.BeginTime = new TimeSpan?(TimeSpan.Zero);
            animation.Duration = new Duration(keyTime + span2);
            animation.RepeatBehavior = RepeatBehavior.Forever;

            animation.KeyFrames.Add(new LinearDoubleKeyFrame(width, keyTime));
            TranslateTransform transform = new TranslateTransform();
            transform.BeginAnimation(TranslateTransform.XProperty, animation);
            brush2.Transform = transform;
            context.Close();
            brush2.Drawing = group;
            return brush2;
        } 

        #endregion

        #region ConvertBack

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        } 

        #endregion
    }
}
