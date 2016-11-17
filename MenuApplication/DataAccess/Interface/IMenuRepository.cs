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

        int idMenuNext();

        /// <summary>
        /// Добавляет в репозиторий меню новый экземпляр
        /// </summary>
        /// <param name="NewMenu">Добавляемое в репозиторий меню</param>
        void Add(IMenu NewMenu);
    }
}
