using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    public class OrderVideModel : BaseViewModel
    {
        OrderPage _page;

        public OrderVideModel(OrderPage page)
        {
            _page = page;
        }
    }
}
