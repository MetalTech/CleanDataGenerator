using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTech.Cdg.Core;

namespace Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cNombre = new Column
            {
                Name = "Nombre",
                IsPk = true,
                size = 5
            };
            var cApellido = new Column
            {
                Name = "Apellido",
                size = 10
            };
            var tPersona = new Table
            {
                Name = "Persona",
                Columns = new List<Column> { cNombre, cApellido }
            };

            var pks = new Dictionary<string, List<string>>();
            tPersona.Columns.Where(x=>x.IsPk).ToList().ForEach(x => pks.Add(x.Name, new List<string>()));

            const int count = 100;
            var results = new string[count, tPersona.Columns.Count];
            for (var i = 0; i < count; i++)
            {
                foreach (var col in tPersona.Columns)
                {
                    var gen = GenerarString(col.size);
                    results[i, tPersona.Columns.IndexOf(col)] = gen;

                    if (col.IsPk) pks[col.Name].Add(gen);
                }
            }
            Assert.AreEqual(results.Length, 200);

        }

        private string GenerarString(int size, bool fix = true)
        {
            const string font = "abcdefghijklmnñopqrstuvwxyz";
            var result = string.Empty;
            size = fix ? size : (myRandom.instance().Next(size));
            for (var i = 0; i < size; i++)
            {
                result += font[myRandom.instance().Next(font.Length)].ToString();
            }
            return result;
        }

        private class myRandom
        {
            private static Random _myRandom;
            private myRandom()
            {

            }

            public static Random instance()
            {
                _myRandom = _myRandom ?? new Random();
                return _myRandom;
            }
        }


    }
}
