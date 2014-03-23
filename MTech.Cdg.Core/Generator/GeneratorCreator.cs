using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MTech.Cdg.Core
{
   public class GeneratorCreator : IGeneratorCreator
    {
        public  IGenerator newGenerator(Typer typer)
        {
            switch (typer.dataType)
            {
                case DataType.Int:
                    return new IntGenerator(typer);
                case DataType.String:
                    return new StringGenerator(typer);
                case DataType.Date:
                case DataType.Time:
                case DataType.DateTime:
                    return new DateTimeGenerator(typer);
                default:
                    throw new Exception("typer.dataType "+typer.dataType +"is not defined");
            }
        }


    }
}
