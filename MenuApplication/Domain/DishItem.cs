using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Domain
{
    /// <summary>
    /// Класс позиции в калькуляционной карточке
    /// </summary>
    internal class DishItem : IDishItem
    {
        /// <summary>
        /// Ингредиент 
        /// </summary>
        public IIngredient Ingredient { get; set; }

        /// <summary>
        /// Переопределение метода ToString для ингредиента 
        /// </summary>
        /// <returns>Наименование ингрдиента</returns>
        public override string ToString()
        {
            return Ingredient.NameIngredient;
        }

        public string GetNameIngredient => Ingredient.NameIngredient;

        /// <summary>
        /// Норма ингредиента в килограммах на 100 порций
        /// </summary>
        public double NormOn100Portions { get; set; }


        public DishItem() { }

        /// <summary>
        /// Конструктор позиции в калькуляционной карточке
        /// </summary>
        /// <param name="_Ingredient">Объект ингрединта в калькуляционной карточке</param>
        /// <param name="_NormOn100Portions">Вес ингредиента на 100 порций</param>
        public DishItem(IIngredient _Ingredient, double _NormOn100Portions)
        {
            Ingredient = _Ingredient;
            NormOn100Portions = _NormOn100Portions;
        }

        /// <summary>
        /// Сумма ингредиента в позиции калькуляционной карточки
        /// </summary>
        public decimal TotalInItem => (decimal)NormOn100Portions * PricePerOneKg;
        
        /// <summary>
        /// Возващает цену за 1 кг ингредиента
        /// </summary>
        public decimal PricePerOneKg
        {
            get
            {
                if (Ingredient == null) { return 0.00M; }
                else { return Ingredient.PricePerOneKg; }
            } 
        }

        /// <summary>
        /// Возвращает количество белков в ингредиенте в 100 порциях
        /// </summary>
        public double ProteinOn100Portion => NormOn100Portions*10 * Ingredient.Protein;

        /// <summary>
        /// Возвращает количество жиров в ингредиенте в 100 порциях
        /// </summary>
        public double FatOn100Portion => NormOn100Portions * 10 * Ingredient.Fat;

        /// <summary>
        /// Возвращает количество углеводов в ингредиенте в 100 порциях
        /// </summary>
        public double CarbohydrateOn100Portion => NormOn100Portions * 10 * Ingredient.Carbohydrate;

        /// <summary>
        /// Возвращает количество калорийности в ингредиенте в 100 порциях
        /// </summary>
        public double CalorificValueOn100Portion => NormOn100Portions * 10 * Ingredient.CalorificValue;
    }
}
