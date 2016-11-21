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
        DB_MenuEntities context;

        public DirectoryController()
        {
            context = new DB_MenuEntities();
        }

        public IEnumerable<TypeIngredient> TypeIngredientFetch() => context.TypeIngredients.ToList();

        public IEnumerable<TypeDish> TypeDishFetch() => context.TypeDishes.ToList();

        public IEnumerable<TypeMenu> TypeMenuFetch() => context.TypeMenus.ToList();

        public IEnumerable<Employee> CalculatorFetch() => context.Employees
            .Where(emp => emp.Position.NamePosition == "Калькулятор").ToList();

        public IEnumerable<Employee> ChiefCookerFetch() => context.Employees
            .Where(emp => emp.Position.NamePosition == "Заведующий столовой" || emp.Position.NamePosition == "Шеф-повар").ToList();
    }
}
