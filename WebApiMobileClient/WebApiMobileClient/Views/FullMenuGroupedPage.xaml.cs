using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMobileClient.Helpers;
using WebApiMobileClient.Models;
using WebApiMobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiMobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullMenuGroupedPage : ContentPage
    {
        Stack<string> _stack;
        public FullMenuGroupedPage()
        {
            InitializeComponent();

            BindingContext = new FullMenuGroupedViewModel(this);
            xDishType.Text = "Вид Блюда";
            _stack = new Stack<string>();
        }

        private  void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == null)
                return;
            if (e.Item is IEnumerable)
            {
                Grouping<string, Dish> gr = (Grouping<string, Dish>)e.Item;
                if (xDishType.Text != gr.Key)
                {
                    _stack.Push(xDishType.Text);
                    xDishType.Text = gr.Key;
                }
                //DisplayAlert("Event: ItemAppearing", gr.Key, "Ok");
                //var list = (IEnumerable) e.Item;
                //string msg = "";
                //foreach (Dish item in list)
                //{
                //    msg += item.Name + "; ";
                //}
                //DisplayAlert("Event: ItemAppearing", msg, "Ok");
            }
            else
            {
                //var dish = (Dish) e.Item;
                //DisplayAlert("Event: ItemAppearing", dish.Name, "Ok");
            }
        }

        private void ListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == null)
                return;
            if (e.Item is IEnumerable)
            {
                Grouping<string, Dish> gr = (Grouping<string, Dish>)e.Item;
                if (xDishType.Text == gr.Key)
                {
                    xDishType.Text =  _stack.Pop();
                    //xDishType.Text = gr.Key;
                }
                xDishType.Text = gr.Key;
                //DisplayAlert("Event: ItemDisAppearing", gr.Key, "Ok");
                //    var list = (IEnumerable)e.Item;
                //    string msg = "";
                //    foreach (Dish item in list)
                //    {
                //        msg += item.Name + "; ";
                //    }
                //    DisplayAlert("Event: ItemDisAppearing", msg, "Ok");
            }
            //else
            //{
            //    var dish = (Dish)e.Item;
            //    DisplayAlert("Event: ItemDisAppearing", dish.Name, "Ok");
            //}

        }
    }
}