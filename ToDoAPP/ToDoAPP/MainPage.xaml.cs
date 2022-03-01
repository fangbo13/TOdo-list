using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Module;
using ToDoApp.ViewModel;
using ToDoAPP.View;
using ToDoAPP.ViewModel;
using Xamarin.Forms;

namespace ToDoAPP
{

    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);/*头部隐藏蓝色区域*/
            this.BindingContext = new MainViewModel();/*绑定到MainBViewmodel*/
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;

            var m = lv.SelectedItem as MenuModel;

            if (m == null) return;

            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex(m.BackColor);// 将子窗口标题头部的颜色和图标一致

            Navigation.PushAsync(new ItemDetailPage()

            {
                Title = m.Title,
                BackgroundColor = Color.FromHex(m.BackColor),/*设置背景颜色为图标颜色一致*/
                BindingContext = new ItemDetailViewModel(m.TaskInfos)
            });

            lv.SelectedItem = null;/*背景颜色消失*/
        }

        private void ListViewSub_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;/*背景颜色消失*/
        }
    }
}
