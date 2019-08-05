using System;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Test.Entidades.Eventos
{
    [TestClass]
    public class AtuendosGestorTest
    {
        List<Atuendo> atuendos;
        Regla regla;
        List<Caracteristica> listaCar;
        List<Caracteristica> listaCar2;
        Evento evento;
        PrendaBuilder pb;
        Usuario usr;

        [TestInitialize]
        public void Initialize()
        {
            this.atuendos = new List<Atuendo>();
            this.listaCar = new List<Caracteristica>();
            this.listaCar2 = new List<Caracteristica>();
            this.regla = new Regla();
            this.evento = new Evento("trabajo");
            this.pb = new PrendaBuilder();
            this.usr = new UsrPremium();
        }

        [TestMethod]
        public void AtuendoNormal()
        {
            #region ATUENDO
            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("cuero")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_larga")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("sweater")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("campera_de_abrigo")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_corto")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("ojotas")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapatilla_de_correr")
                   .ConEvento("trabajo");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());
            #endregion

            //tiene que tener 1 calzado, 1 inferior y al menos 1 superior
            #region REGLA
            listaCar.Add(new Caracteristica("categoria", "calzado"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "inferior"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));

            #endregion

            AtuendosGestor atg = AtuendosGestor.GetInstance();

            atg.GenerarTodosLosAtuendosPosibles(usr);
            atg.FiltrarAtuendosSuperpuestos();
            atg.FiltrarAtuendosRegla(regla);
            atg.MostrarAtuendos();
            //atg.FiltrarAtuendosTemperatura();

            Assert.AreEqual(22, atg.ObtenerAtuendos().Count);
        }
    }
}
