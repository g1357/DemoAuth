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
    public partial class DayMenuPage : ContentPage
    {
        public DayMenuPage(DayMenu dayMenu = null)
        {
            InitializeComponent();

            BindingContext = new DayMenuViewModel(this, dayMenu);
        }
    }
}