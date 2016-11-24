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

        /// <summary>
        /// Конструктор
        /// </summary>
        public IngredientsController()
        {

        }

        /// <summary>
        /// Добаление нового продукта к ингредиенту
        /// </summary>
        /// <param name="newIngredient">Добавляемый ингредиент</param>
        public void Add(IIngredient newIngredient)
        {
            Context.context.Products.Add(new Product()
            {
                Price = newIngredient.StartingPrice,
                Mass = (float)newIngredient.MassInKg,
                BeginDate = newIngredient.RecordDate,
                IDIngredient = newIngredient.IdIngredient,
                IDSubdivision = newIngredient.Subdivision.IDSubdivision
            });
            Context.context.SaveChanges();
            Context.context.Dispose();
            Context.context = new DB_MenuEntities();
        }

        /// <summary>
        /// Добавление нового ингредиента
        /// </summary>
        /// <param name="newIngredient"> Новый ингредиент</param>
        /// <returns>Возвращает  true, если добавление прошло успешно</returns>
        public bool AddNewIngredient(IIngredient newIngredient)
        {
            if (Context.context.Ingredients.Select(x => x.NameIngredient).Contains(newIngredient.NameIngredient))
            {
                return false;
            }
            else
            {
                var ing = Context.context.Ingredients.Add(new ModelDB.Ingredient()
                {
                    NameIngredient = newIngredient.NameIngredient,
                    IDTypeIngredient = newIngredient.TypeIngredient.IDTypeIngredient,
                    Protein = (float)newIngredient.Protein,
                    Fat = (float)newIngredient.Fat,
                    Carbohydrate = (float)newIngredient.Carbohydrate
                } );
                Context.context.Products.Add(new Product()
                {
                    Price = newIngredient.StartingPrice,
                    Mass = (float)newIngredient.MassInKg,
                    BeginDate = newIngredient.RecordDate,
                    IDIngredient =ing.IDIngredient,
                    IDSubdivision = newIngredient.Subdivision.IDSubdivision
                });
                Context.context.SaveChanges();
                Context.context.Dispose();
                Context.context = new DB_MenuEntities();
                return true;
            }
        }

        /// <summary>
        /// Получение всех ингредиентов в подразделении
        /// </summary>
        /// <returns>Список продуктов</returns>
        public IEnumerable<IIngredient> Fetch() => Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Products.ToList();

        /// <summary>
        /// Находит ингредиент по имени
        /// </summary>
        /// <param name="Object">Имя ингредиента</param>
        /// <returns>Найденный ингредиент</returns>
        public IIngredient GetIngrByName(string Object) => Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Products
            .FirstOrDefault(x => x.Ingredient.NameIngredient == Object);

        /// <summary>
        /// Получение всех списка ингредиентов с самыми новыми экземплярами
        /// </summary>
        /// <returns> Реестр цен</returns>
        public IEnumerable<IIngredient> GetRegistry() => Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Products.Where(x => x.RecordDate == Fetch().Where(y => y.NameIngredient == x.NameIngredient).Max(z => z.RecordDate))
            .Distinct()
            .OrderBy(x => x.NameIngredient).ToList();
        /// <summary>
        /// Проверка на актуальностьингредиента
        /// </summary>
        /// <param name="ingr">Проверяемый ингредиент</param>
        /// <returns>True если актуален</returns>
        public bool TestOnChangeIngredient(IIngredient ingr)=> Context.context.Subdivisions
            .FirstOrDefault(subdiv => subdiv.NameSubdivision == SubdivisionController.CurrentSubdivision.NameSubdivision)
            .Products.Where(x => x.NameIngredient == ingr.NameIngredient)
            .All(x => x.RecordDate <= ingr.RecordDate);
    }
}
