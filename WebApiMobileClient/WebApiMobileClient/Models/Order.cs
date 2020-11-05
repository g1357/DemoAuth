using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public  class Order : OrderDTO
    {
        public int MyProperty { get; set; }
    }
}
