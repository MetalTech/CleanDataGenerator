using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class AnalyzerResult
    {
        public Table Table { get; set; }
        public List<Table> ParentTables { get; set; }
        public List<Table> ChildTables { get; set; }
    }
}
