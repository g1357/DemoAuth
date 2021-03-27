using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MyCanteen.ViewModels
{
    public class AllUsersViewModel : BaseViewModel
    {
        private readonly IUsersService usersService;

        private readonly AllUsersPage page;
        public ObservableCollection<UserModel> Items { get; set; }

        public AllUsersViewModel(IUsersService usersService, AllUsersPage page)
        {
            this.usersService = usersService;
            this.page = page;

            Items = new ObservableCollection<UserModel>();
            ExecuteLoadItemsCommand();//.Wait();

        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                Items.Clear();
                var items = await usersService.GetAllUsers();
                //Items = new ObservableCollection<Order>(Items);
                foreach (var item in items)
                {
                        Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
