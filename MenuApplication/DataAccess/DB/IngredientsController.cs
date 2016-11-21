using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;
using MenuApplication.ModelDB;

namespace MenuApplication.DataAccess.DB
{
    internal class IngredientsController : IIngredientRepositopy
    {
        DB_MenuEntities context;

        /// <summary>
        /// Конструктор
        /// </summary>
        public IngredientsController()
        {
            context = new DB_MenuEntities();
        }

        /// <summary>
        /// Добаление нового продукта к ингредиенту
        /// </summary>
        /// <param name="newIngredient">Добавляемый ингредиент</param>
        public void Add(IIngredient newIngredient)
        {
            context.Products.Add(new Product()
            {
                Price = newIngredient.StartingPrice,
                Mass = (float)newIngredient.MassInKg,
                BeginDate = newIngredient.RecordDate,
                IDIngredient = newIngredient.IdIngredient,
                IDSubdivision = newIngredient.Subdivision.IDSubdivision
            });
            context.SaveChanges();

            //context.Dispose();
            //context = new DB_MenuEntities();
        }

        public bool AddNewIngredient(IIngredient newIngredient)
        {
            if (context.Ingredients.Select(x => x.NameIngredient).Contains(newIngredient.NameIngredient))
            {
                return false;
            }
            else
            {
                var ing = context.Ingredients.Add(new ModelDB.Ingredient()
                {
                    NameIngredient = newIngredient.NameIngredient,
                    IDTypeIngredient = newIngredient.TypeIngredient.IDTypeIngredient,
                    Protein = (float)newIngredient.Protein,
                    Fat = (float)newIngredient.Fat,
                    Carbohydrate = (float)newIngredient.Carbohydrate
                } );
                context.SaveChanges();

                //ModelDB.Ingredient ing = context.Ingredients.FirstOrDefault(x => x.NameIngredient == newIngredient.NameIngredient);
                context.Products.Add(new Product()
                {
                    Price = newIngredient.StartingPrice,
                    Mass = (float)newIngredient.MassInKg,
                    BeginDate = newIngredient.RecordDate,
                    //Ingredient = ing,
                    IDIngredient =ing.IDIngredient,
                    IDSubdivision = newIngredient.Subdivision.IDSubdivision
                });
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<IIngredient> Fetch() => SubdivisionController.CurrentSubdivision.Products.ToList();


        public IIngredient GetIngrByName(string Object) => SubdivisionController.CurrentSubdivision.Products
            .FirstOrDefault(x => x.Ingredient.NameIngredient == Object);

        public IEnumerable<IIngredient> GetRegistry() => SubdivisionController.CurrentSubdivision.Products
            .Where(x => x.RecordDate == Fetch().Where(y => y.NameIngredient == x.NameIngredient).Max(z => z.RecordDate))
            .Distinct()
            .OrderByDescending(x => x.NameIngredient);

        public bool TestOnChangeIngredient(IIngredient ingr)=> SubdivisionController.CurrentSubdivision.Products
            .Where(x => x.NameIngredient == ingr.NameIngredient)
            .All(x => x.RecordDate <= ingr.RecordDate);


    }
}
