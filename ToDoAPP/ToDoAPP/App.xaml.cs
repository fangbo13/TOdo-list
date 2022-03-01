using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());/*把mainpage当为导航页，当点击功能时通过navigation.pushAsync（）推送的屏幕上方*/
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
