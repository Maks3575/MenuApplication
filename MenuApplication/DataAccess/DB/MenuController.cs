using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;
using MenuApplication.ModelDB; 

namespace MenuApplication.DataAccess.DB
{
    class MenuController : IMenuRepository
    {
        DB_MenuEntities context;

        public MenuController()
        {
            context = new DB_MenuEntities();
        }

        public void Add(IMenu NewMenu)
        {
            List<ModelDB.Dish> dishes = new List<ModelDB.Dish>();
            foreach (var i in NewMenu.Dishs)
            {
                dishes.Add(context.Dishes.FirstOrDefault(dish => dish.ExpandedNameDish == i.ExpandedNameDish));
            }
            context.Menus.Add(new ModelDB.Menu()
            {
                UseDate = NewMenu.DateCreateMenu,
                Subdivision = NewMenu.Subdivision,
                Employee = NewMenu.Calculator,
                Employee1 = NewMenu.ChiefCooker,
                TypeMenu = NewMenu.TypeMenu,
                Dishes = dishes
            });
            context.SaveChanges();
        }

        public IEnumerable<IMenu> Fetch()
        {
            var menus = SubdivisionController.CurrentSubdivision.Menus.ToList();
            foreach (var menu in menus)
            {
                menu.Dishs = menu.Dishes.Select(dish => DishController.FillingDish(dish, menu.UseDate)).ToList();
            }
            return menus;
        }

        public int idMenuNext()
        {
            throw new NotImplementedException();
        }
    }
}
