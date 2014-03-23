using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTech.Cdg.Core
{
    public class MyRandom
    {
        private static Random _myRandom;
        private MyRandom(){}

        public static Random Instance()
        {
            _myRandom = _myRandom ?? new Random();
            return _myRandom;
        }
    }
}
