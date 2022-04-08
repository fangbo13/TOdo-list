using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            lable_title.Text= viewmodel.GetTitle();
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Question?", "Are you sure to delete the list?", "Yes", "No");
            if (answer)
            {
                viewmodel.DeleteList();
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("modify", "Please enter a new list name");
            Debug.WriteLine("Action: " + result);
            if (!string.IsNullOrEmpty(result))
            {
                viewmodel.ModifyListName(result);
                lable_title.Text = viewmodel.GetTitle();
            }
            

        }
    }
}