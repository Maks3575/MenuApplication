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
        //DB_MenuEntities context;// = new DB_MenuEntities();
        public static ModelDB.Subdivision CurrentSubdivision { get; set; } //= new DB_MenuEntities().Subdivisions.First();

        public SubdivisionController()
        {
            //context = Context.context;
            CurrentSubdivision = Context.context.Subdivisions.First();

        }

        public IEnumerable<ModelDB.Subdivision> Fetch() => Context.context.Subdivisions;


        //internal static SubdivisionRepositoryPlug CreateInstance()
        //{
        //    return new SubdivisionRepositoryPlug(new List<Subdivision>()
        //    {
        //        new Subdivision("Столовая № 1"),
        //        new Subdivision("Столовая № 2"),
        //        new Subdivision("Столовая № 3"),
        //        new Subdivision("Столовая № 4"),
        //        new Subdivision("Столовая № 5"),
        //        new Subdivision("Столовая № 6"),
        //        new Subdivision("Столовая № 7"),
        //        new Subdivision("Столовая № 8"),
        //        new Subdivision("Столовая № 9"),
        //        new Subdivision("Столовая № 10")
        //    });
        //}
    }
}
