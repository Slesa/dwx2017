using System.Windows;
using System.Windows.Controls;

namespace BackOffice.Helpers
{
    public class ButtonHelper : Button
    {
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.RegisterAttached(
            "IconSource", typeof(string), typeof(ButtonHelper), new PropertyMetadata(default(string)));

        public static void SetIconSource(DependencyObject element, string value)
        {
            element.SetValue(IconSourceProperty, value);
        }

        public static string GetIconSource(DependencyObject element)
        {
            return (string) element.GetValue(IconSourceProperty);
        }
    }
}