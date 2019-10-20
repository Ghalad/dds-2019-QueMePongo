using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ar.UTN.QMP.Lib.Entidades.Core.Tests
{
    [TestClass()]
    public class SchedulerTests
    {
        GestorCaracteristicas GeGa;
        Usuario usr1, usr2;
        Guardarropa g1;
        Regla r1;
        List<Caracteristica> listaCar;
        PrendaBuilder pb;
        Evento evento;
        Pedido pedido;
        QueMePongo qmp;
        DateTime fecha;
        CultureInfo culture;
        Scheduler scheduler;


        [TestInitialize]
        public void Initialize()
        {
            this.GeGa = GestorCaracteristicas.GetInstance();
            this.pb = new PrendaBuilder();
            this.qmp = QueMePongo.GetInstance();
            culture = new CultureInfo("en-US");
            scheduler = Scheduler.GetInstance();
        }


        [TestMethod()]
        public void AgregarPedidoTest()
        {
            usr1 = new UsrGratis(2, "Guido");

            fecha = Convert.ToDateTime("1/3/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/4/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/2/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/1/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));


            Assert.IsTrue(scheduler.CantidadPedidos() == 4);
        }

        [TestMethod]
        public void ResolverPedidosTest1()
        {
            int maxPrendas = 10;
            usr1 = new UsrGratis(maxPrendas, "Guido");
            g1 = new Guardarropa(maxPrendas);

            #region PRENDAS
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro")
              .ConEvento("casual");
            g1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco")
              .ConEvento("casual");
            g1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul")
              .ConEvento("casual");
            g1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConEvento("casual")
              .ConEvento("trabajo");
            g1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("panchas")
              .ConMaterial("lana")
              .ConColor("azul")
              .ConEvento("casual")
              .ConEvento("casamiento");
            g1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("ojotas")
              .ConMaterial("goma")
              .ConColor("azul")
              .ConEvento("casual");
            g1.AgregarPrenda(pb.ObtenerPrenda());
            #endregion PRENDAS

            #region REGLAS

            #region SUPERPOSICION
            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "1"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "2"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "3"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "4"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "1"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "4"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "1"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "3"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            usr1.AgregarRegla(r1);

            #endregion SUPERPOSICION

            // descarta los atuendos que no tengan prendas en la parte superior
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que no tengan prendas en la parte inferior
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "inferior"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que no tengan calzado
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "calzado"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            usr1.AgregarRegla(r1);

            // descarta los atuendos que tengan mas de 1 calzado
            r1 = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "calzado"));
            r1.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            usr1.AgregarRegla(r1);
            #endregion REGLAS

            #region USUARIOS
            usr1.SetSensibilidad("CALUROSO");
            usr1.AgregarGuardarropa(g1);
            #endregion
            

            fecha = Convert.ToDateTime("1/3/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/4/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/2/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));
            fecha = Convert.ToDateTime("1/1/2020 12:10:15 PM", culture);
            scheduler.AgregarPedido(new Pedido(usr1, new Evento("casual", fecha, "Buenos Aires", "Ir a tomar un healdo", "UNICO")));

            while (scheduler.CantidadPedidos() > 0)
            {
                scheduler.DesencolarPedido();
            }

            Assert.IsTrue(scheduler.CantidadPedidos() == 0);
        }

        [TestMethod] // Test de Scheduler y eventos repetitivos
        public void ResolverPedidosTest2()
        {
            usr1 = new UsrPremium("manurocck");
            usr1.AgregarGuardarropa(new Guardarropa(10));

            Pedido Pedido1 = new Pedido(usr1, new Evento("CASUAL", new DateTime(2019, 9, 18), "Buenos Aires", "Pasear por la reserva", "UNICO"));
            Pedido Pedido2 = new Pedido(usr1, new Evento("TRABAJO", new DateTime(2019, 9, 18), "Buenos Aires", "Reunion trabajo", "SEMANAL"));
            Pedido Pedido4 = new Pedido(usr1, new Evento("CUMPLEAÑOS", new DateTime(2019, 9, 18), "Buenos Aires", "Cumpleaños Winnifred", "ANUAL"));
            Pedido Pedido3 = new Pedido(usr1, new Evento("CASUAL", new DateTime(2019, 9, 30), "Buenos Aires", "Ir a tomar un helado", "UNICO"));
            Pedido Pedido5 = new Pedido(usr1, new Evento("CASUAL", new DateTime(2019, 9, 18), "Buenos Aires", "Comprar escalera", "UNICO"));


            scheduler.AgregarPedido(Pedido1);
            scheduler.AgregarPedido(Pedido2);
            scheduler.AgregarPedido(Pedido3);
            scheduler.AgregarPedido(Pedido4);
            scheduler.AgregarPedido(Pedido5);

            Assert.AreEqual(5, scheduler.CantidadPedidos());

            while (scheduler.CantidadPedidos() > 0)
            {
                scheduler.DesencolarPedido();
            }

            Assert.AreEqual(3, scheduler.CantidadPedidos()); //El del 10 de septiembre, el cumpleaños del año que viene y el de trabajo de la semana que viene

        }
    }
}