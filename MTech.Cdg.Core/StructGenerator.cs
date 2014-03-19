using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace MTech.Cdg.Core
{
    public abstract class StructGenerator : IStructGenerator
    {
        private ResXResourceReader resx;

        protected StructGenerator(string resourceName)
        {
            resx=new ResXResourceReader(resourceName);
        }

        public string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
