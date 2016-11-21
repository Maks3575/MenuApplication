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
       

        public MenuController()
        {
        }

        public void Add(IMenu NewMenu)
        {
            List<ModelDB.Dish> dishes = new List<ModelDB.Dish>();
            foreach (var i in NewMenu.Dishs)
            {
                dishes.Add(Context.context.Dishes.FirstOrDefault(dish => dish.ExpandedNameDish == i.ExpandedNameDish));
            }
            Context.context.Menus.Add(new ModelDB.Menu()
            {
                UseDate = NewMenu.DateCreateMenu,
                IDSubdivision = SubdivisionController.CurrentSubdivision.IDSubdivision,
                IDCalculator = NewMenu.Calculator.IDEmployee,
                IDChiefCooker = NewMenu.ChiefCooker.IDEmployee,
                IDTypeMenu = NewMenu.TypeMenu.IDTypeMenu,
                Dishes = dishes
            });
            Context.context.SaveChanges();
            Context.context.Dispose();
            Context.context = new DB_MenuEntities();
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
