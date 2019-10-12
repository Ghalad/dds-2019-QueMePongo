using System;
using System.Collections.Generic;
using System.Linq;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Contexto;

namespace Ar.UTN.QMP.Test.Entidades.DB
{
    [TestClass]
    public class Retrieving
    {
        List<Usuario> Usuarios;

        [TestInitialize]
        public void ImportarTodosLosUsuarios()
        {
            int contadorCaracteristicas = 0, i=1, j=1;

            var ctx = new QueMePongoDB();
            Usuarios = ctx.Usuarios.ToList();

            foreach (Usuario u in Usuarios)
            {
                Console.WriteLine("Cargando usuario  \"{0}\" ...", u.Username);
                ctx.Entry(u).Collection(a => a.Guardarropas).Load();

                Console.WriteLine("Total de {0} guardarropas ...", u.Guardarropas.Count);

                foreach (Guardarropa g in u.Guardarropas)
                {
                    ctx.Entry(g).Collection(b => b.Prendas).Load();

                    foreach (Prenda p in g.Prendas)
                    {
                        ctx.Entry(p).Collection(c => c.Caracteristicas).Load();
                        contadorCaracteristicas += p.CantidadDeCaracteristicas();
                    }
                    Console.WriteLine("Guardarropa {0} cargado con" +
                        " {1} prendas y en total {2} características ..."
                        , i, g.Prendas.Count, contadorCaracteristicas);
                    i++;
                }
                i = 1;

                Console.WriteLine("Cargando historial de atuendos aceptados ...");
                ctx.Entry(u).Collection(k => k.AtuendosAceptados).Load();


                foreach (Atuendo a in u.AtuendosAceptados)
                {
                    ctx.Entry(a).Collection(l => l.Prendas).Load();

                    foreach(Prenda p in a.Prendas)
                    {
                        ctx.Entry(p).Collection(m => m.Caracteristicas).Load();
                    }

                }

                Console.WriteLine("{0} atuendos en el historial con {1} prendas" +
                    " y {2} características ...", u.AtuendosAceptados.Count,
                    u.AtuendosAceptados.Sum(n => n.Prendas.Count),
                    u.AtuendosAceptados.Sum(o => o.Prendas.Sum(p => p.CantidadDeCaracteristicas())));

                ctx.Entry(u).Reference(d => d.Pedido).Load();
                if(u.Pedido != null)
                {
                    Console.WriteLine("Cargando pedido ...");
                    ctx.Entry(u.Pedido).Collection(e => e.Atuendos).Load();
                    Console.WriteLine("El pedido cargó {0} atuendos ...", u.Pedido.Atuendos.Count);

                    foreach (Atuendo a in u.Pedido.Atuendos)
                    {
                        ctx.Entry(a).Collection(f => f.Prendas).Load();
                        foreach(Prenda p in a.Prendas)
                        {
                            ctx.Entry(p).Collection(g => g.Caracteristicas).Load();
                        }

                        Console.WriteLine("Atuendo {0} cargado con un total de " +
                            "{1} prendas y {2} características", j, a.Prendas.Count,
                            a.Prendas.Sum(h => h.CantidadDeCaracteristicas()));
                        j++;
                    }
                    j = 1;
                    Console.WriteLine("");

                }
            }
        }

        [TestMethod]
        public void CantidadUsuarios()
        {
            Assert.AreEqual(Usuarios.Count , 2);
        }

        [TestMethod]
        public void CantidadPedidos()
        {
            int contador = 0;
            foreach(Usuario u in Usuarios)
            {
                if(u.Pedido != null)
                {
                    contador++;
                    u.Pedido.MostrarAtuendos();
                }
            }
            Assert.AreEqual(2, contador);
        }

        [TestMethod]
        public void ImprimirPrendasPorUsuario()
        {
            foreach(Usuario u in Usuarios)
            {
                Console.WriteLine("Usuario : {0}", u.Username);
                foreach(Prenda p in u.ObtenerPrendas())
                {
                    p.MostrarPorPantalla();
                }
            }

            Assert.AreEqual(1, 1);
        }
    }
}
