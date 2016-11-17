using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;

namespace MenuApplication.ModelDB
{
    partial class Dish : IDish
    {
        public double CalorificValueOnOnePortion => (double)ItemDishes
            .Sum(x => x.Ingredient.CalorificValue * x.NormOn100Portion / 10);

        public double CarbohydrateOnOnePortion => ItemDishes
            .Sum(x => x.Ingredient.Carbohydrate * x.NormOn100Portion / 10);

        public DateTime DateCreate
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

        public IList<DishItem> DishItems
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

        public double FatOnOnePortion => ItemDishes
            .Sum(x => x.Ingredient.Fat * x.NormOn100Portion / 10);

        public int NumberDish
        {
            get
            {
                return IDDish;
            }

            set
            {
                IDDish = value;
            }
        }

        public int NumberDoc
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

        public decimal PriceDish
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double ProteinOnOnePortion => ItemDishes
            .Sum(x => x.Ingredient.Protein * x.NormOn100Portion / 10);

        public decimal TotalDishOn100Portsion//=>ItemDishes.Sum(x=>x.Ingredient.Products)
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal TotalDishOn100Portion(DateTime DT) => (decimal)ItemDishes
                .Sum(x => x.Ingredient.Products.Where(y => y.BeginDate <= DT).FirstOrDefault().PriceFor1Kg * x.NormOn100Portion);
        public decimal TotalDish1Portion(DateTime DT) => TotalDishOn100Portion(DT) / 100;
    }
}
