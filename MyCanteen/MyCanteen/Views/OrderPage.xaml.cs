using MyCanteen.Models;
using MyCanteen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        OrderViewModel vm;
        public OrderPage(Order order)
        {
            InitializeComponent();

            BindingContext = vm = new OrderViewModel(this, order);
        }
    }
}