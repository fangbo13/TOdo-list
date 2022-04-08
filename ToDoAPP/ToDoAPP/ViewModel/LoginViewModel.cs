using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp;
using ToDoApp.Core;
using ToDoAPP.Interfaces;
using ToDoAPP.Module;
using ToDoAPP.Service;
using Xamarin.Forms;

namespace ToDoAPP.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }
        APIInterface service;
        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            service = ServiceProvider.Instance.Get<APIInterface>();
        }

        public RelayCommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            var result = service.UserLogin(User.UserName, User.UserPwd);
            if (result.IsSuccess)
            {
                UserContext.UserID =result.ResultData["ID"].ToString();
                UserContext.UserName = result.ResultData["UserName"].ToString();
                UserContext.Remark = result.ResultData["Remark"].ToString();
                Application.Current.MainPage = new MainPage();
                //await Navigation.PushAsync(new MainPage());
               // await Shell.Current.GoToAsync("MainPage");
            }
            else
            {
                Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                Application.Current.MainPage.DisplayAlert("Error", result.ResultMsg, "OK"));
            }

        }

        #region

        private UserInfo _User = new UserInfo();

        public UserInfo User
        {
            get { return _User; }
            set { _User = value; RaisePropertyChanged(nameof(User)); }
        }


        //private ObservableCollection<UserInfo> _User = new ObservableCollection<UserInfo>();

        //public ObservableCollection<UserInfo> User
        //{
        //    get { return _User; }
        //    set { _User = value; RaisePropertyChanged(nameof(User)); }
        //}

        #endregion
    }
}
