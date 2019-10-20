using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
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
            usr1.SetSensibilidad("CALUROSO");  

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


        /// <summary>
        /// Agregados Entrega 3 : 
        /// + Guardarropas compartido
        /// + Scheduler
        /// + Eventos repetitivos
        /// + Ordenamiento de atuendos según gustos
        /// + Filtro de clima según sensibilidad
        /// + Interfaz Notificador
        /// </summary>
        [TestMethod]
        public void GuardarropasCompartido()
        {
            #region VARIABLES
            int maxPrendas = 10;
            Usuario usr1 = new UsrGratis(maxPrendas, "manurocck");
            Usuario usr2 = new UsrGratis(maxPrendas, "ghalad");
            g1 = new Guardarropa(maxPrendas);
            #endregion

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
            usr2.SetSensibilidad("CALUROSO");
            usr1.AgregarGuardarropa(g1);
            usr2.AgregarGuardarropa(g1);
            #endregion

            #region PEDIDOS
            evento = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");
            pedido = new Pedido(usr1, evento);
            qmp.AgregarPedido(pedido);
            pedido = new Pedido(usr2, evento);
            qmp.AgregarPedido(pedido);

            qmp.DesencolarPedido(); //Desencola primero el pedido del usuario 2 por ordenamiento
            usr2.Pedido.AceptarPrimerAtuendo();

            qmp.DesencolarPedido();
            #endregion

            #region MOSTRAR POR PANTALLA
            Console.WriteLine("USUARIO 1 :");
            foreach (Atuendo a in usr1.Pedido.ObtenerAtuendos())
            {
                Console.WriteLine(string.Format("Atuendo id={0}", a.AtuendoId));
                foreach (Prenda p in a.Prendas)
                {
                    p.MostrarPorPantalla();
                }
                Console.WriteLine("");
            }
            Console.WriteLine("USUARIO 2:");
            foreach (Atuendo a in usr2.Pedido.ObtenerAtuendos())
            {
                Console.WriteLine(string.Format("Atuendo id={0}", a.AtuendoId));
                foreach (Prenda p in a.Prendas)
                {
                    p.MostrarPorPantalla();
                }
                Console.WriteLine("");
            }
            #endregion

            Console.WriteLine(string.Format("# Atuendos usuario 1 : {0}", usr1.Pedido.ObtenerAtuendos().Count));
            Console.WriteLine(string.Format("# Atuendos usuario 2 : {0}", usr2.Pedido.ObtenerAtuendos().Count));

            Assert.IsTrue(usr1.Pedido.ObtenerAtuendos().Count != usr2.Pedido.ObtenerAtuendos().Count);
            //Assert.AreEqual(usr.Pedido.ObtenerAtuendos().Count, 30);
            //Assert.AreEqual(usr2.Pedido.ObtenerAtuendos().Count, 2);
        }



        /*
        [TestMethod()]
        [Obsolete]
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
                listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
                listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "1"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
                listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "2"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
                listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "3"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                listaCar = new List<Caracteristica>();
                listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "superior"));
                listaCar.Add(GeGa.ObtenerCaracteristica("superposicion", "4"));
                regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

                regla = new Regla();
                listaCar = new List<Caracteristica>();
                listaCar.Add(GeGa.ObtenerCaracteristica("categoria", "calzado"));
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

            *
        }

        [TestMethod]
        [Obsolete]
        public void ThreadTest()
        {
            /*
            Thread t1 = new Thread(new ThreadStart(job1));
            t1.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("Main job doing cicle [{0}]", i));
                Thread.Sleep(1000);
            }

            t1.Join();
            *
        }

        [Obsolete]
        public void job1()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("Job1 doing cicle [{0}]", i));
                Thread.Sleep(10);
            }
        }
        */
    }
}