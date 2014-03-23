using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MTech.Cdg.Core
{
    public class IntGenerator : aGenerator, IGenerator
    {
        public IntGenerator(Typer typer)
            : base(typer) { }

        public string Generate()
        {
            if (_typer == null) throw new ArgumentNullException("_typer");

            var rdn = MyRandom.Instance().Next(_typer.MinValue, _typer.MaxValue);
            return rdn.ToString(CultureInfo.InvariantCulture);
        }
    }
}
