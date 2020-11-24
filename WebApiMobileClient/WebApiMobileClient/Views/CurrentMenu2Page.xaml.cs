using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiMobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentMenu2Page : ContentPage
    {
        public CurrentMenu2Page()
        {
            InitializeComponent();

            BindingContext = new CurrentMenu2ViewModel(this);
        }
    }
}