using MyCanteen.Helpers;
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
    public partial class MyOrdersPage : ContentPage
    {
        // Модель представления данной страницы
        MyOrdersViewModel vm;
        // Флаг создания страницы
        bool creation;

        public MyOrdersPage()
        {
            creation = true;

            InitializeComponent();

            BindingContext = vm = new MyOrdersViewModel(this);
        }

        // Вызывается перед тем, как страница становится видимой.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (creation)
            {
                creation = false;
            }
            else
            {
                vm.RefreshItems();
            }
        }
    }
}