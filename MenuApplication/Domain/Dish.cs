using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.ModelDB;

namespace MenuApplication.Domain
{   
    /// <summary>
    /// Класс калькуляционная каточка (блюдо)
    /// </summary>
    class Dish:IDish
    {
        /// <summary>
        /// Список ингредиентов блюда
        /// </summary>
        public IList<DishItem> DishItems { get; set; }

        /// <summary>
        /// Номер калькуляционной карточки
        /// </summary>
        public int NumberDoc { get; set; }

        /// <summary>
        /// Дата составления калькуляционной карточки
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Название блюда
        /// </summary>
        public string NameDish { get; set; }

        /// <summary>
        /// Сумма 100 порций блюда
        /// </summary>
        public decimal TotalDishOn100Portsion => DishItems.Sum(x => x.TotalInItem);

        /// <summary>
        /// Цена одного блюда
        /// </summary>
        public decimal PriceDish => TotalDishOn100Portsion / 100;

        /// <summary>
        /// Выход одного блюда в готовом виде, грамм
        /// </summary>
        public string WeightDish { get; set; }

        /// <summary>
        /// Расширенное наименование блюда
        /// </summary>
        public string ExpandedNameDish { get; set; }

        /// <summary>
        /// Номер блюда по сборнику рецептур, ТТК, СТП
        /// </summary>
        public string NumberInCollectionOfRecipes { get; set; }

        /// <summary>
        /// Номер калькуляционной карточки
        /// </summary>
        public int NumberDish { get; set; }

        public Dish() { }     
        
        /// <summary>
        /// Конструктор калькуляционной карточки
        /// </summary>
        /// <param name="_DishItems">Список полей калькуляционной карточки</param>
        /// <param name="_NumerDoc">Номер документа</param>
        /// <param name="_DateCreate">Дата составления</param>
        /// <param name="_NameDish">Наименование блюда</param>
        /// <param name="_ExpandedNameDish">Расширенное наименование блюда</param>
        /// <param name="_NumberInCollectionOfRecipes">Номер блюда по сборнику рецептур, ТТК, СТП</param>
        /// <param name="_WeightDish">Выход 1 порции готового блюда</param>
        public Dish(int _NumerDoc, DateTime _DateCreate, string _NameDish, 
            string _ExpandedNameDish, string _NumberInCollectionOfRecipes, string _WeightDish, IList<DishItem> _DishItems)
        {
            WeightDish=_WeightDish;
            DishItems = _DishItems;
            NumberDoc = _NumerDoc;
            DateCreate = _DateCreate;
            NameDish = _NameDish;
            ExpandedNameDish = _ExpandedNameDish;
            NumberInCollectionOfRecipes=_NumberInCollectionOfRecipes;            
        }

        public Dish(IDish dish,DateTime dt, IList<DishItem> _DishItems)
        {
            WeightDish = dish.WeightDish;
            DishItems = _DishItems;
            NumberDoc = dish.NumberDoc;
            DateCreate = dt;
            NameDish = dish.NameDish;
            ExpandedNameDish = dish.ExpandedNameDish;
            NumberInCollectionOfRecipes = dish.NumberInCollectionOfRecipes;
        }


        /// <summary>
        /// Возвращает количество белков в одной порции
        /// </summary>
        public double ProteinOnOnePortion => DishItems.Sum(x => x.ProteinOn100Portion)/100;

        /// <summary>
        /// Возвращает количество жиров в одной порции
        /// </summary>
        public double FatOnOnePortion => DishItems.Sum(x => x.FatOn100Portion)/100;

        /// <summary>
        /// Возвращает количество углеводов в одной порции
        /// </summary>
        public double CarbohydrateOnOnePortion => DishItems.Sum(x => x.CarbohydrateOn100Portion)/100;

        /// <summary>
        /// Возвращает количество калорийности в одной порции
        /// </summary>
        public double CalorificValueOnOnePortion => DishItems.Sum(x => x.CalorificValueOn100Portion) / 100;

        public TypeDish TypeDish { get; set; }
    }
}
