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
    public partial class NewsPage : ContentPage
    {
        NewsViewModel vm;

        public NewsPage()
        {
            InitializeComponent();

            BindingContext = vm = new NewsViewModel(this);
        }
    }
}