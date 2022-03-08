using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class IValueDiaplayConverter : IValueConverter/*Add converter*/
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))/*Process if not equal to null*/
            {
                if (result == 0)/*Equal to 0 returns null*/
                    return "";
                return result;/*Greater than 0 returns result*/
            }
            return "";/*Does not match return null*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";/*Return empty value because it is not used*/
        }
    }
}