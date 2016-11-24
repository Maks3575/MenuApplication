using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuApplication.DataAccess;
using MenuApplication.Domain;
using MenuApplication.ModelDB;
using System.Windows.Forms;
using MenuApplication.DataAccess.DB;

namespace MenuApplication
{   
    /// <summary>
    /// Класс контроллер
    /// </summary>
    class Controller
    {
        private DB_MenuEntities context;
        private readonly SubdivisionController _SubdivisionsController;
        private readonly IIngredientRepositopy _IngredientController;
        private readonly IDishRepository _DishController;
        private readonly IMenuRepository _MenuController;
        private readonly DirectoryController _DirectoryController;
        private Report _Report;

        /// <summary>
        /// Конструктор класса котроллера
        /// </summary>
        /// <param name="IngredientRepository">Репозиторий ингредиентов</param>
        /// <param name="DishItemRepository">Репозиторий позиций калькуляционной карточки</param>
        /// <param name="DishRepository">Репозиторий кальлкуляционных карточек</param>
        /// <param name="MenuRepository">Репозиторий меню</param>
        public Controller (//IIngredientRepositopy IngredientRepository,// IDishItemRepository DishItemRepository,
                //IDishRepository DishRepository, 
                //IMenuRepository MenuRepository
            )//, SubdivisionRepositoryPlug SubdivisionInRepository)
        {
            _SubdivisionsController = new SubdivisionController();
            _IngredientController = new IngredientsController();//IngredientRepository;
            _DishController = new DishController();//DishRepository;
            _MenuController = new MenuController();//MenuRepository;
            _DirectoryController = new DirectoryController();
            
            
            //_SubdivisionsController = new SubdivisionController();
            //DishDataTest();
            _Report = new Report();
            context = new DB_MenuEntities();     
        }

        /// <summary>
        /// Выводит заготовку бракеража в Excel
        /// </summary>
        /// <param name="menu">Меню служащее основой для брокеража</param>
        public void BrokerashInExcel(IMenu menu)
        {
            _Report.BrokerachInExcel(menu);
        }

        /// <summary>
        /// Выводит меню в Excel
        /// </summary>
        /// <param name="menu">Меню навывод</param>
        public void MenuInExcel(IMenu menu)
        {
            _Report.MenuInExcel(menu);
        }

        /// <summary>
        /// Выводит актуальный реестр цен в эксель
        /// </summary>
        public void RegistryInExcel()
        {
            _Report.RegistryInExcel(_IngredientController.GetRegistry()); //as IList<Ingredient>);
        }

        /// <summary>
        /// Создает Калькуляционную карточку в экселе
        /// </summary>
        /// <param name="dish">Воводимое блюдо</param>
        public void DishInExcel(IDish dish)
        {
            IDish prevDish = _DishController.HistoryDish(dish.ExpandedNameDish).Where(d => d.DateCreate < dish.DateCreate).FirstOrDefault();
            if (prevDish==null)
            {
                _Report.CalculationInExcel(dish, dish);
            }
            else
            {
                _Report.CalculationInExcel(dish, prevDish);
            }
        }
        
        /// <summary>
        /// Заполнение репозиториев тестовыми случайными данными
        /// </summary>
        public void DishDataTest()
        {
            IList<IDish> L = new List<IDish>();
            IList<Domain.Dish> L2 = new List<Domain.Dish>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                List<DishItem> DishI = new List<DishItem>();
                List<DishItem> DishI1 = new List<DishItem>();
                IList<IIngredient> Ingredients = _IngredientController.GetRegistry().ToList();
                IList<IDish> menu = new List<IDish>();

                for (int j = 0; j < rand.Next(3, 10); j++)//
                    DishI.Add(new DishItem(Ingredients[rand.Next(1, Ingredients.Count - 1)], (double)(rand.Next(1, 120) / 10)));
                //DishI1.Add(new DishItem(Ingredients[rand.Next(1, Ingredients.Count - 1)], (double)(rand.Next(1, 120) / 10)));

                Domain.Dish d = new Domain.Dish(i, DateTime.Now.AddHours(-rand.Next(600000)), $"Наименование блюда {i}"
                                                , $"Расширенное наименование блюда {i}", rand.Next(100, 9999).ToString()
                                                , (rand.Next(10, 30) * 10).ToString(), DishI);
                L.Add(d);
                AddDishInRepository(d);
            }
        }

        public int NextNumberDocDish() => _DishController.NumberDocNext();
        //Работа с ингредиентами

        /// <summary>
        /// Возвращает копию реестра цен для редактирования его
        /// </summary>
        /// <returns>Копия реестра цен</returns>
        public IEnumerable<IIngredient> StartEditingRegistryIngredients()
        {
            return _IngredientController.GetRegistry().Select(x => x.Clone());
        }

