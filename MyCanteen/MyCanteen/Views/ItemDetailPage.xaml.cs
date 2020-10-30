using System.ComponentModel;
using Xamarin.Forms;
using MyCanteen.ViewModels;

namespace MyCanteen.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}