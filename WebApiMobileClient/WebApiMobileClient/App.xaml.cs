using System;
using WebApiMobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiMobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<CanteenDemoService>();

            MainPage = new NavigationPage(new MainPage());
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
