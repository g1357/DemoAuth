using MyCanteen.Models;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.ViewModels
{
    public class OrderVideModel : BaseViewModel
    {
        OrderPage _page;
        Order _order;
        public Order ThisOrder
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }

        public OrderVideModel(OrderPage page, Order order)
        {
            _page = page;
            _order = order;
        }
    }
}
