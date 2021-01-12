using MyCanteen.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrenMenuPage : ContentPage
    {
        // Модель представления данной страницы
        CurrentMenuViewModel vm;
        // Флаг создания страницы
        bool creation;
        public CurrenMenuPage()
        {
            // Установка начального создания 
            creation = true;

            InitializeComponent();

            BindingContext = vm = new CurrentMenuViewModel(this);
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