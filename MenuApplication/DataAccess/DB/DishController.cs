using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;
using MenuApplication.ModelDB;

namespace MenuApplication.DataAccess.DB
{
    class DishController : IDishRepository
    {
        DB_MenuEntities context;

        public DishController()
        {
            context = new DB_MenuEntities();
        }

        public void Add(IDish newDish)
        {
            throw new NotImplementedException();
        }

        public bool CheckOnContain(IDish dish) => context.Dishes
            .Select(x => x.ExpandedNameDish).Contains(dish.ExpandedNameDish);

        public bool CheckOnExpandedNameDish(string ExpandedNameDish)=>context.Dishes
            .Select(x => x.ExpandedNameDish).Contains(ExpandedNameDish);

        public IEnumerable<IDish> Fetch() => context.Dishes;

        public IDish GetDishByName(string ExpandedNameDish) => context.Dishes
            .FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);

        public IDish GetDishByName(string ExpandedNameDish, DateTime DT)
        {
            Dish Dish = context.Dishes.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);
            Dish.DishItems= context.Dishes
            .FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish)
            return 
        }

        public IEnumerable<IDish> HistoryDish(string ExpandedNamedish)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDish> LatestDish()
        {
            throw new NotImplementedException();
        }

        public int NumberDocNext()
        {
            throw new NotImplementedException();
        }
    }
}
