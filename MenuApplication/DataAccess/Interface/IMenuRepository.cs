using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{   
    /// <summary>
    /// Интерфейс репозитория для меню
    /// </summary>
    interface IMenuRepository
    {   
        /// <summary>
        /// Возвращает список меню
        /// </summary>
        /// <returns></returns>
        IEnumerable<IMenu> Fetch();

        /// <summary>
        /// Проверяет существует ли меню на заданную дату такого же типа
        /// </summary>
        /// <param name="DT">Дата</param>
        /// <param name="TM">Тип Меню</param>
        /// <returns>true если такое уже существует</returns>
        bool CheckOnTypeMenu(DateTime DT, string TM);

        int idMenuNext();

        /// <summary>
        /// Добавляет в репозиторий меню новый экземпляр
        /// </summary>
        /// <param name="NewMenu">Добавляемое в репозиторий меню</param>
        void Add(IMenu NewMenu);
    }
}
