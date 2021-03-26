using MyCanteen.Services;
using MyCanteen.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllUsersPage : ContentPage
    {
        AllUsersViewModel vm;
        //public ObservableCollection<string> Items { get; set; }

        public AllUsersPage()
        {
            InitializeComponent();

            var usersService = DependencyService.Get<IUsersService>();
            vm = new AllUsersViewModel(usersService, this);
            BindingContext = vm;
/*
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView.ItemsSource = Items;
*/
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
