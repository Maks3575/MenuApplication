using MenuApplication.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess.DB
{
    class DirectoryController
    {
        DB_MenuEntities context;

        public DirectoryController()
        {
            context = new DB_MenuEntities();
        }


        public IEnumerable<TypeIngredient> TypeIngredientFetch() => context.TypeIngredients.ToList();

    }
}
