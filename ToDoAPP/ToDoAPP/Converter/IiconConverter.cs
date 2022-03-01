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
            if (value != null && bool.TryParse(value.ToString(), out bool result))/*判断value是否为null和布尔值*/
            {
                var r = parameter.ToString();
                if (result)/*判断result*/
                {
                    if (r == "Left")/*当左边图标结果为True是*/
                        return "\xe69e";/*返回正确对钩图标*/
                    else
                        return "\xe61a";/*不是则星星收藏图标*/
                }
                else/*如果是false*/
                {
                    if (r == "Left")
                        return "\xe80c";/*左边返回空心圆*/
                    else
                        return "\xe625"; /*右边返回空心五角星*/
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
