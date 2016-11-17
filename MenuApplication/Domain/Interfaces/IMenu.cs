using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Domain
{   
    /// <summary>
    /// Интерфейс меню
    /// </summary>
    interface IMenu
    {
        /// <summary>
        /// Список блюд входящих в меню
        /// </summary>
        IList<Dish> Dishs { get; set; }



        /// <summary>
        /// Дата создания меню
        /// </summary>
        DateTime DateCreateMenu { get; set; }

        /// <summary>
        /// Id меню
        /// </summary>
        int IdMenu { get; }
    }
}
