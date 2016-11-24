using MenuApplication.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess.DB
{
    class DirectoryController
    {


        public DirectoryController()
        {
        }

        /// <summary>
        /// Возвращает список всех типов ингредиентов
        /// </summary>
        /// <returns>Список типов ингредиентов</returns>
        public IEnumerable<TypeIngredient> TypeIngredientFetch() => Context.context.TypeIngredients.ToList();

        /// <summary>
        /// Возвращает список всех типов блюд
        /// </summary>
        /// <returns>Список типов блюд</returns>
        public IEnumerable<TypeDish> TypeDishFetch() => Context.context.TypeDishes.ToList();

        /// <summary>
        /// Возвращает список всех типов меню
        /// </summary>
        /// <returns>Список типов меню</returns>
        public IEnumerable<TypeMenu> TypeMenuFetch() => Context.context.TypeMenus.ToList();

        /// <summary>
        /// Возвращает список калькуляторов
        /// </summary>
        /// <returns>список калькуляторов</returns>
        public IEnumerable<Employee> CalculatorFetch() => Context.context.Employees
            .Where(emp => emp.Position.NamePosition == "Калькулятор").ToList();

        /// <summary>
        /// Возвращает список материально ответственных лиц
        /// </summary>
        /// <returns>Список МОЛ</returns>
        public IEnumerable<Employee> ChiefCookerFetch() => Context.context.Employees
            .Where(emp => emp.Position.NamePosition == "Заведующий столовой" || emp.Position.NamePosition == "Шеф-повар").ToList();
    }
}
