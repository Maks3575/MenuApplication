using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{   
    /// <summary>
    /// Интерфейс репозитория для калькуляционных карточек
    /// </summary>
    interface IDishRepository
    {
        /// <summary>
        /// Возвращает список калькуляционных карточек
        /// </summary>
        /// <returns>Список калькуляционной карточки</returns>
        IEnumerable<IDish> Fetch();

        int NumberDocNext();

        /// <summary>
        /// Добавляет калькуляционную карточку в репозиторий 
        /// </summary>
        /// <param name="newDish">Добавляемое поле</param>
        void Add(IDish newDish);

        /// <summary>
        /// ВОзвращает самую свежую калькуляционную карточку по названию блюда
        /// </summary>
        /// <param name="ExpandedNameDish">Расширенное название искомого блюда</param>
        /// <returns>Свежая калькуляционная карточка</returns>
        IDish GetDishByName(string ExpandedNameDish);

        /// <summary>
        /// Возвращает историю калькуляционной карточки
        /// </summary>
        /// <param name="ExpandedNamedish">Расширенное имя калькуляционной карточки</param>
        /// <returns>Список всех калькуляционных карточек с заданным именем</returns>
        IEnumerable<IDish> HistoryDish(string ExpandedNamedish);

        /// <summary>
        /// Возвращает список в котором находятся все блюда в единственном самом новом экземпляре
        /// </summary>
        /// <returns>Список самых новых блюд</returns>
        IEnumerable<IDish> LatestDish();

        /// <summary>
        /// Проверяет содержится ли блюдо в репозитории
        /// </summary>
        /// <param name="dish">Проверяемое блюдо</param>
        /// <returns>true если содержится</returns>
        bool CheckOnContain(IDish dish);

        /// <summary>
        /// Проверка на уникальность расширенного названия блюда TRUE если не уникально
        /// </summary>
        /// <param name="ExpandedNameDish">Проверяемое расширенное наименование блюда</param>
        /// <returns>TRUE если не уникально</returns>
        bool CheckOnExpandedNameDish(string ExpandedNameDish);
    }
}
