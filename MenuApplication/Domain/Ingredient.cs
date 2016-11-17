using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.ModelDB;

namespace MenuApplication.Domain
{   
    /// <summary>
    /// Класс ингредиента
    /// </summary>
    internal class Ingredient:IIngredient
    {
        /// <summary>
        /// Код ингредиента
        /// </summary>
        public int IdIngredient { get; set; }

        /// <summary>
        /// Переопределение метода ToString() для класса Ingredient
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return NameIngredient;
        }

        /// <summary>
        /// Наименование ингредиента
        /// </summary>
        public string NameIngredient { get; set; }

        /// <summary>
        /// Масса продукта из упаковки
        /// </summary>
        public double MassInKg { get; set; }

        /// <summary>
        /// Начальная цена за массу продукта в упаковке
        /// </summary>
        public decimal StartingPrice { get; set; }

        /// <summary>
        /// Цена за 1 кг ингредиента
        /// </summary>
        public decimal PricePerOneKg
        {
            get
            {
                if ((decimal)MassInKg == 0)
                    return (decimal)1;
                else
                    return StartingPrice / (decimal)MassInKg;
            }
        }

        /// <summary>
        /// Дата записи ингредиента в реестр
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// Содержание белка в 100 г ингредиента
        /// </summary>
        public double Protein { get; set; }
        
        /// <summary>
        /// Содержание жира в 100 г ингредиента
        /// </summary>
        public double Fat { get; set; }
        
        /// <summary>
        /// Содержание углевода в 100 г ингредиента
        /// </summary>
        public double Carbohydrate { get; set; }

        /// <summary>
        /// Энергетическая ценность в 100 г ингредиента
        /// </summary>
        public double CalorificValue
        {
            get { return Protein*4 + Carbohydrate*4 + Fat*9; }
        }

        public Ingredient() { }

        /// <summary>
        /// Конструктор создания ингредиента
        /// </summary>
        ///// <param name="_IdIngredient"></param>
        /// <param name="_NameIngredient">Название ингредиента</param>
        /// <param name="_MassInKg">Maсса ингредиента из упаковки</param>
        /// <param name="_StartingPrice">Начальная цена</param>
        /// <param name="_RecordDate">Дата записи в реестр</param>
        /// <param name="_Protein">Белок в 100 г ингредиента</param>
        /// <param name="_Fat">Жир в 100 г ингредиента</param>
        /// <param name="_Carbohydrate">Углевод в 100 г ингредиента</param>
        public Ingredient(string _NameIngredient, double _MassInKg, 
            decimal _StartingPrice, DateTime _RecordDate, double _Protein, double _Fat, double _Carbohydrate)
        {
            //IdIngredient = _IdIngredient;
            NameIngredient = _NameIngredient;
            MassInKg = _MassInKg;
            StartingPrice = _StartingPrice;
            RecordDate = _RecordDate;
            Protein = _Protein;
            Fat = _Fat;
            Carbohydrate = _Carbohydrate;
        }

        /// <summary>
        /// Создает копию объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        public IIngredient Clone()
        {
            return (Ingredient)MemberwiseClone();
        }


        public IIngredient GetThis => this;

        public TypeIngredient TypeIngredient
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ModelDB.Subdivision Subdivision
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
