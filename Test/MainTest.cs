using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTech.Cdg.Core;
using System.Data;

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
                size = 5,
                datatype = DataType.Char
            };
            var cApellido = new Column
            {
                Name = "Apellido",
                size = 20,
                datatype = DataType.VarChar
            };
            var tPersona = new Table
            {
                Name = "Persona",
                Columns = new List<Column> { cNombre, cApellido }
            };

            var dt = new DataTable("Persona");


            var pks = new Dictionary<string, List<string>>();
            tPersona.Columns.Where(x => x.IsPk).ToList().ForEach(x => pks.Add(x.Name, new List<string>()));
            tPersona.Columns.ForEach(x => dt.Columns.Add(x.Name));

            const int count = 100;
            var results = new string[count, tPersona.Columns.Count];
            for (var i = 0; i < count; i++)
            {
                var row = dt.NewRow();
                foreach (var col in tPersona.Columns)
                {
                    var gen = GenerarString(col.size, col.datatype == DataType.Char);
                    results[i, tPersona.Columns.IndexOf(col)] = gen;
                    row[col.Name] = gen;
                    if (col.IsPk) pks[col.Name].Add(gen);
                }
                dt.Rows.Add(row);
            }

            Assert.AreEqual(results.Length, 200);

        }

        [TestMethod]
        public void TestMethod2()
        {

            #region Tablas
            #region Persona
            var tPersona = new Table
            {
                Name = "Persona",
                Level = 0,
                Columns = new List<Column> { new Column
            {
                Name = "Nombre",
                size = 5,
                IsPk = true,
                datatype = DataType.Char
            }, new Column
            {
                Name = "Apellido",
                size = 20,
                datatype = DataType.VarChar
            },new Column
            {
                Name = "Id",
                datatype = DataType.Int
            } }
            };
            #endregion
            #region Hijo


            var tHijo = new Table
            {
                Name = "Hijo",
                Level = 1,
                Columns = new List<Column> { new Column
                {
                    Name = "IDPadre",
                    datatype = DataType.Int,

                },
                new Column
                {
                    Name = "Valor",
                    datatype = DataType.Int,
                    size = 3
                }}
            };
            #endregion



            tPersona.Columns.ForEach(x => x.Table = tPersona);
            tHijo.Columns.ForEach(x => x.Table = tHijo);

            var relaciones = new List<Relation>
            {
                new Relation
                {
                    Name = "Persona-hijo",
                    ParentColumn = tPersona.Columns.First(x => x.Name == "Nombre"),
                    ReferencedColumn = tHijo.Columns.First(x => x.Name == "Valor")
                }
            };

            var tablas = new List<Table> { tHijo, tPersona };

            Func<string, bool> UsaLista =
                identificador => relaciones.Any(x => x.ReferencedColumn.Name == identificador);
            Func<string, string> ListaUsar =
                identificador => relaciones.First(x => x.ReferencedColumn.Name == identificador).ParentColumn.Name;
            #endregion

            var ds = new DataSet();
            foreach (var tabla in tablas)
            {
                ds.Tables.Add(tabla.Name);
                foreach (var col in tabla.Columns)
                {
                    ds.Tables[tabla.Name].Columns.Add(col.Name);
                }
            }


            var pks = new Dictionary<string, List<string>>();
            (from t in tablas
             from c in t.Columns
             where c.IsPk
             select c).ToList()
             .ForEach(x => pks.Add(x.Name, new List<string>()));

            const int count = 5;
            var levels = tablas.Select(x => x.Level).Distinct().OrderBy(x=>x).ToList();

            foreach (var level in levels)
            {
                var tablasLevel = tablas.Where(x => x.Level == level).ToList();
                foreach (var table in tablasLevel)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var dr = ds.Tables[table.Name].NewRow();
                        foreach (var col in table.Columns)
                        {
                            var gen = string.Empty;
                            if (UsaLista(col.Name))
                            {
                                gen = GeneradorLista(pks[ListaUsar(col.Name)]);
                            }
                            else
                            {
                                if (col.datatype == DataType.Int)
                                    gen = GenerarInt();
                                else
                                    gen = GenerarString(col.size, col.datatype == DataType.Char);
                            }

                            dr[col.Name] = gen;
                            if (col.IsPk) pks[col.Name].Add(gen);
                        }
                        ds.Tables[table.Name].Rows.Add(dr);
                    }
                }
            }


            Assert.AreEqual(ds.Tables.Count, 2);

        }

        private string GeneradorLista(IReadOnlyList<string> list)
        {
            return list[MyRandom.Instance().Next(list.Count - 1)];
        }
        private string GenerarString(int size, bool fix = true)
        {
            const string font = "abcdefghijklmnñopqrstuvwxyz";
            var result = string.Empty;
            size = fix ? size : (MyRandom.Instance().Next(size));
            for (var i = 0; i < size; i++)
            {
                result += font[MyRandom.Instance().Next(font.Length)].ToString();
            }
            return result;
        }

        private string GenerarInt(int size = 100)
        {
            return MyRandom.Instance().Next(size).ToString();
        }
        


    }
}
