using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Domain;

namespace MenuApplication.DataAccess.DB
{
    class ItemDishController : IDishItemRepository
    {
        public void Add(IDishItem newDishItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDishItem> Fetch()
        {
            throw new NotImplementedException();
        }
    }
}
