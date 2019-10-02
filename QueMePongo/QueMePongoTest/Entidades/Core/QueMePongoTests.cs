//using Ar.UTN.QMP.Lib.Entidades.Atuendos;
//using Ar.UTN.QMP.Lib.Entidades.Eventos;
//using Ar.UTN.QMP.Lib.Entidades.Reglas;
//using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
//using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
//using Ar.UTN.QMP.Lib.Entidades.Usuarios;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Threading;

//namespace Ar.UTN.QMP.Lib.Entidades.Core.Tests
//{
//    [TestClass()]
//    public class QueMePongoTests
//    {
//        [TestMethod]
//        public void ResolverPedido()
//        {
//            int maxPrendas = 10;
//            Usuario usr = new UsrGratis(maxPrendas);
//            usr.CrearGuardarropa(1);
//            usr.SetSensibilidad("CALUROSO");
//            Regla regla;
//            List<Caracteristica> listaCar;

//            PrendaBuilder pb = new PrendaBuilder();

//            #region PRENDAS
//            pb.CrearPrenda()
//              .ConCategoria("accesorio")
//              .ConTipo("gorra")
//              .ConMaterial("lana")
//              .ConColor("verde")
//              .ConColor("negro")
//              .ConEvento("casual");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("remera_manga_corta")
//              .ConMaterial("algodon")
//              .ConColor("azul")
//              .ConColor("blanco")
//              .ConEvento("casual");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("campera_de_lluvia")
//              .ConMaterial("poliester")
//              .ConColor("negro")
//              .ConColor("azul")
//              .ConEvento("casual");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//            pb.CrearPrenda()
//              .ConCategoria("inferior")
//              .ConTipo("pantalon_largo")
//              .ConMaterial("poliester")
//              .ConColor("negro")
//              .ConEvento("casual")
//              .ConEvento("trabajo");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//            pb.CrearPrenda()
//              .ConCategoria("calzado")
//              .ConTipo("panchas")
//              .ConMaterial("lana")
//              .ConColor("azul")
//              .ConEvento("casual")
//              .ConEvento("casamiento");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//            pb.CrearPrenda()
//              .ConCategoria("calzado")
//              .ConTipo("ojotas")
//              .ConMaterial("goma")
//              .ConColor("azul")
//              .ConEvento("casual");
//            usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());
//            #endregion PRENDAS

//            Evento evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");

//            #region REGLAS

//            #region SUPERPOSICION
//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            #region a
//            /* HAY QUE ARREGLAS ESTO
//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);
//            */
//            #endregion a
//            #endregion SUPERPOSICION

//            // descarta los atuendos que no tengan prendas en la parte superior
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que no tengan prendas en la parte inferior
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "inferior"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que no tengan calzado
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "calzado"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan mas de 1 calzado
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "calzado"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);
//            #endregion REGLAS
            

//            Pedido pedido = new Pedido(usr, usr.Guardarropas.Find(g => g.Id.Equals("g1")).ObtenerPrendas(), usr.Reglas, evento);

//            QueMePongo qmp = QueMePongo.GetInstance();

//            qmp.AgregarPedido(pedido);

//            Assert.IsTrue(usr.Pedido == null);
//            qmp.DesencolarPedido();

//            foreach(Atuendo a in usr.Pedido.ObtenerAtuendos())
//            {
//                int i = 1;
//                Console.WriteLine(string.Format("Atuendo id={0}", a.Id));
//                foreach(Prenda p in a.Prendas)
//                {
//                    p.MostrarPorPantalla();
//                }
//                Console.WriteLine("");
//            }
//            Assert.IsTrue(usr.Pedido.ObtenerAtuendos().Count >= 0);
//        }


//        /// <summary>
//        /// Agregados Entrega 3 : 
//        /// + Guardarropas compartido
//        /// + Scheduler
//        /// + Eventos repetitivos
//        /// + Ordenamiento de atuendos según gustos
//        /// + Filtro de clima según sensibilidad
//        /// + Interfaz Notificador
//        /// </summary>
//        [TestMethod] 
//        public void GuardarropasCompartido()
//        {
//            #region VARIABLES
//            int maxPrendas = 10;
//            Usuario usr = new UsrGratis(maxPrendas);
//            Usuario usr2 = new UsrGratis(maxPrendas);
//            Guardarropa g1;
//            Prenda prenda1;
//            Prenda prenda2;
//            Prenda prenda3;
//            Prenda prenda4;
//            Prenda prenda5;
//            Prenda prenda6;
//            Prenda prenda7;
//            Prenda prenda8;
//            Prenda prenda9;
//            Prenda prenda10;
//            Regla regla;
//            List<Caracteristica> listaCar;
//            #endregion

