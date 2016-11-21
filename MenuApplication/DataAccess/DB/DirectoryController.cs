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

        public IEnumerable<TypeIngredient> TypeIngredientFetch() => Context.context.TypeIngredients.ToList();

        public IEnumerable<TypeDish> TypeDishFetch() => Context.context.TypeDishes.ToList();

        public IEnumerable<TypeMenu> TypeMenuFetch() => Context.context.TypeMenus.ToList();

        public IEnumerable<Employee> CalculatorFetch() => Context.context.Employees
            .Where(emp => emp.Position.NamePosition == "Калькулятор").ToList();

        public IEnumerable<Employee> ChiefCookerFetch() => Context.context.Employees
            .Where(emp => emp.Position.NamePosition == "Заведующий столовой" || emp.Position.NamePosition == "Шеф-повар").ToList();
    }
}
