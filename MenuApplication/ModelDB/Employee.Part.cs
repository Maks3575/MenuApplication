using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.ModelDB
{
    partial class Employee
    {
        public Employee GetThis => this;

        public override string ToString() => ShortNameEmployee;

        public string FullName => $"{SurnameEmployee} {NameEmployee} {PatronymicEmloyee}";
    }
}
