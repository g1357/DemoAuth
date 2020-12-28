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
    public partial class FullMenuPage : ContentPage
    {
        FullMenuViewModel vm;

        public FullMenuPage()
        {
            InitializeComponent();

            BindingContext = vm = new FullMenuViewModel(this);
        }
    }
}