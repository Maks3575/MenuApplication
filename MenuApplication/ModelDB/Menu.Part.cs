using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.ModelDB
{
    partial class Menu : IMenu
    {
        public DateTime DateCreateMenu
        {
            get
            {
                return UseDate;
            }

            set
            {
                UseDate = value;
            }
        }

        public IList<IDish> Dishs { get; set; }

        public int IdMenu => IDMenu;
    }
}
