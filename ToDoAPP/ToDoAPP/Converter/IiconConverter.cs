using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class IiconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))/* Determine if value is null and boolean*/
            {
                var r = parameter.ToString();
                if (result)/*judge result*/
                {
                    if (r == "Left")/* When the left icon results in True */
                        return "\xe69e";/* Return the correct pair of hook icons*/
                    else
                        return "\xe61a";/*not then star collection icon*/
                }
                else/* if false*/
                {
                    if (r == "Left")
                        return "\xe80c";/*left returns hollow circle*/
                    else
                        return "\xe625"; /*right return hollow pentagram*/
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}