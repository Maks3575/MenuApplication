using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{
    internal class MenuRepositoryPlug:IMenuRepository
    {   
        /// <summary>
        /// Список экземпляров меню
        /// </summary>
        private readonly IList<IMenu> _IMenuInRepository;

        public int idMenuNext()
        {
            if (_IMenuInRepository.Count() == 0)
                return 1;
            else
            {
                return _IMenuInRepository.Max(x => x.IdMenu) + 1;
            }
        }

        /// <summary>
        /// Конструктор репозитория меню
        /// </summary>
        /// <param name="IMenuInRepository">Список экземпляров меню</param>
        public MenuRepositoryPlug(IList<IMenu> IMenuInRepository)
        {
            _IMenuInRepository = IMenuInRepository;
        }

        /// <summary>
        /// Возвращает список меню
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMenu> Fetch() => _IMenuInRepository;

        /// <summary>
        /// Добавляет в репозиторий меню новый экземпляр
        /// </summary>
        /// <param name="NewMenu">Добавляемое в репозиторий меню</param>
        public void Add(IMenu NewMenu)
        {
            _IMenuInRepository.Add(NewMenu);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static MenuRepositoryPlug CreateInstance()
        {
            return new MenuRepositoryPlug(new List<IMenu>());
        }

        public bool CheckOnTypeMenu(DateTime DT, string TM)
        {
            throw new NotImplementedException();
        }
    }
}
