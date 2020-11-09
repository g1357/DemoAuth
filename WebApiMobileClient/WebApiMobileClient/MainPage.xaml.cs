﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMobileClient.Services;
using WebApiMobileClient.Views;
using Xamarin.Forms;

namespace WebApiMobileClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            new CanteenDemoService();
        }

        private async void NavigateToLognPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void NavigateToMainMenuPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenuPage());
        }

    }
}
