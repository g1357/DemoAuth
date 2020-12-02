using MyCanteen.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Services
{
    /// <summary>
    /// Интерфейс для "тяжёлого" сервиса столовой
    /// </summary>
    public interface ICanteenHeavyService
    {
        List<MenuOrder> GetCurrentMenuOrderListAsync();
    }
}
