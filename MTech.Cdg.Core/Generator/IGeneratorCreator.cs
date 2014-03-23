using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTech.Cdg.Core
{
   public interface IGeneratorCreator
   {
        IGenerator newGenerator(Typer typer);
   }
}
