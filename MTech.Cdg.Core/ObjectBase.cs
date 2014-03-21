using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTech.Cdg.Core
{
    public class ObjectBase
    {
        private  string _identifier ;

        public string Identifier
        {
            get
            {
                if (string.IsNullOrEmpty(_identifier))
                    _identifier = Guid.NewGuid().ToString();
                return _identifier;
            }
            
        }

        public string Name
        {
            get;
            set;
        }
    }
}
