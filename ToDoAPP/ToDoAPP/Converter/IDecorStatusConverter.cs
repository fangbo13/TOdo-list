using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class IDecorStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))/* determine that the result is not equal to null and is a boolean type Return the result of the sliding line */
            {
                if (result) return TextDecorations.Strikethrough;/* return to underlining effect*/
            }
            return TextDecorations.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TextDecorations.None;
        }
    }
}