using MenuApplication.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Domain
{
    /// <summary>
    /// Интерфейс для ингредиента
    /// </summary>
    public interface IIngredient
    {   
        /// <summary>
        /// Код ингредиента
        /// </summary>
        int IdIngredient { get; set; }

        /// <summary>
        /// Тип ингредиента
        /// </summary>
        TypeIngredient TypeIngredient { get; set; }

        /// <summary>
        /// Подразделение ингредиента
        /// </summary>
        ModelDB.Subdivision Subdivision { get; set; }

        /// <summary>
        /// Наименование ингредиента
        /// </summary>
        string NameIngredient { get; set; }
       
        /// <summary>
        /// Масса продукта из упаковки
        /// </summary>
        double MassInKg { get; set; }
        
        /// <summary>
        /// Начальная цена за массу продукта в упаковке
        /// </summary>
        decimal StartingPrice { get; set; }
        
        /// <summary>
        /// Цена за 1 кг ингредиента
        /// </summary>
        decimal PricePerOneKg { get; }

        /// <summary>
        /// Дата записи ингредиента в реестр
        /// </summary>
        DateTime RecordDate { get; set; }
        
        /// <summary>
        /// Содержание белка в 100 г ингредиента
        /// </summary>
        double Protein { get; set; }

        /// <summary>
        /// Содержание жира в 100 г ингредиента
        /// </summary>
        double Fat { get; set; }

        /// <summary>
        /// Содержание улевода в 100 г ингредиента
        /// </summary>
        double Carbohydrate { get; set; }

        /// <summary>
        /// Энергетическая ценность в 100 г ингредиента
        /// </summary>
        double CalorificValue { get; }

        /// <summary>
        ///Возвращает ссылку на данный объект
        /// </summary>
        IIngredient GetThis { get; }

        /// <summary>
        /// Возвращает копию объекта
        /// </summary>
        /// <returns>Копия ингредиента</returns>
        IIngredient Clone();
    }
}
