using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.ModelDB
{
    public partial class Dish : IEqualityComparer<Dish>
    {
        public bool Equals(Dish x, Dish y) => x != null && y != null && x.ExpandedNameDish == ExpandedNameDish;

        public int GetHashCode(Dish obj) => obj.IDDish == null ? 0 : obj.IDDish.GetHashCode()^obj.IDTypeDish.GetHashCode();
    }
}
