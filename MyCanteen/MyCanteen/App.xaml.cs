﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyCanteen.Services;
using MyCanteen.Views;
using MyCanteen.Services.Interfaces;

namespace MyCanteen
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();

            DependencyService.Register<ICanteenService, CanteenService>();
            //DependencyService.Register<CanteenDemoService>();

            DependencyService.Register<IUsersService, UsersService>();
            
            LoadLocalData();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            //LoadLocalData();
        }

        protected override void OnSleep()
        {
            // Сохранение существующих заказов в локальном файле
            var _canteenService = DependencyService.Get<ICanteenService>();
            _canteenService?.SaveOrdersAsync();
        }

        protected override void OnResume()
        {
            LoadLocalData();
        }
        public async void LoadLocalData()
        {
            // Загрузка существующих заказов из локального файла
            var _canteenService = DependencyService.Get<ICanteenService>();
            await _canteenService?.LoadOrdersAsync();
        }
    }
}
