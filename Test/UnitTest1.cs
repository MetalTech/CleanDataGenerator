using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PruebaError
    {
        private Random _rdn;

        [TestInitialize]
        public void Inicio()
        {
            _rdn = new Random();
        }

        [TestMethod]
        public void GenerarNumeroAleatorio()
        {
            var resultado = NumeroAleatorio();
            Assert.IsInstanceOfType(resultado, typeof(int));
        }
        [TestMethod]
        public void GenerarNumeroAleatorioMinMax()
        {
            var resultado = NumeroAleatorio(10);
            Assert.IsTrue(resultado >= 0 && resultado <= 10);
        }
        [TestMethod]
        public void GenerarStringAleatorioUniforme()
        {
            var size = NumeroAleatorio(100);
            var cantidad = NumeroAleatorio(10);
            var list = (new string[cantidad]).ToList();
            list.ForEach(x=>x=CadenaAleatoria(size));
            Assert.IsTrue(list.TrueForAll(x=>x.Length==size));
        }
        [TestMethod]
        public void GenerarStringAleatorioVariable()
        {
            const int min = 0;
            const int max = 100;
            var cantidad = NumeroAleatorio(100);
            var list = (new string[cantidad]).ToList();
            list.ForEach(x=>x=CadenaAleatoria(NumeroAleatorio(min,max)));

            Func<List<string>, bool> validacion = x =>
            {
                var y = x.Select(a => a.Length).ToList();
                var z = y[0];
                return y.Count(a => a.Equals(z)) == y.Count();
            };
            Assert.IsTrue(validacion(list));
        }

        private int NumeroAleatorio()
        {
            return _rdn.Next();
        }
        private int NumeroAleatorio( int max)
        {
            return NumeroAleatorio(0, max);
        }
        private int NumeroAleatorio(int min, int max)
        {
            return _rdn.Next(min, max);
        }

        private string CadenaAleatoria(int size)
        {
            var res = (size % 11);
            var rep = (size / 11) + (res == 0 ? 0 : 1);
            var resp = string.Empty;

            for (var i = 0; i < rep; i++)
            {
                resp += Path.GetRandomFileName().Replace(".", "");
            }
            return resp.Substring(0, size);

            
        }
    }
}
