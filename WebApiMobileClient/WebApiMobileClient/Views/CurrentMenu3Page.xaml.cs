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
    public partial class CurrentMenu3Page : ContentPage
    {
        public CurrentMenu3Page()
        {
            InitializeComponent();

            BindingContext = new CurrentMenu3ViewModel(this);
        }
    }
}