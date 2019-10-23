using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Ar.UTN.QMP.Test.Entidades.DB
{
    [TestClass]
    public class Updating
    {
        Usuario user;

        public void CargarUsuario(string username, QueMePongoDB ctx)
        {
            int contadorCaracteristicas = 0, i = 1, j = 1;

            user = ctx.Usuarios.SingleOrDefault(b => b.Username == username);

            Console.WriteLine("Cargando usuario  \"{0}\" ...", user.Username);
            ctx.Entry(user).Collection(a => a.Guardarropas).Load();

            Console.WriteLine("Total de {0} guardarropas ...", user.Guardarropas.Count);

            foreach (Guardarropa g in user.Guardarropas)
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
            ctx.Entry(user).Collection(k => k.AtuendosAceptados).Load();


            foreach (Atuendo a in user.AtuendosAceptados)
            {
                ctx.Entry(a).Collection(l => l.Prendas).Load();

                foreach (Prenda p in a.Prendas)
                {
                    ctx.Entry(p).Collection(m => m.Caracteristicas).Load();
                }

            }

            Console.WriteLine("{0} atuendos en el historial con {1} prendas" +
                " y {2} características ...", user.AtuendosAceptados.Count,
                user.AtuendosAceptados.Sum(n => n.Prendas.Count),
                user.AtuendosAceptados.Sum(o => o.Prendas.Sum(p => p.CantidadDeCaracteristicas())));

            ctx.Entry(user).Reference(d => d.Pedido).Load();
            if (user.Pedido != null)
            {
                Console.WriteLine("Cargando pedido ...");
                ctx.Entry(user.Pedido).Collection(e => e.Atuendos).Load();
                Console.WriteLine("El pedido cargó {0} atuendos ...", user.Pedido.Atuendos.Count);

                foreach (Atuendo a in user.Pedido.Atuendos)
                {
                    ctx.Entry(a).Collection(f => f.Prendas).Load();
                    foreach (Prenda p in a.Prendas)
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

        //OK
        [TestMethod]
        public void ModificarMaximo()
        {
            QueMePongoDB ctx = new QueMePongoDB();
            string username = "manurocck";

            this.CargarUsuario(username, ctx);
            Assert.AreEqual(10, user.MaximoPrendas);

            user.MaximoPrendas = 20;
            ctx.SaveChanges();

            this.CargarUsuario(username, ctx);
            Assert.AreEqual(10, user.MaximoPrendas);
        }

        [TestMethod]
        public void AceptarAtuendoYGuardar()
        {
            QueMePongoDB ctx = new QueMePongoDB();
            string username = "manurocck";

            this.CargarUsuario(username, ctx);
            user.Pedido.AceptarAtuendo(32, 10);

            ctx.SaveChanges();

            this.CargarUsuario(username, ctx);

            Assert.IsTrue(user.AtuendosAceptados.Count == 1);
        }
    }
}
