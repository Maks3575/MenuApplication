using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.DataAccess
{
    class SubdivisionRepositoryPlug
    {
        private readonly IList<Subdivision> _SubdivisionInRepository;

        public IEnumerable<Subdivision> Fetch() => _SubdivisionInRepository;

        public SubdivisionRepositoryPlug(IList<Subdivision> SRP)
        {
            _SubdivisionInRepository = SRP;
        }

        internal static SubdivisionRepositoryPlug CreateInstance()
        {
            return new SubdivisionRepositoryPlug(new List<Subdivision>()
            {
                new Subdivision("Столовая № 1"),
                new Subdivision("Столовая № 2"),
                new Subdivision("Столовая № 3"),
                new Subdivision("Столовая № 4"),
                new Subdivision("Столовая № 5"),
                new Subdivision("Столовая № 6"),
                new Subdivision("Столовая № 7"),
                new Subdivision("Столовая № 8"),
                new Subdivision("Столовая № 9"),
                new Subdivision("Столовая № 10")
            });
        }                                                             
    }
}
