using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp;
using ToDoAPP.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewmodel;
        public LoginPage()
        {
            InitializeComponent();
            viewmodel = new LoginViewModel(Navigation);
            this.BindingContext= viewmodel;
        }
    }
}