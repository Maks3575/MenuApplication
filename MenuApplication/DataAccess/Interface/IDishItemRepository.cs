using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{
    /// <summary>
    /// Интерфейс репозитория для полей калькуляционной карты
    /// </summary>
    interface IDishItemRepository
    {
        /// <summary>
        /// Возвращает список полей калькуляционной карточки
        /// </summary>
        /// <returns>Список полей калькуляционной карточки</returns>
        IEnumerable<IDishItem> Fetch();

        /// <summary>
        /// Добавляет поле калькуляционной карточки в репозиторий 
        /// </summary>
        /// <param name="newDishItem">Добавляемое поле</param>
        void Add(IDishItem newDishItem);

    }
}

