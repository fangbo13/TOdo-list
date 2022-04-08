using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleListPage : ContentPage
    {
        MainViewModel viewmodel;
        public ScheduleListPage()
        {
            InitializeComponent();
           
            viewmodel = new MainViewModel();
            viewmodel.LoadDetailList();
            this.BindingContext = viewmodel;

            xlayout.IsVisible = false;
            btnAdd.Clicked += BtnAdd_Clicked;
            xEdit.Unfocused += XEdit_Unfocused;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = false;
            xlayout.IsVisible = true;
            await Task.Delay(500);
            xEdit.Focus();
        }

        private void XEdit_Unfocused(object sender, FocusEventArgs e)
        {
            xlayout.IsVisible = false;
            btnAdd.IsVisible = true;
        }

    }
}