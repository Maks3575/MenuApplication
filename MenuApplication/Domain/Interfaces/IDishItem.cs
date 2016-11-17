using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Domain
{
    /// <summary>
    /// Интерфейс позиции в калькуляционной карточке
    /// </summary>
    interface IDishItem
    {
        /// <summary>
        /// Ингредиент 
        /// </summary>
        IIngredient Ingredient { get; set; }

        string GetNameIngredient { get; }

        /// <summary>
        /// Норма в килограммах на 100 порций
        /// </summary>
        double NormOn100Portions { get; set; }

        /// <summary>
        /// Цена за 1 кг ингредиента
        /// </summary>
        decimal PricePerOneKg { get; }

        /// <summary>
        /// Сумма ингредиента в позиции калькуляционной карточки
        /// </summary>
        decimal TotalInItem { get; }

        /// <summary>
        /// Содержание белка в 100 порциях блюда
        /// </summary>
        double ProteinOn100Portion { get;}

        /// <summary>
        /// Содержание жира в 100 порциях блюда
        /// </summary>
        double FatOn100Portion { get;}

        /// <summary>
        /// Содержание улевода в 100 порциях блюда
        /// </summary>
        double CarbohydrateOn100Portion { get; }

        /// <summary>
        /// Энергетическая ценность в 100 порциях блюда
        /// </summary>
        double CalorificValueOn100Portion { get; }
    }
}
