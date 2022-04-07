using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Module;
using ToDoApp.View;
using ToDoApp.ViewModel;
using Xamarin.Forms;

namespace ToDoApp
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);/*Hidden blue area on the head*/
            viewModel = new MainViewModel();
            this.BindingContext = viewModel;/*Bind to MainBViewmodel*/
            Messenger.Default.Register<SingleChecklist>(this, "OpenDetailPage", OpenDetailPage);
            Messenger.Default.Register<string>(this, "Add", Add);
            Messenger.Default.Register<string>(this, "Query", Query);
        }

        private async void Query(string obj)
        {
            ItemQueryViewModel viewModel = new ItemQueryViewModel(new SingleChecklist());
            await Navigation.PushAsync(new ItemQueryPage() { BindingContext = viewModel });
        }

        private async void Add(string obj)
        {
            var result = await DisplayPromptAsync("", "Please enter the list title?");
            if (!string.IsNullOrWhiteSpace(result))
            {
                viewModel.AddCheckList(new Checklist()
                {
                    Title = result,
                    Id = Guid.NewGuid().ToString(),
                    IconFont = "\xe63b",
                    BackColor = "#009ACD",
                });
            }
        }

        private async void OpenDetailPage(SingleChecklist obj)
        {
            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex(obj.Checklist.BackColor);// Align the colour of the child window header with the icon
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(obj))
            {
                Title = obj.Checklist.Title,
                BackgroundColor = Color.FromHex(obj.Checklist.BackColor)/*Set the background colour to be the same as the icon colour*/
            });
            await Task.Delay(200);
            collView.SelectedItem = null; /*Background colour disappears*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.InitMainViewModel();
        }
    }
}
