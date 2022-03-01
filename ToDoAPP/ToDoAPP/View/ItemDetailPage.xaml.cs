using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            xlayout.IsVisible = false;//启动时默认隐藏
            btnAdd.Clicked += BtnAdd_Clicked;
            xEdit.Unfocused += XEdit_Unfocused;
        }
        private void XEdit_Unfocused(object sender, FocusEventArgs e)
        {
            //当输入框失去焦点后，把layout隐藏，然后再显示按钮
            xlayout.IsVisible = false;
            btnAdd.IsVisible = true;
        }
        private void BtnAdd_Clicked(object sender,EventArgs e)
        {
            btnAdd.IsVisible = false;
            xlayout.IsVisible = true;
            xEdit.Focus();
        }
    }
}