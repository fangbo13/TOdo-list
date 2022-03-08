using GalaSoft.MvvmLight.Messaging;
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
            Messenger.Default.Register<SingleChecklist>(this, "OpenDetailPage", OpenDetailPage);
        }

        private async void OpenDetailPage(SingleChecklist obj)
        {
             (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex(obj.Checklist.BackColor);// 将子窗口标题头部的颜色和图标一致
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(obj))
            {
                Title = obj.Checklist.Title,
                BackgroundColor = Color.FromHex(obj.Checklist.BackColor)/*设置背景颜色为图标颜色一致*/
            });
            await Task.Delay(100);
            collView.SelectedItem = null;/*背景颜色消失*/
        }

      
    }
}
