using MyCanteen.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel vm;
        public AboutPage()
        {
            InitializeComponent();

            BindingContext = vm = new AboutViewModel(this);
        }
    }
}