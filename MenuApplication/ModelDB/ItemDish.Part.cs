using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;
namespace MenuApplication.ModelDB
{
    partial class ItemDish : IDishItem
    {
        public double CalorificValueOn100Portion => (double)(Ingredient.CalorificValue * 10 * NormOn100Portions);

        public double CarbohydrateOn100Portion => Ingredient.Carbohydrate * 10 * NormOn100Portions;

        public double FatOn100Portion => Ingredient.Fat * 10 * NormOn100Portions;

        public string GetNameIngredient => Ingredient.NameIngredient;

        public double NormOn100Portions
        {
            get
            {
                return NormOn100Portion;
            }

            set
            {
                NormOn100Portion = (float)value; 
            }
        }

        public decimal PricePerOneKg
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double ProteinOn100Portion => Ingredient.Protein * 10 * NormOn100Portions;

        public decimal TotalInItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IIngredient IDishItem.Ingredient
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