        /// <summary>
        /// Сохраняет отредактированные ингредиенты
        /// </summary>
        /// <param name="savingList">Лист на проверку и сохранение</param>
        public void EndEditingRegistryIngredients(IEnumerable<IIngredient> savingList)
        {
            var comparer = new IngredientRepositoryPlug.IngredientComparerForSaving();
            savingList.ToList().ForEach(x => 
            {
               if (!(_IngredientController.GetRegistry().Contains(x, comparer)))
                {
                    x.RecordDate = DateTime.Now;
                    _IngredientController.Add(x);
                }
            });
        }
        
        /// <summary>
        /// Возвращает новый пустой экземпляр ингредиента
        /// </summary>
        /// <returns>Новый пустой ингредиент</returns>
        public IIngredient NewIngedient()
        {
            return new Domain.Ingredient { NameIngredient = "" };
        }

        /// <summary>
        ///Возвращает список всех ингредиентов из репозитория
        /// </summary>
        /// <returns>Полный список нгредиентов из репозитория</returns>
        public IEnumerable<IIngredient> GetALLIngredientAsBindingList()
        {
            return _IngredientController.Fetch();
        }

        /// <summary>
        /// Возвращает по одному самому новому экземпляру ингредиента
        /// </summary>
        /// <returns>Реестр цен</returns>
        public IEnumerable<IIngredient> GetRegistryAsBindingList()
        {
            return _IngredientController.GetRegistry();
        }

        /// <summary>
        /// Добавление ингредиента в репозиторий
        /// </summary>
        /// <param name="NewIngredient">Добавляемый ингредиент</param>
        public void AddIngredientInRepository(IIngredient NewIngredient)
        {
            if (NewIngredient == null)
                throw new ArgumentNullException("newIngredient");
            _IngredientController.Add(NewIngredient);     
        }

        /// <summary>
        /// Добавляем еще не существующий в репозитории ингредиент
        /// </summary>
        /// <param name="_NameIngredient">Наименование ингредиета</param>
        /// <param name="_MassInKg">Упаковочная масса</param>
        /// <param name="_StartingPrice">Упаковочная цена</param>
        /// <param name="_RecordDate">Дата записи</param>
        /// <param name="_Protein">Количество белков на 100 г продукта</param>
        /// <param name="_Fat">Количество жиров на 100 г продукта</param>
        /// <param name="_Carbohydrate">Количество углеводов на 100 г продукта</param>
        /// <returns>добавилось или нет</returns>
        public bool AddNewIngredientInRepository(string _NameIngredient, double _MassInKg,
            decimal _StartingPrice, DateTime _RecordDate,
            double _Protein, double _Fat, double _Carbohydrate,TypeIngredient _TypeIngredient)
        {
            Product NewIngredient = new Product()
            {
                Ingredient = new ModelDB.Ingredient(),
                NameIngredient = _NameIngredient,
                MassInKg = _MassInKg,
                StartingPrice = _StartingPrice,
                RecordDate = _RecordDate,
                Protein = _Protein,
                Fat = _Fat,
                Carbohydrate = _Carbohydrate,
                TypeIngredient = _TypeIngredient,
                Subdivision = SubdivisionController.CurrentSubdivision
            };

            return _IngredientController.AddNewIngredient(NewIngredient);

        }

        //Работа с калькуляциоными карточками

        /// <summary>
        /// Полячить все блюда из репозитория
        /// </summary>
        /// <returns>Список всех блюд из репозитория</returns>
        public IEnumerable<IDish> GetAllDishAsBindingList()
        {
            return _DishController.Fetch();
        }

        /// <summary>
        /// Возвращает поединственному, самому новому, экземпляру всех блюд из репозитория 
        /// </summary>
        /// <returns>Список актуальных блюд</returns>
        public IEnumerable<IDish> GetFreshDish()
        {
            return _DishController.LatestDish();
        }

        /// <summary>
        /// Добавление блюда в репозиторий
        /// </summary>
        /// <param name="NewDish">Добавляемое блюдо</param>
        public void AddDishInRepository(IDish NewDish)
        {
            _DishController.Add(NewDish);

        }

        /// <summary>
        /// Возвращает новый пустой экземпляр блюда
        /// </summary>
        /// <returns>Новый пустой экземпляр блюда</returns>
        public IDish NewDish()
        {
         return new Domain.Dish() { DishItems = new List<DishItem>() {} };
        }

        /// <summary>
        /// Возвращает новейший экземпляр блюда из репозитория по расширенному имени
        /// </summary>
        /// <param name="Name">Расширенное наименование икомого блюда</param>
        /// <returns></returns>
        public IDish SearchDishByName(string Name)
        {
            return _DishController.GetDishByName(Name);
        }

