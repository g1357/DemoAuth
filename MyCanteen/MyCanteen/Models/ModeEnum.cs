using System;
using System.Collections.Generic;
using System.Text;

namespace MyCanteen.Models
{
    /// <summary>
    /// Перечисление режима работы приложения
    /// </summary>
    public enum ModeEnum
    {
        Production = 1, // Производственный режим
        LocalDemo = 2,  // Режим локальной демонстрации
        InternetDemo =3 // Режим сетевой демонстрации
    }
}
