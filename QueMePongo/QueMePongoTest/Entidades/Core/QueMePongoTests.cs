using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ar.UTN.QMP.Lib.Entidades.Core.Tests
{
    [TestClass()]
    public class QueMePongoTests
    {
        [TestMethod()]
        public void CreacionDePedido()
        {
            /*
            try
            {
                int maxPrendas = 10;
                Usuario usr = new UsrGratis(maxPrendas);
                usr.CrearGuardarropa("g1");
                Regla regla;
                List<Caracteristica> listaCar;

                PrendaBuilder pb = new PrendaBuilder();

                #region PRENDAS
                pb.CrearPrenda()
                  .ConCategoria("accesorio")
                  .ConTipo("gorra")
                  .ConMaterial("lana")
                  .ConColor("verde")
                  .ConColor("negro")
                  .ConEvento("casual");
                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("remera_manga_corta")
                  .ConMaterial("algodon")
                  .ConColor("azul")
                  .ConColor("blanco")
                  .ConEvento("casual");
                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("campera_de_lluvia")
                  .ConMaterial("poliester")
                  .ConColor("negro")
                  .ConColor("azul")
                  .ConEvento("casual");
                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

                pb.CrearPrenda()
                  .ConCategoria("inferior")
                  .ConTipo("pantalon_largo")
                  .ConMaterial("poliester")
                  .ConColor("negro")
                  .ConEvento("casual");
                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

                pb.CrearPrenda()
                  .ConCategoria("calzado")
                  .ConTipo("panchas")
                  .ConMaterial("lana")
                  .ConColor("azul")
                  .ConEvento("casual");
                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());
                #endregion PRENDAS

                Evento evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo");

                #region REGLAS
                regla = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(new Caracteristica("categoria", "superior"));
                listaCar.Add(new Caracteristica("superposicion", "1"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(new Caracteristica("categoria", "superior"));
                listaCar.Add(new Caracteristica("superposicion", "2"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(new Caracteristica("categoria", "superior"));
                listaCar.Add(new Caracteristica("superposicion", "3"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(new Caracteristica("categoria", "superior"));
                listaCar.Add(new Caracteristica("superposicion", "4"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                regla = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(new Caracteristica("categoria", "calzado"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
                #endregion REGLAS

                usr.AgregarRegla(regla);

                Pedido pedido = new Pedido(usr, usr.Guardarropas.Find(g => g.Id.Equals("g1")).ObtenerPrendas(), usr.Reglas, evento);

                QueMePongo qmp = QueMePongo.GetInstance();

                qmp.AgregarPedido(pedido);

                //while (usr.Pedido == null) ;

                //Thread.Sleep(5000);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Assert.IsTrue(usr.Pedido.ObtenerAtuendos().Count > 0);

            */
        }
    }
}