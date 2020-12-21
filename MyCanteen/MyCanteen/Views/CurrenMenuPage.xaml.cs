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
        bool creation;
        public CurrenMenuPage()
        {
            creation = true;
            InitializeComponent();

            BindingContext = new CurrentMenuViewModel(this);
        }

        // Вызывается перед тем, как страница становится видимой.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("On Appearing!");
            if (creation)
            {
                creation = false;
            }
            else
            {
                Debug.WriteLine("On Appearing! Return!");
                ((CurrentMenuViewModel)BindingContext).ExecuteLoadItemsCommand().Wait();
            }
        }
    }
}