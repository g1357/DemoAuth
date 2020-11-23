using System;
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
    public partial class DayMenuPage : ContentPage
    {
        //public DayMenuPage()
        //{
        //    InitializeComponent();
        //}
        public DayMenuPage(DayMenu dayMenu = null)
        {
            InitializeComponent();

            BindingContext = new DayMenuViewModel(this, dayMenu);
        }
    }
}