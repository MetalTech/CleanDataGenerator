using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTech.Cdg.Core.Entities
{
   public class DBStruct
   {
       public IList<Table> Tables { get; set; }
       public IList<Relation> Relations { get; set; }   
   }
}
