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
    public partial class OrderHistoryPage : ContentPage
    {
        // Модель представления данной страницы
        OrderHistoryViewModel vm;
        // Флаг создания страницы
        bool creation;

        public OrderHistoryPage()
        {
            creation = true;

            InitializeComponent();

            BindingContext = vm = new OrderHistoryViewModel(this);
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