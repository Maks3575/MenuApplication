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
            throw new NotImplementedException();
        }

        public IEnumerable<IMenu> Fetch()
        {
            var menus = context.Menus.ToList();
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