//            #region CREACION PRENDAS
//            PrendaBuilder pb = new PrendaBuilder();
//            pb.CrearPrenda()
//              .ConCategoria("accesorio")
//              .ConTipo("gorra")
//              .ConMaterial("lana")
//              .ConColor("verde")
//              .ConColor("negro")
//              .ConEvento("casual");
//            prenda1 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("remera_manga_corta")
//              .ConMaterial("algodon")
//              .ConColor("azul")
//              .ConColor("blanco")
//              .ConEvento("casual");
//            prenda2 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("campera_de_lluvia")
//              .ConMaterial("poliester")
//              .ConColor("negro")
//              .ConColor("azul")
//              .ConEvento("casual");
//            prenda3 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("inferior")
//              .ConTipo("pantalon_largo")
//              .ConMaterial("poliester")
//              .ConColor("negro")
//              .ConEvento("casual")
//              .ConEvento("trabajo");
//            prenda4 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("calzado")
//              .ConTipo("panchas")
//              .ConMaterial("lana")
//              .ConColor("azul")
//              .ConEvento("casual")
//              .ConEvento("casamiento");
//            prenda5 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("inferior")
//              .ConTipo("pollera")
//              .ConEvento("casual");
//            prenda6 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("remera_manga_larga")
//              .ConEvento("casual")
//              .ConEvento("trabajo");
//            prenda7 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("calzado")
//              .ConTipo("zapatilla_de_correr")
//              .ConEvento("casual")
//              .ConEvento("casamiento");
//            prenda8 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("inferior")
//              .ConTipo("pantalon_corto")
//              .ConEvento("casual");
//            prenda9 = pb.ObtenerPrenda();

//            pb.CrearPrenda()
//              .ConCategoria("superior")
//              .ConTipo("campera_de_abrigo")
//              .ConEvento("casual");
//            prenda10 = pb.ObtenerPrenda();

//            #endregion PRENDAS
//            #region CREACION GUARDARROPA
//            g1 = new Guardarropa(1, maxPrendas);
//            g1.AgregarPrenda(prenda1);
//            g1.AgregarPrenda(prenda2);
//            g1.AgregarPrenda(prenda3);
//            g1.AgregarPrenda(prenda4);
//            g1.AgregarPrenda(prenda5);
//            g1.AgregarPrenda(prenda6);
//            g1.AgregarPrenda(prenda7);
//            g1.AgregarPrenda(prenda8);
//            g1.AgregarPrenda(prenda9);
//            g1.AgregarPrenda(prenda10);
//            #endregion
//            #region REGLAS

//            #region SUPERPOSICION
//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "1"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            #region a
//            /* HAY QUE ARREGLAS ESTO
//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "4"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "2"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            listaCar.Add(new Caracteristica("superposicion", "3"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
//            usr.AgregarRegla(regla);
//            */
//            #endregion a
//            #endregion SUPERPOSICION

//            // descarta los atuendos que no tengan prendas en la parte superior
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "superior"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que no tengan prendas en la parte inferior
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "inferior"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que no tengan calzado
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "calzado"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan mas de 1 calzado
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "calzado"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);

//            // descarta los atuendos que tengan mas de 1 inferior
//            regla = new Regla();
//            listaCar = new List<Caracteristica>();
//            listaCar.Add(new Caracteristica("categoria", "inferior"));
//            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
//            usr.AgregarRegla(regla);
//            #endregion REGLAS
//            #region USUARIOS
//            usr.SetSensibilidad("CALUROSO");
//            usr2.SetSensibilidad("CALUROSO");
//            usr.AgregarGuardarropa(g1);
//            usr2.AgregarGuardarropa(g1);
//            #endregion
//            #region PEDIDOS
//            Evento evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");
//            Pedido pedido = new Pedido(usr, usr.Guardarropas.Find(g => g.Id.Equals("g1")).ObtenerPrendas(), usr.Reglas, evento);
//            QueMePongo qmp = QueMePongo.GetInstance();
//            qmp.AgregarPedido(pedido);
//            pedido = new Pedido(usr2, usr2.Guardarropas.Find(g => g.Id.Equals("g1")).ObtenerPrendas(), usr.Reglas, evento);
//            qmp.AgregarPedido(pedido);

