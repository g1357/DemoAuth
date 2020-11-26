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
            LoadLocalData();
        }

        protected override void OnSleep()
        {
            // Сохранение существующих заказов в локальном файле
            var _canteenService = DependencyService.Get<CanteenDemoService>();
            _canteenService.SaveOrdersAsync();
        }

        protected override void OnResume()
        {
            LoadLocalData();
        }
        
        void LoadLocalData()
        {
            // Загрузка существующих заказов из локального файла
            var _canteenService = DependencyService.Get<CanteenDemoService>();
            _canteenService.ReadOrdersAsync();

        }
    }
}
