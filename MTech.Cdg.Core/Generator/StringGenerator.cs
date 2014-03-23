using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace MTech.Cdg.Core
{
    public class StringGenerator : aGenerator, IGenerator
    {
        public StringGenerator(Typer typer)
            : base(typer) { }

        public string Generate()
        {
            const string font = "abcdefghijklmnñopqrstuvwxyz";
            var value = string.Empty;

            var size = _typer.IsVariable ? MyRandom.Instance().Next(_typer.Size) : _typer.Size;

            for (var i = 0; i < size; i++)
            {
                value += font[MyRandom.Instance().Next(font.Length)].ToString(CultureInfo.InvariantCulture);
            }
            return value;
        }
    }
}
