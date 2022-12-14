using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        MainViewModel viewModel;
        public ItemDetailPage()
        {
            InitializeComponent();
            xlayout.IsVisible = false;
            btnAdd.Clicked += BtnAdd_Clicked;
            xEdit.Unfocused += XEdit_Unfocused;

            //if (viewModel.SingleChecklist.Checklist.BackColor != "#009ACD")
            //{
            //    this.ToolbarItems.Clear();
            //}

            this.BindingContext = viewModel;
        }

        private void XEdit_Unfocused(object sender, FocusEventArgs e)
        {
            xlayout.IsVisible = false;
            btnAdd.IsVisible = true;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = false;
            xlayout.IsVisible = true;
            await Task.Delay(500);
            xEdit.Focus();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }

        private async void btnUpdateClick(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("", "Please enter a new list title?");
            if (!string.IsNullOrWhiteSpace(result))
            {
                var vm = this.BindingContext as ItemDetailViewModel;
                bool r = await vm.UpdateName(result);
                if (r)
                    await Navigation.PopAsync();
            }
        }

        private async void btnDeleteClick(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Inquiry?", "Sure to delete this list?", "OK", "Cancel");
            if (result)
            {
                var vm = this.BindingContext as ItemDetailViewModel;
                bool r = await vm.DeleteCheckList();
                if (r)
                    await Navigation.PopAsync();
            }
        }
    }
}