        /// <summary>
        /// Возвращает поля блюда
        /// </summary>
        /// <param name="_dish"> Блюдо чьи поля нужно вернуть</param>
        /// <returns>Поля блюда</returns>
        public IEnumerable<IDishItem> GetContentDish(IDish _dish)
        {
            return _dish.DishItems;
        }

        /// <summary>
        /// Возвращает историю обновления указанного блюда
        /// </summary>
        /// <param name="ExpandedNameDish">Расширенное имя блюда</param>
        /// <returns>История обновлений блюда</returns>
        public IEnumerable<IDish> GetHistoryDish(string ExpandedNameDish)
        {
            return _DishController.HistoryDish(ExpandedNameDish);//.Where(x=>x!=null).OrderByDescending(x=>x.DateCreate);//as IEnumerable<Dish>;
        }

        /// <summary>
        /// Проверка на актуальность блюда
        /// </summary>
        /// <param name="Dish">Блюдо на проверку</param>
        /// <returns>True если актуально</returns>
        public bool TestOnRelevanceDish(IDish Dish)
        {
            return Dish.DishItems.All(x => _IngredientController.TestOnChangeIngredient(x.Ingredient));
        }

        /// <summary>
        /// Возвращает обновленное блюдо
        /// </summary>
        /// <param name="dish">Блюдо на обновление</param>
        /// <param name="dt">дата</param>
        /// <returns>обновленное блюдо</returns>
        public IDish RefreshDish(IDish dish, DateTime dt)
        {
            if (TestOnRelevanceDish(dish))
            {
                return dish;
            }else
            {
                List<DishItem> NewListDI = new List<DishItem>();
                foreach (var DI in dish.DishItems)
                {
                    if (_IngredientController.TestOnChangeIngredient(DI.Ingredient))
                    {
                        NewListDI.Add(DI);
                    }
                    else
                    {
                        NewListDI.Add(new DishItem(_IngredientController.GetIngrByName(DI.Ingredient.NameIngredient),DI.NormOn100Portions));
                    }
                }
                return (new Domain.Dish(dish,dt,NewListDI));
            }
        }

        /// <summary>
        /// Проверка на уникальность расширенного названия блюда
        /// </summary>
        /// <param name="ExpNameDish">Расширенное наименование проверяемого блюда</param>
        /// <returns> TRUE если не уникально</returns>
        public bool CheckExpandedNameDish(string ExpNameDish) => _DishController.CheckOnExpandedNameDish(ExpNameDish);

        ////РАБОТА С МЕНЮ
        /// <summary>
        /// Возвращает новый пустой экземпляр меню
        /// </summary>
        /// <returns>Новый пустой экземпляр меню</returns>
        public IMenu NewMenu()
        {
            return new ModelDB.Menu() { Dishs = new List<IDish>()};
        }
        
        /// <summary>
        /// Добавить меню в репозиторий
        /// </summary>
        /// <param name="menu">Меню на добавление</param>
        public void AddMenuInRepository(IMenu menu)
        {
            if (menu==null)
                throw new ArgumentNullException("NewMenu");
            _MenuController.Add(menu);
        }

        /// <summary>
        /// Получение всех меню из репозитория
        /// </summary>
        /// <returns>Список всех меню из репозитория</returns>
        public IEnumerable<IMenu> GetAllMenuAsBindingList()
        {
            return _MenuController.Fetch();
        }

        //работа с подразделениями и отчетностью

        /// <summary>
        /// Возвращает все структурные подразделения из репозитория
        /// </summary>
        /// <returns>Список всех подразделений</returns>
        public List<ModelDB.Subdivision> GetSubdivisionAsBindingList() => _SubdivisionsController.Fetch().ToList();//context.Subdivisions.ToList();// 

        /// <summary>
        /// Меняет значение подразделения в классе отчетов
        /// </summary>
        /// <param name="subdiv">Подразделение на которое меняем</param>
        public void ChangeSubdivisionInReport()//Subdivision subdiv)
        {
            //_Report.Subdivision = subdiv;
        }

        public void ChangeCurrentSubdivision(ModelDB.Subdivision CurrSubdiv)
        {
            SubdivisionController.CurrentSubdivision = CurrSubdiv;
        }

        //-------------работа с справочниками-------------
        public IEnumerable<ModelDB.TypeDish> GetTypeDishtAsBindingList() => _DirectoryController.TypeDishFetch();

        public IEnumerable<ModelDB.TypeMenu> GetTypeMenuAsBindingList() => _DirectoryController.TypeMenuFetch();

        public IEnumerable<ModelDB.Employee> GetCalculatorAsBindingList() => _DirectoryController.CalculatorFetch();

        public IEnumerable<ModelDB.Employee> GetChiefCookerAsBindingList() => _DirectoryController.ChiefCookerFetch();

    }
}
