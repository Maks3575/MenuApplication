using MenuApplication.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess.DB
{
    internal class SubdivisionController
    {
        public static ModelDB.Subdivision CurrentSubdivision { get; set; }

        public SubdivisionController()
        {
            CurrentSubdivision = Context.context.Subdivisions.First();
        }

        /// <summary>
        /// Получение списка подразделений
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModelDB.Subdivision> Fetch() => Context.context.Subdivisions;
    }
}