//            qmp.DesencolarPedido(); //Desencola primero el pedido del usuario 2 por ordenamiento
//            usr2.Pedido.AceptarPrimerAtuendo();

//            qmp.DesencolarPedido();
//            #endregion

//            #region MOSTRAR POR PANTALLA
//            Console.WriteLine("USUARIO 1 :");
//            foreach (Atuendo a in usr.Pedido.ObtenerAtuendos())
//            {
//                Console.WriteLine(string.Format("Atuendo id={0}", a.Id));
//                foreach (Prenda p in a.Prendas)
//                {
//                    p.MostrarPorPantalla();
//                }
//                Console.WriteLine("");
//            }
//            Console.WriteLine("USUARIO 2:");
//            foreach (Atuendo a in usr2.Pedido.ObtenerAtuendos())
//            {
//                Console.WriteLine(string.Format("Atuendo id={0}", a.Id));
//                foreach (Prenda p in a.Prendas)
//                {
//                    p.MostrarPorPantalla();
//                }
//                Console.WriteLine("");
//            }
//            #endregion

//            Console.WriteLine(string.Format("# Atuendos usuario 1 : {0}", usr.Pedido.ObtenerAtuendos().Count));
//            Console.WriteLine(string.Format("# Atuendos usuario 2 : {0}", usr2.Pedido.ObtenerAtuendos().Count));

//            Assert.IsTrue(usr.Pedido.ObtenerAtuendos().Count != usr2.Pedido.ObtenerAtuendos().Count);
//            //Assert.AreEqual(usr.Pedido.ObtenerAtuendos().Count, 30);
//            //Assert.AreEqual(usr2.Pedido.ObtenerAtuendos().Count, 2);
//        }

//        [TestMethod] // Test de Scheduler y eventos repetitivos
//        public void Scheduler()
//        {
//            Usuario usr = new UsrPremium();
//            usr.AgregarGuardarropa(new Guardarropa(10));

//            Pedido Pedido1 = new Pedido(usr, usr.Guardarropas[0].ObtenerPrendas(), usr.Reglas, new Evento("CASUAL", new DateTime(2019, 9, 18), "Buenos Aires", "Pasear por la reserva", "UNICO"));
//            Pedido Pedido2 = new Pedido(usr, usr.Guardarropas[0].ObtenerPrendas(), usr.Reglas, new Evento("TRABAJO", new DateTime(2019, 9, 18), "Buenos Aires", "Reunion trabajo", "SEMANAL"));
//            Pedido Pedido4 = new Pedido(usr, usr.Guardarropas[0].ObtenerPrendas(), usr.Reglas, new Evento("CUMPLEAÑOS", new DateTime(2019, 9, 18), "Buenos Aires", "Cumpleaños Winnifred", "ANUAL"));
//            Pedido Pedido3 = new Pedido(usr, usr.Guardarropas[0].ObtenerPrendas(), usr.Reglas, new Evento("CASUAL", new DateTime(2019, 9, 30), "Buenos Aires", "Ir a tomar un helado", "UNICO"));
//            Pedido Pedido5 = new Pedido(usr, usr.Guardarropas[0].ObtenerPrendas(), usr.Reglas, new Evento("CASUAL", new DateTime(2019, 9, 18), "Buenos Aires", "Comprar escalera", "UNICO"));

//            QueMePongo qmp = QueMePongo.GetInstance();
//            qmp.AgregarPedido(Pedido1);
//            qmp.AgregarPedido(Pedido2);
//            qmp.AgregarPedido(Pedido3);
//            qmp.AgregarPedido(Pedido4);
//            qmp.AgregarPedido(Pedido5);

//            Assert.AreEqual(5, qmp.CantidadPedidos());

//            qmp.IniciarScheduler();

