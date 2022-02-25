using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class IValueDiaplayConverter : IValueConverter/*添加转换器*/
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))/*如果不等于null就进行处理*/
            {
                if (result == 0)/*等于0返回空*/
                    return "";
                return result;/*大于0返回result*/
            }
            return "";/*不符合返回空*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";/*因为用不到所以直接返回空值*/
        }
    }
}
