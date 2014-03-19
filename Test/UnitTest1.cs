using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PruebaError
    {
        private Random rdn;

        [TestInitialize]
        private void Inicio()
        {
             rdn = new Random();
        }

        [TestMethod]
        public void GenerarNumeroAleatorio()
        {
          var resultado=  rdn.Next(0, 10);
            Assert.IsInstanceOfType(resultado,typeof(int));
        }
        [TestMethod]
        public void GenerarStringAleatorio()
        {
            int size = 20;

           var str= Path.GetRandomFileName();
            
        }
    }
}
