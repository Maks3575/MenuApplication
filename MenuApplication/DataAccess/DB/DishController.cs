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
            throw new NotImplementedException();//не используется
        }

        public IDish GetDishByName(string ExpandedNameDish)
        {
            throw new NotImplementedException();//не используется
        }
        //=> context.Dishes
        //    .FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);

        public IDish GetDishByName(string ExpandedNameDish, DateTime DT)
        {
            {
                throw new NotImplementedException();//не используется
            }
            //Dish Dish = context.Dishes.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish);
            //Dish.DishItems= context.Dishes
            //.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNameDish)
            //return 
        }

        /// <summary>
        /// Поиск даты калькуляции блюда (первого использования)
        /// </summary>
        /// <param name="DishDB">Блюдо</param>
        /// <param name="DT">Дата</param>
        /// <returns>Дата калькуляции блюда</returns>
        public DateTime CalculationDishDate(ModelDB.Dish DishDB, DateTime DT)
        {
            DateTime CreateDate;
            List<DateTime> CreateDates = SubdivisionController.CurrentSubdivision.Menus
                .Where(x => x.UseDate <= DT && x.Dishes.Any(y => y.ExpandedNameDish == DishDB.ExpandedNameDish))
                .OrderByDescending(x => x.UseDate).Select(x => x.UseDate).ToList();
            if (CreateDates == null)
            {
                CreateDate = DT;
            }
            else
            {
                List<Product> Products = DishDB.ItemDishes.Select(x => x.Ingredient.Products
                    .Where(y => y.BeginDate <= DT && y.Subdivision == SubdivisionController.CurrentSubdivision)
                    .OrderByDescending(y => y.BeginDate).FirstOrDefault()).ToList();
                CreateDate = DT;
                foreach (var Date in CreateDates)
                {

                    if (!DishDB.ItemDishes.Select(x => x.Ingredient.Products
                    .Where(y => y.BeginDate <= Date && y.Subdivision == SubdivisionController.CurrentSubdivision)
                    .OrderByDescending(y => y.BeginDate).FirstOrDefault()).ToList().SequenceEqual(Products)) break;
                    CreateDate = Date;
                }
            }
            return CreateDate;
        }

        /// <summary>
        /// Создание калькуляции блюда, которое реализует IDish
        /// </summary>
        /// <param name="DishDB">Блюдо из контекста</param>
        /// <param name="DT">Дата</param>
        /// <returns>Калькуляция блюда</returns>
        public IDish FillingDish(ModelDB.Dish DishDB, DateTime DT)
        {
            List<DishItem> DI = DishDB.ItemDishes.Select(x => new DishItem()
            {
                Ingredient = x.Ingredient.Products
                .Where(y => y.BeginDate <= DT && y.Subdivision == SubdivisionController.CurrentSubdivision)
                .OrderByDescending(y => y.BeginDate).FirstOrDefault(),
                NormOn100Portions = x.NormOn100Portion
            }).ToList();
            if (DI.Select(x => x.Ingredient).Any(x => x == null)) 
            {
                return null;
            }
            else
            {
                return new Domain.Dish()
                {
                    DateCreate = CalculationDishDate(DishDB, DT),
                    NumberDish = DishDB.IDDish,
                    NameDish = DishDB.NameDish,
                    ExpandedNameDish = DishDB.ExpandedNameDish,
                    WeightDish = DishDB.WeightDish,
                    NumberInCollectionOfRecipes = DishDB.NumberInCollectionOfRecipes,
                    TypeDish = DishDB.TypeDish,
                    DishItems = DI
                };
            }            
        }

        /// <summary>
        /// Возвращает историю обновлений указанного блюда
        /// </summary>
        /// <param name="ExpandedNamedish">Расширенное имя блюда</param>
        /// <returns>Список со всеми обновлениями для данного блюда</returns>
        public IEnumerable<IDish> HistoryDish(string ExpandedNamedish)
        {
            ModelDB.Dish dish = context.Dishes.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNamedish);
            List<DateTime> HistoryDates = SubdivisionController.CurrentSubdivision.Menus
                .Where(x => x.Dishes.Any(y => y.ExpandedNameDish == ExpandedNamedish))
                .Select(x => CalculationDishDate(dish, x.UseDate)).Distinct().ToList();
            
            if (HistoryDates == null)
            {
                Domain.Dish d = FillingDish(dish, DateTime.Now) as Domain.Dish;
                if (d == null)
                {
                    return null;
                }
                else
                {
                    return new List<IDish>() { d };
                }
            }
            else
            {
                return HistoryDates.Select(x => FillingDish(dish, x));
            }
        }

        /// <summary>
        /// Возвращает список в котором находятся все блюда в единственном самом новом экземпляре
        /// </summary>
        /// <returns>Список самых новых блюд</returns>
        public IEnumerable<IDish> LatestDish()
        {
            return SubdivisionController.CurrentSubdivision.Menus.SelectMany(Menu => Menu.Dishes)
                .Distinct().Select(Dish => FillingDish(Dish, DateTime.Now));
            //throw new NotImplementedException();
        }

        public int NumberDocNext()
        {
            throw new NotImplementedException();
        }
    }
}
