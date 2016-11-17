using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{
    /// <summary>
    /// Класс репозиторий (заглушка) для полей калькуляционной карточки
    /// </summary>
    internal class DishItemRepositoryPlug:IDishItemRepository
    {   
        /// <summary>
        /// Список полей калькуляционной карточки
        /// </summary>
        private readonly IList<IDishItem> _DishItemsInRepository;

        /// <summary>
        /// Конструктор репозитория полей калькуляционной карточки
        /// </summary>
        /// <param name="DishItemsInRepository">Список полей калькуляционных карточек</param>
        public DishItemRepositoryPlug(IList<IDishItem> DishItemsInRepository)
        {
            _DishItemsInRepository = DishItemsInRepository;
        }

        /// <summary>
        /// Возвращает список полей калькуляционной карточки
        /// </summary>
        /// <returns>Список полей калькуляционной карточки</returns>
        public IEnumerable<IDishItem> Fetch()
        {
            return _DishItemsInRepository;
        }

        /// <summary>
        /// Добавляет поле калькуляционной карточки в репозиторий 
        /// </summary>
        /// <param name="newDishItem">Добавляемое поле</param>
        public void Add(IDishItem newDishItem)
        {
            _DishItemsInRepository.Add(newDishItem);
        }

        /// <summary>
        /// Возвращает репозитрий полей калькуляционной карточки заполненный тестовыми данными
        /// </summary>
        /// <returns></returns>
        internal static DishItemRepositoryPlug CreateInstance()
        {
            return new DishItemRepositoryPlug(new List<IDishItem>());
                //new Ingredient(1,"Сосиски",1,(decimal)388.90,true,DateTime.Now,0,0,0)
            //});
        }
    }
}
