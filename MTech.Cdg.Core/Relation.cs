using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class Relation : ObjectBase
    {
        public Column ParentColumn { get; set; }
        public Column ReferencedColumn { get; set; }
    }
}
