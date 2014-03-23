using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTech.Cdg.Core
{
    public abstract class aGenerator
    {
        protected Typer _typer;

        public aGenerator()
        {
        }

        public aGenerator(Typer typer)
        {
            _typer = typer;
        }


    }
}
