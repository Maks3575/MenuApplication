using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApplication.DataAccess
{
    /// <summary>
    /// Класс репозиторий (заглушка) для ингредиентов
    /// </summary>
    internal class IngredientRepositoryPlug : IIngredientRepositopy
    {
        /// <summary>
        /// Список ингредиентов
        /// </summary>
        private readonly IList<IIngredient> _IngredientsInRepository;

        /// <summary>
        /// Конструктор заглушки репозитория ингредиентов
        /// </summary>
        /// <param name="IngredientsInRepository">Список ингредиентов</param>
        public IngredientRepositoryPlug(IList<IIngredient> IngredientsInRepository)
        {
            _IngredientsInRepository = IngredientsInRepository;
        }

        /// <summary>
        /// Возвращает список ингредиентов
        /// </summary>
        /// <returns>Список ингредиентов</returns>
        public IEnumerable<IIngredient> Fetch()
        {
            return _IngredientsInRepository;
        }

        /// <summary>
        /// Добавляет ингредиент в репозиторий 
        /// </summary>
        /// <param name="newIngredient">Добавляемый объект</param>
        public void Add(IIngredient newIngredient)
        {
            _IngredientsInRepository.Add(newIngredient);
        }

        /// <summary>
        /// Добавляет новый ингредиент в репозиторий
        /// </summary>
        /// <param name="newIngredient">Добавляемый ингредиент</param>
        public bool AddNewIngredient(IIngredient newIngredient)
        {
            if (_IngredientsInRepository.Select(x => x.NameIngredient).Contains(newIngredient.NameIngredient))
            {
                return false;
            }
            else
            {
                _IngredientsInRepository.Add(newIngredient);
                return true;
            }
        }

        public class IngredientComparer : IEqualityComparer<IIngredient>
        {
            public bool Equals(IIngredient x, IIngredient y)
            {
                return x.NameIngredient == y.NameIngredient;
            }

            public int GetHashCode(IIngredient obj)
            {
                return obj.NameIngredient.GetHashCode();
            }
        }

        public class IngredientComparerForSaving : IEqualityComparer<IIngredient>
        {
            public bool Equals(IIngredient x, IIngredient y)
            {
                return (x.NameIngredient == y.NameIngredient) && x.MassInKg==y.MassInKg && x.StartingPrice==y.StartingPrice;
            }

            public int GetHashCode(IIngredient obj)
            {
                return obj.NameIngredient.GetHashCode();
            }
        }

        /// <summary>
        /// Возвращает список ингредиентов в котором находится по одному экземпляру всех ингредиентов (самые новые)
        /// </summary>
        /// <returns>Актуальный реестр цен</returns>
        public IEnumerable<IIngredient> GetRegistry()
        {
            //IEnumerable<IIngredient> i = new List<IIngredient>();
            //i = _IngredientsInRepository.Where(y => y.RecordDate == _IngredientsInRepository.Where(x => x.NameIngredient == y.NameIngredient).Max(x => x.RecordDate)).Distinct();
            return _IngredientsInRepository.Where(y => y.RecordDate == _IngredientsInRepository.Where(x => x.NameIngredient == y.NameIngredient).Max(x => x.RecordDate)).Distinct().OrderBy(x=>x.NameIngredient);        
        }

        /// <summary>
        /// Проверка на актуальность ингредиента
        /// </summary>
        /// <param name="ingr">Проверяемый ингредиент</param>
        /// <returns>Актуален ли элемент</returns>
        public bool TestOnChangeIngredient(IIngredient ingr)
        {
            return _IngredientsInRepository.Where(x=>x.NameIngredient==ingr.NameIngredient).All(x => x.RecordDate <= ingr.RecordDate);
        }


        /// <summary>
        /// Получение объекта ингредиента по имени
        /// </summary>
        /// <returns>Ингредиент</returns> 
        public IIngredient GetIngrByName(string Object) => _IngredientsInRepository.Where(x => x.NameIngredient == Object).OrderByDescending(x => x.RecordDate).First();
        
        /// <summary>
        /// Возвращает репозиторий ингредиентов заполненный тестовыми данными
        /// </summary>
        /// <returns>Заполненный епозиторий ингредиентов</returns>
        internal static IngredientRepositoryPlug CreateInstance()
        {
            Random r=new Random();
            return new IngredientRepositoryPlug(new List<IIngredient>()
            {
            new Ingredient("Кефир", 0.5, (decimal)22.11, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Творог", 0.25, (decimal)52.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сметана", 0.5, (decimal)94.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сыр Обской", 1, (decimal)441.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Дрожжи сух.", 0.5, (decimal)95.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кетчуп", 0.54, (decimal)94.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            

            new Ingredient("Вода питьевая", 19, (decimal)130, DateTime.Now.AddHours(-r.Next(600000)).AddDays(-r.Next(100)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Тесто слоеное", 0.45, (decimal)64.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Говядина б/к ", 1, (decimal)517.73, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Шея свин.", 1, (decimal)605.8, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Свинина б/к карбонат", 1, (decimal)588.74, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Язык говяжий", 1, (decimal)570.6, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Язык свиной", 1, (decimal)440.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Печень говяжья", 1, (decimal)148.66, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сердце свиное", 1, (decimal)190.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Колбаса вареная в/с", 1, (decimal)448.64, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Колбаса полукопченая", 1, (decimal)588.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Бекон к/в", 1, (decimal)514.6, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сосиски ", 1, (decimal)388.9, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Яйцо", 0.04, (decimal)7.21, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кролик н/к", 1, (decimal)510, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Окорочка Куринные", 1, (decimal)198.64, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кура", 1, (decimal)212.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Грудки куриные филе", 1, (decimal)488.45, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Куриное филе с кожей", 1, (decimal)460.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Картофель св.", 1, (decimal)48, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Капуста св.", 1, (decimal)45, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Капуста цвет.с.м.", 0.4, (decimal)68, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Капуста морская", 1, (decimal)1385, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Морковь", 1, (decimal)54, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Свекла св.", 1, (decimal)47, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Лук реп.", 1, (decimal)44.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Лук зеленый ", 1, (decimal)488.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Овощи с.м.", 0.4, (decimal)66.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Укроп свеж.", 1, (decimal)588.44, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Лимоны", 1, (decimal)221.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Чеснок", 1, (decimal)196, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Огурцы св.", 1, (decimal)211.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Помидоры св. ", 1, (decimal)288.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Перец слд.", 1, (decimal)79, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Перец слд. импортный", 1, (decimal)200, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Редис св.", 1, (decimal)171.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Редька св.", 1, (decimal)91.8, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Огурцы соленые", 1, (decimal)171.8, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Огурцы консервированные", 0.72, (decimal)68, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Яблоки", 1, (decimal)118.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Мандарины", 1, (decimal)181.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Орех грецкий", 1, (decimal)580.64, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Орех арахис", 1, (decimal)149.44, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Курага", 1, (decimal)211.19, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Изюм", 1, (decimal)180.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сухофрукты", 1, (decimal)64.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Чернослив", 1, (decimal)181, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Ягода с.м.клубника,вишня,смородина", 0.4, (decimal)96, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Ягода с.м.черника,малина", 0.3, (decimal)81, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Цукаты черешни", 1, (decimal)571, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Горошек зеленый бонд.     ", 0.42, (decimal)89.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кукуруза конс. бонд.         ", 0.425, (decimal)69.3, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Шампиньоны конс.", 0.85, (decimal)91.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Фасоль конс.", 0.42, (decimal)58.6, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Томат-паста(18 - 20%)", 0.77, (decimal)110.23, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Соль", 1, (decimal)18.9, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сахар", 1, (decimal)58.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сахар-рафинад", 1, (decimal)58.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Пудра сахарная", 0.15, (decimal)11.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Какао-порошок", 0.5, (decimal)24.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Перец черный молотый", 0.015, (decimal)28.11, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Лавровый лист", 0.007, (decimal)17, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Уксусная кислота 70%", 0.2, (decimal)27.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кислота лимонная", 0.02, (decimal)24.11, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Гречка ", 1, (decimal)88.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Мука пшен.", 1, (decimal)42.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Чай черный", 25, (decimal)55, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Чай зеленый ", 25, (decimal)88, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кофе Нескафе", 0.1, (decimal)146.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Молоко стерилизованное", 1, (decimal)72.14, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Молоко концентрированное", 0.325, (decimal)65, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Молоко сгущенное", 0.4, (decimal)58.8, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Молоко сухое", 1, (decimal)180, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Майонез ", 0.9, (decimal)120, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Масло растительное", 0.92, (decimal)99.6, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10)
,           new Ingredient("Масло сливочное ", 1, (decimal)305.24, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Маргарин Пышка", 0.25, (decimal)45, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кефир", 0.5, (decimal)22.11, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Творог", 0.25, (decimal)52.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сметана", 0.5, (decimal)94.5, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Сыр Обской", 1, (decimal)441.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Дрожжи сух.", 0.5, (decimal)95.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Кетчуп", 0.54, (decimal)94.1, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Зелень сухая  петрушка ", 0.005, (decimal)6.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Зелень сухая  укроп", 0.005, (decimal)6.4, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10),
            new Ingredient("Картофель св.", 1, (decimal)48, DateTime.Now.AddHours(-r.Next(600000)), (double)r.Next(300)/10, (double)r.Next(400)/10, (double)r.Next(600)/10)
            });
        }
    }
}
