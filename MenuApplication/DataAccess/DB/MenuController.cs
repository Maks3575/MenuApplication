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

        /// <summary>
        /// Проверяет существует ли меню на заданную дату такого же типа
        /// </summary>
        /// <param name="DT">Дата</param>
        /// <param name="TM">Тип Меню</param>
        /// <returns>true если такое уже существует</returns>
        public bool CheckOnTypeMenu(DateTime DT, string TM) => Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Menus.Any(menu => menu.UseDate.Date == DT.Date && menu.TypeMenu.NameTypeMenu == TM);

        /// <summary>
        /// Добавление меню
        /// </summary>
        /// <param name="NewMenu">Добавляемое меню</param>
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

        /// <summary>
        /// Получение списка всех меню в подразделении
        /// </summary>
        /// <returns>Список меню</returns>
        public IEnumerable<IMenu> Fetch()
        {
            var menus = Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Menus.OrderBy(menu=>menu.DateCreateMenu).ToList();
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
