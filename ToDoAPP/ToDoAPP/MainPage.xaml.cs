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
            this.BindingContext =new MainViewModel();/*绑定*/
        }

        //private void ListView_ItemSelected(object sender,SelectedPositionChangedEventArgs e)
        //{
        //    ListView lv = sender as ListView;
        //    lv.SelectedItem = null;/*背景颜色消失*/
        //}
    }
}
