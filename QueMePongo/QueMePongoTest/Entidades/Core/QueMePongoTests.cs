using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Test.Entidades.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Core.Tests
{
    [TestClass()]
    public class QueMePongoTests
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



        [TestInitialize]
        public void Initialize()
        {
            this.GeGa = GestorCaracteristicas.GetInstance();
            this.pb = new PrendaBuilder();
            this.qmp = QueMePongo.GetInstance();
        }

        [TestMethod]
        public void ResolverPedido()
        {
            int maxPrendas = 10;
            usr1 = new UsrGratis(maxPrendas, "manurocck");
            g1 = new Guardarropa(maxPrendas);
            usr1.AgregarGuardarropa(g1);
            usr1.Sensibilidad = this.GeGa.ObtenerIndiceSensibilidad("CALUROSO");

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

            evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");

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


            pedido = new Pedido(usr1, evento);
            
            qmp.AgregarPedido(pedido);

            Assert.IsTrue(usr1.Pedido == null);
            qmp.DesencolarPedido();

            foreach (Atuendo a in usr1.Pedido.ObtenerAtuendos())
            {
                int i = 1;
                Console.WriteLine(string.Format("Atuendo id={0}", a.AtuendoId));
                foreach (Prenda p in a.Prendas)
                {
                    p.MostrarPorPantalla();
                }
                Console.WriteLine("");
            }
            Assert.IsTrue(usr1.Pedido.ObtenerAtuendos().Count >= 0);
        }

        [TestMethod]
        public void GuardarropasCompartido()
        {
            #region VARIABLES
            int maxPrendas = 10;
            usr1 = new UsrGratis(maxPrendas, "manurocck");
            usr2 = new UsrGratis(maxPrendas, "ghalad");
            g1 = new Guardarropa(maxPrendas);
            #endregion

            #region PRENDAS
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
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
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
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("azul")
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
            usr1.Sensibilidad = this.GeGa.ObtenerIndiceSensibilidad("CALUROSO");
            usr2.Sensibilidad = this.GeGa.ObtenerIndiceSensibilidad("CALUROSO");
            usr1.AgregarGuardarropa(g1);
            usr2.AgregarGuardarropa(g1);
            #endregion

            #region PEDIDOS
            evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");
            qmp.AgregarPedido(new Pedido(usr1, evento));

            evento = new Evento("casual", DateTime.Now, "Buenos Aires", "ir a caminar", "semanal");
            qmp.AgregarPedido(new Pedido(usr2, evento));
            #endregion PEDIDOS

            // Resuelvo el pedido que entro primero (USR1)
            qmp.DesencolarPedido();

            // Acepto el atuendo xx
            usr1.Pedido.AceptarAtuendo(6, 17);

            // Busco el atuendo aceptado (unico) por el usr1 para compararlo con los atuendos sugeridos al usr2
            Atuendo atuendoAceptado = null;
            foreach (Atuendo unAtuendo in usr1.AtuendosAceptados)
            {
                if (unAtuendo.AtuendoId == 6) atuendoAceptado = unAtuendo;
            }

            // Resuelvo el segundo pedido
            qmp.DesencolarPedido();

            Assert.IsNotNull(atuendoAceptado);

            // Compruebo que ningun atuendo sugerido al usr2 contenga prendas del atuendo aceptado por el usr1
            foreach (Prenda unaPrendaAceptada in atuendoAceptado.Prendas)
            {
                foreach (Atuendo unAtuendo in usr2.Pedido.Atuendos)
                {
                    foreach (Prenda unaPrenda in unAtuendo.Prendas)
                    {
                        Assert.IsTrue(unaPrendaAceptada.PrendaId != unaPrenda.PrendaId);
                    }
                }
            }
        }

        [TestMethod]
        public void AlertaMeteorologica()
        {
            int maxPrendas = 10;
            usr1 = new UsrGratis(maxPrendas, "manurocck");
            usr1.UsuarioId = 123;
            usr1.SetMetodoComunicacion(new MensajeTexto());
            g1 = new Guardarropa(maxPrendas);
            usr1.AgregarGuardarropa(g1);
            usr1.Sensibilidad = this.GeGa.ObtenerIndiceSensibilidad("CALUROSO");

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

            evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");

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

            pedido = new Pedido(usr1, evento);

            qmp.AgregarPedido(pedido);

            Assert.IsTrue(usr1.Pedido == null);

            qmp.DesencolarPedido();

            // PARA TESTEAR ESTE METODO ES NECESARIO CAMBIAR EL METODO "NotificarCambioDeClima" DE "PEDIDO"
            // PARA QUE LLAME AL METODO "CumpleNivelDeAbrigo2" EN VEZ DE LA METODO "CumpleNivelDeAbrigo"
            pedido.AceptarAtuendo(14, 13);
        }
    }
}