using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Ar.UTN.QMP.Lib;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Test.Entidades.DB
{
    [TestClass]
    public class Persistencia
    {
        //OK
        [TestMethod]
        public void PersistirUsuariosConPedidos()
        {
            Pedido pedido1;
            Pedido pedido2;
            Evento evento1 = new Evento("casual", DateTime.Now, "Buenos Aires", "Ir a tomar un healdo", "UNICO");
            Evento evento2 = new Evento("trabajo", DateTime.Now, "Buenos Aires", "Ir a trabajar", "A DIARIO"); ;

            #region VARIABLES

            Prenda prenda1;
            Prenda prenda2;
            Prenda prenda3;
            Prenda prenda4;
            Prenda prenda5;
            Prenda prenda6;
            Prenda prenda7;
            Prenda prenda8;
            Prenda prenda9;
            Prenda prenda10;
            Usuario usr1;
            Usuario usr2;
            Regla regla;
            List<Caracteristica> listaCar;
            List<Regla> listaReglas = new List<Regla>();

            Guardarropa unGuardarropa;
            Guardarropa otroGuardarropa;

            #endregion

            #region CREACION PRENDAS
            PrendaBuilder pb = new PrendaBuilder();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro")
              .ConEvento("casual");
            prenda1 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco")
              .ConEvento("casual");
            prenda2 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul")
              .ConEvento("casual");
            prenda3 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda4 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("panchas")
              .ConMaterial("lana")
              .ConColor("azul")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda5 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pollera")
              .ConEvento("casual");
            prenda6 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda7 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("zapatilla_de_correr")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda8 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_corto")
              .ConEvento("casual");
            prenda9 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_abrigo")
              .ConEvento("casual");
            prenda10 = pb.ObtenerPrenda();

            #endregion PRENDAS

            #region ASIGNACION PRENDAS
            unGuardarropa = new Guardarropa(10);
            otroGuardarropa = new Guardarropa(10);

            unGuardarropa.AgregarPrenda(prenda1);
            unGuardarropa.AgregarPrenda(prenda2);
            unGuardarropa.AgregarPrenda(prenda3);
            unGuardarropa.AgregarPrenda(prenda4);
            unGuardarropa.AgregarPrenda(prenda5);
            unGuardarropa.AgregarPrenda(prenda6);
            unGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda5);
            otroGuardarropa.AgregarPrenda(prenda6);
            otroGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda8);
            otroGuardarropa.AgregarPrenda(prenda9);
            otroGuardarropa.AgregarPrenda(prenda10);
            #endregion

            #region CREACION REGLAS

            #region SUPERPOSICION
            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "2"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "3"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "4"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "4"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "3"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            listaReglas.Add(regla);

            #endregion SUPERPOSICION

            // descarta los atuendos que no tengan prendas en la parte superior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que no tengan prendas en la parte inferior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "inferior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que no tengan calzado
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "calzado"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan mas de 1 calzado
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "calzado"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan mas de 1 inferior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "inferior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);
            #endregion REGLAS

            #region CREACION USUARIOS

            usr1 = new UsrGratis(10, "manurocck");
            usr2 = new UsrPremium("guido");

            usr1.AgregarGuardarropa(unGuardarropa);
            usr2.AgregarGuardarropa(otroGuardarropa);
            usr2.AgregarGuardarropa(unGuardarropa);

            #endregion

            #region ASIGNACION REGLAS

            foreach (Regla r in listaReglas)
            {
                usr1.AgregarRegla(r);
            }

            #endregion

            pedido1 = new Pedido(usr1, evento1);
            pedido2 = new Pedido(usr2, evento2);

            //HAY QUE DESCOMENTAR LA LINEA DE FILTRAR POR CLIMA EN RESOLVER
            pedido1.Resolver();
            pedido2.Resolver();

            Assert.AreEqual(1, pedido2.Atuendos.Count);
            Assert.AreEqual(16, pedido1.Atuendos.Count);

            try
            {
                QueMePongoDB db = new QueMePongoDB();

                db.Usuarios.Add(usr1);
                //db.Usuarios.Add(usr2);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            Assert.AreEqual(1, 1);
        }
        
        //OK
        [TestMethod]
        public void PersistirUsuariosConGuardarropas()
        {
            Prenda prenda1;
            Prenda prenda2;
            Prenda prenda3;
            Prenda prenda4;
            Prenda prenda5;
            Prenda prenda6;
            Prenda prenda7;
            Prenda prenda8;
            Prenda prenda9;
            Prenda prenda10;
            Usuario usr1;
            Usuario usr2;

            Guardarropa unGuardarropa;
            Guardarropa otroGuardarropa;

            #region CREACION PRENDAS
            PrendaBuilder pb = new PrendaBuilder();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro")
              .ConEvento("casual");
            prenda1 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco")
              .ConEvento("casual");
            prenda2 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul")
              .ConEvento("casual");
            prenda3 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda4 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("panchas")
              .ConMaterial("lana")
              .ConColor("azul")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda5 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pollera")
              .ConEvento("casual");
            prenda6 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda7 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("zapatilla_de_correr")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda8 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_corto")
              .ConEvento("casual");
            prenda9 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_abrigo")
              .ConEvento("casual");
            prenda10 = pb.ObtenerPrenda();

            #endregion PRENDAS

            #region ASIGNACION PRENDAS
            unGuardarropa = new Guardarropa(10);
            otroGuardarropa = new Guardarropa(10);

            unGuardarropa.AgregarPrenda(prenda1);
            unGuardarropa.AgregarPrenda(prenda2);
            unGuardarropa.AgregarPrenda(prenda3);
            unGuardarropa.AgregarPrenda(prenda4);
            unGuardarropa.AgregarPrenda(prenda5);
            unGuardarropa.AgregarPrenda(prenda6);
            unGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda5);
            otroGuardarropa.AgregarPrenda(prenda6);
            otroGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda8);
            otroGuardarropa.AgregarPrenda(prenda9);
            otroGuardarropa.AgregarPrenda(prenda10);
            #endregion

            #region CREACION USUARIOS

            usr1 = new UsrGratis(10, "manurocck");
            usr2 = new UsrPremium("guido");

            usr1.AgregarGuardarropa(unGuardarropa);
            usr2.AgregarGuardarropa(otroGuardarropa);
            usr2.AgregarGuardarropa(unGuardarropa);

            #endregion

            try
            {
                QueMePongoDB db = new QueMePongoDB();

                db.Usuarios.Add(usr1);
                db.Usuarios.Add(usr2);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            Assert.AreEqual(1, 1);
        }
        
        //OK
        [TestMethod]
        public void PersistirPrendas()
        {
            Prenda prenda1;
            Prenda prenda2;
            Prenda prenda3;
            Prenda prenda4;
            Prenda prenda5;
            Prenda prenda6;
            Prenda prenda7;
            Prenda prenda8;
            Prenda prenda9;
            Prenda prenda10;

            #region CREACION PRENDAS
            PrendaBuilder pb = new PrendaBuilder();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro")
              .ConEvento("casual");
            prenda1 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco")
              .ConEvento("casual");
            prenda2 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul")
              .ConEvento("casual");
            prenda3 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda4 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("panchas")
              .ConMaterial("lana")
              .ConColor("azul")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda5 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pollera")
              .ConEvento("casual");
            prenda6 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda7 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("zapatilla_de_correr")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda8 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_corto")
              .ConEvento("casual");
            prenda9 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_abrigo")
              .ConEvento("casual");
            prenda10 = pb.ObtenerPrenda();

            #endregion PRENDAS

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                QueMePongoDB db = new QueMePongoDB();

                db.Prendas.Add(prenda1);
                db.Prendas.Add(prenda2);
                db.Prendas.Add(prenda3);
                db.Prendas.Add(prenda4);
                db.Prendas.Add(prenda5);
                db.Prendas.Add(prenda6);
                db.Prendas.Add(prenda7);
                db.Prendas.Add(prenda8);
                db.Prendas.Add(prenda9);
                db.Prendas.Add(prenda10);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            Assert.AreEqual(1, 1);
        }

        //OK
        [TestMethod]
        public void PersistirGuardarropas()
        {
            Prenda prenda1;
            Prenda prenda2  ;
            Prenda prenda3  ;
            Prenda prenda4  ;
            Prenda prenda5  ;
            Prenda prenda6  ;
            Prenda prenda7  ;
            Prenda prenda8  ;
            Prenda prenda9  ;
            Prenda prenda10 ;

            Guardarropa unGuardarropa;
            Guardarropa otroGuardarropa;

            #region CREACION PRENDAS
            PrendaBuilder pb = new PrendaBuilder();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro")
              .ConEvento("casual");
            prenda1 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco")
              .ConEvento("casual");
            prenda2 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul")
              .ConEvento("casual");
            prenda3 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda4 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("panchas")
              .ConMaterial("lana")
              .ConColor("azul")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda5 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pollera")
              .ConEvento("casual");
            prenda6 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConEvento("casual")
              .ConEvento("trabajo");
            prenda7 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("zapatilla_de_correr")
              .ConEvento("casual")
              .ConEvento("casamiento");
            prenda8 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_corto")
              .ConEvento("casual");
            prenda9 = pb.ObtenerPrenda();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_abrigo")
              .ConEvento("casual");
            prenda10 = pb.ObtenerPrenda();

            #endregion PRENDAS

            #region ASIGNACION PRENDAS
            unGuardarropa = new Guardarropa(10);
            otroGuardarropa = new Guardarropa(10);

            unGuardarropa.AgregarPrenda(prenda1);
            unGuardarropa.AgregarPrenda(prenda2);
            unGuardarropa.AgregarPrenda(prenda3);
            unGuardarropa.AgregarPrenda(prenda4);
            unGuardarropa.AgregarPrenda(prenda5);
            unGuardarropa.AgregarPrenda(prenda6);
            unGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda5);
            otroGuardarropa.AgregarPrenda(prenda6);
            otroGuardarropa.AgregarPrenda(prenda7);
            otroGuardarropa.AgregarPrenda(prenda8);
            otroGuardarropa.AgregarPrenda(prenda9);
            otroGuardarropa.AgregarPrenda(prenda10);
            #endregion


            try
            {
                QueMePongoDB db = new QueMePongoDB();

                db.Guardarropas.Add(unGuardarropa);
                db.Guardarropas.Add(otroGuardarropa);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            Assert.AreEqual(1, 1);
        }

        //OK
        [TestMethod]
        public void PersistirReglas()
        {
            Regla regla;
            List<Caracteristica> listaCar;

            List<Regla> listaReglas = new List<Regla>();

            #region REGLAS

            #region SUPERPOSICION
            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 1
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 2
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "2"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 3
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "3"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan en la parte superior mas de una prenda con nivel de superposicion 4
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "4"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "4"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan prendas con superposicion de grado mayor, sin tener prendas son superposicion de grado menor
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "3"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            listaReglas.Add(regla);

            #endregion SUPERPOSICION

            // descarta los atuendos que no tengan prendas en la parte superior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que no tengan prendas en la parte inferior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "inferior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que no tengan calzado
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "calzado"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan mas de 1 calzado
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "calzado"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);

            // descarta los atuendos que tengan mas de 1 inferior
            regla = new Regla();
            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "inferior"));
            regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            listaReglas.Add(regla);
            #endregion REGLAS


            try
            {
                QueMePongoDB db = new QueMePongoDB();

                foreach(Regla r in listaReglas)
                {
                    db.Reglas.Add(r);
                }

                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            Assert.AreEqual(1, 1);
        }

    }
}
