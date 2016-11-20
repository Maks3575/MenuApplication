using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.ModelDB;

namespace MenuApplication.Domain
{   
    class Menu:IMenu
    {
        /// <summary>
        /// Список блюд входящих в меню
        /// </summary>
        public IList<IDish> Dishs { get; set; }

        

        /// <summary>
        /// Дата создания меню
        /// </summary>
        public DateTime DateCreateMenu { get; set; }

        /// <summary>
        /// Id меню
        /// </summary>
        public int IdMenu { get; }

        public ModelDB.Subdivision Subdivision
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Employee ChiefCooker
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Employee Calculator
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TypeMenu TypeMenu
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Menu() { }
        
        /// <summary>
        /// Конструктор меню
        /// </summary>
        /// <param name="_Dishs">Список блюд в меню</param>
        /// <param name="_DateCreateMenu">Дата создания меню</param>
        /// <param name="_IdMenu">Id меню</param>
        public Menu(IList<IDish> _Dishs, DateTime _DateCreateMenu, int _IdMenu)
        {
            Dishs = _Dishs;
            DateCreateMenu = _DateCreateMenu;
            IdMenu = _IdMenu;
        }
    }
}
