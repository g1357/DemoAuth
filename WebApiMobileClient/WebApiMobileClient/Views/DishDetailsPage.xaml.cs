﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMobileClient.Models;
using WebApiMobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiMobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DishDetailsPage : ContentPage
    {
        public DishDetailsPage()
        {
            InitializeComponent();
        }

        public DishDetailsPage(Dish dish) :this()
        {
            BindingContext = new DishDetailsViewModel(dish);

        }
    }
}