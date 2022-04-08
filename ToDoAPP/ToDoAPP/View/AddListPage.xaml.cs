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
    public partial class AddListPage : ContentPage
    {
        MainViewModel viewmodel;
        public AddListPage()
        {
            InitializeComponent();
            viewmodel = new MainViewModel();
            this.BindingContext = viewmodel;
        }
    }
}