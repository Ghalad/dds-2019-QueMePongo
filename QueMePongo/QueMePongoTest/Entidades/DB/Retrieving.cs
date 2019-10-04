using System;
using System.Collections.Generic;
using System.Linq;
using Ar.UTN.QMP.Lib;
using System.Data.Entity;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Test.Entidades.DB
{
    [TestClass]
    public class Retrieving
    {
        List<Usuario> Usuarios;

        [TestInitialize]
        public void ImportarTodosLosUsuarios()
        {
            int contadorCaracteristicas = 0, i=0;

            var ctx = new QueMePongoDB();
            Usuarios = ctx.Usuarios.ToList();

            foreach (Usuario u in Usuarios)
            {
                Console.WriteLine("Username : {0}", u.Username);
                ctx.Entry(u).Collection(a => a.Guardarropas).Load();
                ctx.Entry(u).Reference(d => d.Pedido).Load();
                ctx.Entry(u.Pedido).Collection(e => e.Atuendos).Load();


                foreach (Guardarropa g in u.Guardarropas)
                {
                    ctx.Entry(g).Collection(b => b.Prendas).Load();
                    Console.WriteLine("Guardarropa {0} cargado", i);
                    
                    foreach (Prenda p in g.Prendas)
                    {
                        ctx.Entry(p).Collection(c => c.Caracteristicas).Load();
                        contadorCaracteristicas += p.CantidadDeCaracteristicas();
                    }
                    Console.WriteLine("{0} prendas cargadas", g.Prendas.Count);
                    Console.WriteLine("{0} caracteristicas cargadas", contadorCaracteristicas);
                }
                Console.WriteLine("{0} guardarropas cargados", u.Guardarropas.Count);
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
