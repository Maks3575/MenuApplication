using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuApplication.Domain;

namespace MenuApplication.DataAccess
{   
    /// <summary>
    /// Интерфейс репозитория для игредиентов
    /// </summary>
    interface IIngredientRepositopy
    {   
        /// <summary>
        /// Возвращает список ингредиентов
        /// </summary>
        /// <returns>Список ингредиентов</returns>
        IEnumerable<IIngredient> Fetch();

        /// <summary>
        /// Проверка на актуальность ингредиента
        /// </summary>
        /// <param name="ingr">Проверяемый ингредиент</param>
        /// <returns>Актуален ли элемент</returns>
        bool TestOnChangeIngredient(IIngredient ingr);

        /// <summary>
        /// Добавляет обновленный ингредиент в репозиторий 
        /// </summary>
        /// <param name="newIngredient">Добавляемый объект</param>
        void Add(IIngredient newIngredient);

        /// <summary>
        /// Добавляет новый ингредиент в репозиторий
        /// </summary>
        /// <param name="newIngredient">Добавляемый ингредиент</param>
        bool AddNewIngredient(IIngredient newIngredient);

        /// <summary>
        /// Получение объекта ингредиента по имени
        /// </summary>
        /// <returns>Ингредиент</returns>
        IIngredient GetIngrByName(string Object);

        /// <summary>
        /// Возвращает список ингредиентов в котором находится по одному экземпляру всех ингредиентов (самые новые)
        /// </summary>
        /// <returns>Актуальный реестр цен</returns>
        IEnumerable<IIngredient> GetRegistry();

        //class IngredientComparerForSaving : IEqualityComparer<IIngredient>();

    }
}
