﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.ModelDB
{
    partial class TypeMenu
    {
        public TypeMenu GetThis => this;

        public override string ToString() => NameTypeMenu;
    }
}
