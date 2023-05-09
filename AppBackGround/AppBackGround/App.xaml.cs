using AppBackGround.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBackGround
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IForegroundService>();

            MainPage = new MainPage();
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
