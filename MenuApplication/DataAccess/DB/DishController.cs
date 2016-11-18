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
            var Dish = context.Dishes.Add(new ModelDB.Dish()
            {
                NameDish = newDish.NameDish,
                ExpandedNameDish = newDish.ExpandedNameDish,
                WeightDish = newDish.WeightDish,
                NumberInCollectionOfRecipes = newDish.NumberInCollectionOfRecipes,
                TypeDish = newDish.TypeDish//надо добавить в IDish поле TypeDish
            });

            context.ItemDishes.AddRange(newDish.DishItems.Select(x => new ModelDB.ItemDish()
            {
                Dish = Dish,
                IDIngredient = x.Ingredient.IdIngredient,
                NormOn100Portion = (float)x.NormOn100Portions
            }));

        }

        public bool CheckOnContain(IDish dish) => context.Dishes
            .Select(x => x.ExpandedNameDish).Contains(dish.ExpandedNameDish);

        public bool CheckOnExpandedNameDish(string ExpandedNameDish)=>context.Dishes
            .Select(x => x.ExpandedNameDish).Contains(ExpandedNameDish);

        public IEnumerable<IDish> Fetch()
        {
            throw new NotImplementedException();
        }

        public IDish GetDishByName(string ExpandedNameDish)
        {
            throw new NotImplementedException();
        }
        //=> context.Dishes
        //    .FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);

        public IDish GetDishByName(string ExpandedNameDish, DateTime DT)
        {
            {
                throw new NotImplementedException();
            }
            //Dish Dish = context.Dishes.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);
            //Dish.DishItems= context.Dishes
            //.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish)
            //return 
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
