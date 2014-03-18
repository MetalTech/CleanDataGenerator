using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class Table : ObjectBase
    {
        public List<Column> Columns { get; set; }
        public List<Constraint> Constraints { get; set; }
    }
}
