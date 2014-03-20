using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class ObjectBase
    {
        public string Identifier
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
            
        }

        public string Name
        {
            get;
            set;
        }
    }
}
