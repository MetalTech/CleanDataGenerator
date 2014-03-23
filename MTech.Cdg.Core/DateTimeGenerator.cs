using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class DateTimeGenerator : aGenerator, IGenerator
    {
        public DateTimeGenerator(Typer typer)
            : base(typer)
        {

        }

        public string Generate()
        {
            if (_typer == null) throw new ArgumentNullException("_typer");
            switch (_typer.dataType)
            {
                case DataType.Date:
                    return getDate(_typer.MinDate, _typer.MaxDate).ToShortDateString();
                case DataType.Time:
                    return getDate(_typer.MinTime, _typer.MaxTime).ToLongTimeString();
                case DataType.DateTime:
                    var time = getDate(_typer.MinTime, _typer.MaxTime);
                    var date = getDate(_typer.MinDate, _typer.MaxDate).Add(new TimeSpan(time.Ticks));
                    return date.ToShortDateString() + " " + date.ToLongTimeString();
                default:
                    throw new Exception();
            }
        }

        private DateTime getDate(DateTime min, DateTime max)
        {
            var range = max - min;

            var randTimeSpan = new TimeSpan((long)(MyRandom.Instance().NextDouble() * range.Ticks));

            return min + randTimeSpan;
        }

    }
}
