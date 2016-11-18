using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{
    /// <summary>
    /// Класс репозиторий для калькуляционных карточек
    /// </summary>
    internal class DishRepositoryPlug:IDishRepository
    {
        /// <summary>
        /// Список калькуляционных карточек
        /// </summary>
        IList<IDish> _DishsInRepository;

        public int NumberDocNext()
        {
            if (_DishsInRepository.Count()==0)
            return 1;
            else
            {
                return _DishsInRepository.Max(x => x.NumberDoc) + 1;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="DishRepositoryPlug">Список блюд, который необходимо хранить в репозитории</param>
        public DishRepositoryPlug(IList<IDish> DishRepositoryPlug)
        {
            _DishsInRepository = DishRepositoryPlug;
        }

        /// <summary>
        /// Возвращает список калькуляционных карточек
        /// </summary>
        /// <returns>Список калькуляционной карточки</returns>
        public IEnumerable<IDish> Fetch()
        {
            return _DishsInRepository;
        }

        /// <summary>
        /// Добавляет калькуляционную карточку в репозиторий 
        /// </summary>
        /// <param name="newDish">Добавляемое поле</param>
        public void Add(IDish newDish)
        {
            _DishsInRepository.Add(newDish);
        }

        /// <summary>
        /// Возвращает репозиторий калькуляционых карточек заполненный тестовыми данными
        /// </summary>
        /// <returns>Репозиторий калькуляционных карточек</returns>
        internal static DishRepositoryPlug CreateInstance()
        {
            return new DishRepositoryPlug(new List<IDish>());
        }

        /// <summary>
        /// Возвращает самый новый экземпляр блюда по переданному расширенному имени блюда
        /// </summary>
        /// <param name="ExpandedNameDish">Расширенное имя блюда</param>
        /// <returns>Новейший экземпляр блюда или null, если блюда с таким расширенным именем не найдены</returns>
        public IDish GetDishByName(string ExpandedNameDish)
        {
            if (_DishsInRepository.Where(x => x.ExpandedNameDish == ExpandedNameDish).FirstOrDefault() == null)
            {
                return null;
            }
            else
            {
                return _DishsInRepository.Where(x => x.ExpandedNameDish == ExpandedNameDish).OrderByDescending(x=>x.DateCreate).FirstOrDefault();
            }
        }
        /// <summary>
        /// Возвращает историю обновлений указанного блюда
        /// </summary>
        /// <param name="ExpandedNamedish">Расширенное имя блюда</param>
        /// <returns>Список со всеми обновлениями для данного блюда</returns>
        public IEnumerable<IDish> HistoryDish(string ExpandedNamedish) =>_DishsInRepository.Where(x => x.ExpandedNameDish == ExpandedNamedish).OrderByDescending(x => x.DateCreate);

            /// <summary>
            /// Возвращает список в котором находятся все блюда в единственном самом новом экземпляре
            /// </summary>
            /// <returns>Список самых новых блюд</returns>       
        public IEnumerable<IDish> LatestDish() =>_DishsInRepository.Where(y => y.DateCreate == _DishsInRepository.Where(x => x.ExpandedNameDish == y.ExpandedNameDish).Max(z => z.DateCreate)).OrderBy(x=>x.ExpandedNameDish);

        /// <summary>
        /// Проверяет содержится ли блюдо в репозитории
        /// </summary>
        /// <param name="dish">Проверяемое блюдо</param>
        /// <returns>true если содержится</returns>
        public bool CheckOnContain(IDish dish)
        {
            return _DishsInRepository.Contains(dish);
        }

        /// <summary>
        /// Проверка на уникальность расширенного названия блюда TRUE если не уникально
        /// </summary>
        /// <param name="ExpandedNameDish">Проверяемое расширенное наименование блюда</param>
        /// <returns>TRUE если не уникально</returns>
        public bool CheckOnExpandedNameDish(string ExpandedNameDish) => _DishsInRepository.Select(x => x.ExpandedNameDish).Contains(ExpandedNameDish);
    }
}