//            Assert.AreEqual(3, qmp.CantidadPedidos()); //El del 10 de septiembre, el cumpleaños del año que viene y el de trabajo de la semana que viene

//        }

//        /*
//        [TestMethod()]
//        [Obsolete]
//        public void CreacionDePedido()
//        {
//            /*
//            try
//            {
//                int maxPrendas = 10;
//                Usuario usr = new UsrGratis(maxPrendas);
//                usr.CrearGuardarropa("g1");
//                Regla regla;
//                List<Caracteristica> listaCar;

//                PrendaBuilder pb = new PrendaBuilder();

//                #region PRENDAS
//                pb.CrearPrenda()
//                  .ConCategoria("accesorio")
//                  .ConTipo("gorra")
//                  .ConMaterial("lana")
//                  .ConColor("verde")
//                  .ConColor("negro")
//                  .ConEvento("casual");
//                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//                pb.CrearPrenda()
//                  .ConCategoria("superior")
//                  .ConTipo("remera_manga_corta")
//                  .ConMaterial("algodon")
//                  .ConColor("azul")
//                  .ConColor("blanco")
//                  .ConEvento("casual");
//                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//                pb.CrearPrenda()
//                  .ConCategoria("superior")
//                  .ConTipo("campera_de_lluvia")
//                  .ConMaterial("poliester")
//                  .ConColor("negro")
//                  .ConColor("azul")
//                  .ConEvento("casual");
//                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//                pb.CrearPrenda()
//                  .ConCategoria("inferior")
//                  .ConTipo("pantalon_largo")
//                  .ConMaterial("poliester")
//                  .ConColor("negro")
//                  .ConEvento("casual");
//                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());

//                pb.CrearPrenda()
//                  .ConCategoria("calzado")
//                  .ConTipo("panchas")
//                  .ConMaterial("lana")
//                  .ConColor("azul")
//                  .ConEvento("casual");
//                usr.Guardarropas.Find(g => g.Id.Equals("g1")).AgregarPrenda(pb.ObtenerPrenda());
//                #endregion PRENDAS

//                Evento evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo");

//                #region REGLAS
//                regla = new Regla();
//                listaCar = new List<Caracteristica>();
//                listaCar.Add(new Caracteristica("categoria", "superior"));
//                listaCar.Add(new Caracteristica("superposicion", "1"));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

//                listaCar = new List<Caracteristica>();
//                listaCar.Add(new Caracteristica("categoria", "superior"));
//                listaCar.Add(new Caracteristica("superposicion", "2"));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

//                listaCar = new List<Caracteristica>();
//                listaCar.Add(new Caracteristica("categoria", "superior"));
//                listaCar.Add(new Caracteristica("superposicion", "3"));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

//                listaCar = new List<Caracteristica>();
//                listaCar.Add(new Caracteristica("categoria", "superior"));
//                listaCar.Add(new Caracteristica("superposicion", "4"));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

//                regla = new Regla();
//                listaCar = new List<Caracteristica>();
//                listaCar.Add(new Caracteristica("categoria", "calzado"));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
//                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
//                #endregion REGLAS

//                usr.AgregarRegla(regla);

//                Pedido pedido = new Pedido(usr, usr.Guardarropas.Find(g => g.Id.Equals("g1")).ObtenerPrendas(), usr.Reglas, evento);

//                QueMePongo qmp = QueMePongo.GetInstance();

//                qmp.AgregarPedido(pedido);

//                //while (usr.Pedido == null) ;

//                //Thread.Sleep(5000);
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            //Assert.IsTrue(usr.Pedido.ObtenerAtuendos().Count > 0);

//            *
//        }

//        [TestMethod]
//        [Obsolete]
//        public void ThreadTest()
//        {
//            /*
//            Thread t1 = new Thread(new ThreadStart(job1));
//            t1.Start();

//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine(string.Format("Main job doing cicle [{0}]", i));
//                Thread.Sleep(1000);
//            }

//            t1.Join();
//            *
//        }

//        [Obsolete]
//        public void job1()
//        {
//            for(int i = 0; i < 10; i++)
//            {
//                Console.WriteLine(string.Format("Job1 doing cicle [{0}]", i));
//                Thread.Sleep(10);
//            }
//        }
//        */
//    }
//}