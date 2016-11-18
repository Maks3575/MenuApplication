using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.ModelDB;
namespace MenuApplication.Domain
{   
    /// <summary>
    /// Интерфейс для блюда
    /// </summary>
    interface IDish
    {   
        /// <summary>
        /// Список ингредиентов блюда
        /// </summary>
        IList<DishItem> DishItems { get; set; }

        /// <summary>
        /// Тип блюда
        /// </summary>
        TypeDish TypeDish { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        int NumberDoc { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        string  NameDish { get; set; }

        /// <summary>
        /// Расширенное наименование блюда(Уникальное наименование)
        /// </summary>
        string ExpandedNameDish { get; set; }

        /// <summary>
        /// Номер блюда по сборнику рецептур, ТТК, СТП
        /// </summary>
        string NumberInCollectionOfRecipes { get; set; }

        /// <summary>
        /// Номер калькуляционной карточки
        /// </summary>
        int NumberDish { get; set; }

        /// <summary>
        /// Дата составления калькуляционной карточки
        /// </summary>
        DateTime DateCreate { get; set; }

        /// <summary>
        /// Сумма 100 порций блюда
        /// </summary>
        decimal TotalDishOn100Portsion { get; }

        /// <summary>
        /// Цена одного блюда
        /// </summary>
        decimal PriceDish { get;}

        /// <summary>
        /// Выход одного блюда в готовом виде, грамм
        /// </summary>
        string WeightDish { get; set; }

        /// <summary>
        /// Возвращает количество белков в одной порции
        /// </summary>
        double ProteinOnOnePortion { get; }

        /// <summary>
        /// Возвращает количество жиров в одной порции
        /// </summary>
        double FatOnOnePortion { get; }

        /// <summary>
        /// Возвращает количество углеводов в одной порции
        /// </summary>
        double CarbohydrateOnOnePortion { get; }

        /// <summary>
        /// Возвращает количество калорийности в одной порции
        /// </summary>
        double CalorificValueOnOnePortion { get; }
    }
}
