using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTech.Cdg.Core
{
   public class Typer
   {
       private DateTime? _minDate;
       private DateTime? _maxDate;
       private DateTime? _minTime;
       private DateTime? _maxTime;

       public int Size { get; set; }
       public int MinValue { get; set; }
       public int MaxValue { get; set; }


       public DataType dataType { get; set; }

       public bool IsVariable { get; set; }

       public DateTime MinDate {
           get { return _minDate ?? DateTime.MinValue;; }
           set
           {
               _minDate = value;
           }
       }
       public DateTime MaxDate
       {
           get { return _maxDate ?? DateTime.MaxValue; ; }
           set
           {
               _maxDate = value;
           }
       }


       public DateTime MinTime {
           get { return _minTime ?? DateTime.MinValue; }
           set { _minTime= value ; }
       }

       public DateTime MaxTime
       {
           get { return _maxTime ?? DateTime.MinValue.AddDays(1).AddMilliseconds(-1); }
           set { _maxTime = value; }
       }
   }
}
