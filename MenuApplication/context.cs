using MenuApplication.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication
{
    public static class Context
    {
        public static DB_MenuEntities context { get; set; } = new DB_MenuEntities();
    }
}
