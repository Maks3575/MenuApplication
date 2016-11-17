using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication
{
    class Subdivision
    {
        public string NameSubdivision { get; set; }

        public Subdivision(string nameSubdivision)
        {
            NameSubdivision = nameSubdivision;
        }

        public Subdivision GetThis => this;

    }
}
