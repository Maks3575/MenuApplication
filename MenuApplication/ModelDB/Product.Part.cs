using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;

namespace MenuApplication.ModelDB
{
    partial class Product : IIngredient, IEquatable<Product> //IEqualityComparer<Product>
    {
        public double CalorificValue => (double)Ingredient.CalorificValue; // Protein * 4 + Carbohydrate * 4 + Fat * 9;

        public double Carbohydrate
        {
            get
            {
                return Ingredient.Carbohydrate;
            }
            set
            {
                Ingredient.Carbohydrate = (float)value;
            }
        }

        public double Fat
        {
            get
            {
                return Ingredient.Fat;
            }

            set
            {
                Ingredient.Fat = (float)value;
            }
        }

        public IIngredient GetThis => this;

        public int IdIngredient
        {
            get
            {
                return Ingredient.IDIngredient;
            }

            set
            {
                Ingredient.IDIngredient = value;
            }
        }

        public double MassInKg
        {
            get
            {
                return Mass;
            }

            set
            {
                Mass = (float)value;
            }
        }

        public string NameIngredient
        {
            get
            {
                return Ingredient.NameIngredient;
            }

            set
            {
                Ingredient.NameIngredient = value;
            }
        }

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

        public double Protein
        {
            get
            {
                return Ingredient.Protein;
            }

            set
            {
                Ingredient.Protein = (float)value;
            }
        }

        public DateTime RecordDate
        {
            get
            {
                return BeginDate;
            }

            set
            {
                BeginDate = value;
            }
        }

        public decimal StartingPrice
        {
            get
            {
                return Price;
            }

            set
            {
                Price = value;
            }
        }

        //public ModelDB.Subdivision Subdivision
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public TypeIngredient TypeIngredient
        {
            get
            {
                return Ingredient.TypeIngredient;
            }

            set
            {
                Ingredient.TypeIngredient = value;
            }
        }

        public IIngredient Clone()
        {
            return new Product() {
                Price = Price,
                Mass = Mass,
                BeginDate = BeginDate,
                Ingredient = Ingredient,
                Subdivision = Subdivision,
                Protein = Protein,
                Fat = Fat,
                Carbohydrate = Carbohydrate,
                TypeIngredient = TypeIngredient
            };
        }

        public bool Equals(Product other) => other != null && IDProduct == other.IDProduct;

        //public bool Equals(Product x, Product y) => x != null && y != null && x.IDProduct == IDProduct;

        //public int GetHashCode(Product obj) => obj == null ? 0 : obj.IDProduct.GetHashCode();

        public override bool Equals(object obj) => Equals(obj as Product);

        public override int GetHashCode() => IDProduct.GetHashCode();
    }
}