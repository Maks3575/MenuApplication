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
        

        public DishController()
        {
            
        }

        public void Add(IDish newDish)
        {
            var Dish = Context.context.Dishes.Add(new ModelDB.Dish()
            {
                NameDish = newDish.NameDish,
                ExpandedNameDish = newDish.ExpandedNameDish,
                WeightDish = newDish.WeightDish,
                NumberInCollectionOfRecipes = newDish.NumberInCollectionOfRecipes,
                IDTypeDish = newDish.TypeDish.IDTypeDish//надо добавить в IDish поле TypeDish
            });

            Context.context.ItemDishes.AddRange(newDish.DishItems.Select(x => new ModelDB.ItemDish()
            {
                Dish = Dish,
                IDIngredient = x.Ingredient.IdIngredient,
                NormOn100Portion = (float)x.NormOn100Portions
            }));
            Context.context.SaveChanges();
            Context.context.Dispose();
            Context.context = new DB_MenuEntities();

        }

        public bool CheckOnContain(IDish dish) => Context.context.Dishes
            .Select(x => x.ExpandedNameDish).Contains(dish.ExpandedNameDish);

        public bool CheckOnExpandedNameDish(string ExpandedNameDish)=> Context.context.Dishes
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
        public static DateTime CalculationDishDate(ModelDB.Dish DishDB, DateTime DT)
        {
            DateTime CreateDate;

            //находим все даты использования данного блюда
            List<DateTime> CreateDates = SubdivisionController.CurrentSubdivision.Menus
                .Where(Menu => Menu.UseDate <= DT && Menu.Dishes.Any(dish => dish.ExpandedNameDish == DishDB.ExpandedNameDish))
                .OrderByDescending(x => x.UseDate).Select(x => x.UseDate).ToList();

            if (CreateDates == null)//если блюдо не использовалось
            {
                if (FillingDish(DishDB, DT) == null)//если на переданную дату нельзя создать блюдо
                {
                    CreateDate = new DateTime(0001, 1, 1, 0, 0, 0);//указываем минимально воможную дату
                }
                else//иначе высылаем переданную дату
                {
                    CreateDate = DT;
                }
            }
            else //если блюдо использовалось
            {
                //создаем список продуктов на переданную дату
                List<Product> Products = DishDB.ItemDishes.Select(x => x.Ingredient.Products
                    .Where(y => y.BeginDate <= DT && y.Subdivision.IDSubdivision == SubdivisionController.CurrentSubdivision.IDSubdivision)
                    .OrderByDescending(y => y.BeginDate).FirstOrDefault()).ToList();
                CreateDate = DT;
                //перебираем даты использования до тех пор, пока не найдется последовательность продуктов отличная от той что на текущую дату
                foreach (var Date in CreateDates)
                {
                    if (!DishDB.ItemDishes.Select(x => x.Ingredient.Products
                    .Where(y => y.BeginDate <= Date && y.Subdivision.IDSubdivision == SubdivisionController.CurrentSubdivision.IDSubdivision)
                    .OrderByDescending(y => y.BeginDate).FirstOrDefault()).ToList().SequenceEqual(Products))
                        break;
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
        public static IDish FillingDish(ModelDB.Dish DishDB, DateTime DT)
        {
            //создаем список DishItem для выбранного блюда
            List<DishItem> DI = DishDB.ItemDishes.Select(x => new DishItem()
            {
                Ingredient = x.Ingredient.Products
                .Where(y => y.BeginDate <= DT && y.Subdivision.IDSubdivision == SubdivisionController.CurrentSubdivision.IDSubdivision)
                .OrderByDescending(y => y.BeginDate).FirstOrDefault(),

                NormOn100Portions = x.NormOn100Portion
            }).ToList();
            //проверяем существуют ли все необходимые продукты на заданную дату в нужном подразделении
            if (DI.Select(x => x.Ingredient).Any(x => x == null))
            {
                //если не сущетвуют возвращаем null
                return null;
            }
            else
            {
                return new Domain.Dish()
                {
                    //DateCreate = CalculationDishDate(DishDB, DT), //заменил так как перед ее вызовом дата всегда уже найдена
                    DateCreate = DT,
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
            //получаем нужное блюдо
            ModelDB.Dish dish = Context.context.Dishes.FirstOrDefault(x => x.ExpandedNameDish == ExpandedNamedish);

            //находим все даты его калькуляции
            List<DateTime> HistoryDates = SubdivisionController.CurrentSubdivision.Menus
                .Where(x => x.Dishes.Any(y => y.ExpandedNameDish == ExpandedNamedish))
                .Select(x => CalculationDishDate(dish, x.UseDate)).Distinct().ToList();
            
            if (HistoryDates == null)//если блюдо не использовалось
            {
                Domain.Dish d = FillingDish(dish, DateTime.Now) as Domain.Dish;
                if (d == null)//проверяем на существование всех необходимых ингредиентов для данного блюда
                {
                    return null;// если не существует выводим null
                }
                else
                {
                    return new List<IDish>() { d };//если существует выводим калькуляцию текущим числом
                }
            }
            else//если блюдо использовалось создаем список блюд на каждую дату калькуляции
            {
                return HistoryDates.Select(x => FillingDish(dish, x)).Where(x => x != null).OrderByDescending(d=>d.DateCreate);
            }
        }

        /// <summary>
        /// Возвращает список в котором находятся все блюда в единственном самом новом экземпляре
        /// </summary>
        /// <returns>Список самых новых блюд</returns>
        public IEnumerable<IDish> LatestDish()//надо переделать!!!!!
        {
            return SubdivisionController.CurrentSubdivision.Menus.SelectMany(Menu => Menu.Dishes)
                .Distinct().Select(Dish => FillingDish(Dish, CalculationDishDate(Dish, DateTime.Now)))
                .Where(dish => dish != null);
            //throw new NotImplementedException();
        }

        public int NumberDocNext()
        {
            throw new NotImplementedException();
        }
    }
}
