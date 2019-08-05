using System;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
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
    public class EventoTest
    {
        List<Atuendo> atuendos;
        Regla regla;
        List<Caracteristica> listaCar;
        Evento evento;
        PrendaBuilder pb;
        Usuario usr;

        [TestInitialize]
        public void Initialize()
        {
            this.atuendos = new List<Atuendo>();
            this.listaCar = new List<Caracteristica>();
            this.regla = new Regla();
            this.evento = new Evento("trabajo");
            this.pb = new PrendaBuilder();
            this.usr = new UsrPremium();
        }

        [TestMethod]
        public void AtuendosTemperaturaMedia()
        {
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
                   .ConTipo("camisa_manga_larga")
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

            listaCar.Add(new Caracteristica("categoria", "calzado"));
            listaCar.Add(new Caracteristica("categoria", "inferior"));

            //Como estoy teniendo problema con entender *todavia* las condiciones
            //voy a aclarar lo que ENTIENDO que hace cada condicion/lo que quiero que hagan


            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            //invalida los atuendos que no tengan las características
            regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            //invalida los atuendos que tengan repetidas las categorias
            regla.AgregarCondicion(new CondicionMultiple(listaCar));
            //invalida los atuendos superpuestos
            regla.AgregarCondicion(new CondicionSuperpuesto());

            AtuendosGestor atg = AtuendosGestor.GetInstance();

            atg.GenerarTodosLosAtuendosPosibles(usr);
            //atg.MostrarAtuendos();
            atg.FiltrarAtuendosRegla(regla);
            atg.MostrarAtuendos();
            //atg.FiltrarAtuendosTemperatura();

            Assert.IsTrue(false);
           
            //Assert.AreEqual(1, this.usr.Guardarropas[0].ObtenerAtuendosTemperatura(6).Count);

            //este falla.. espero 4 porque las combinaciones posibles tendrían que ser 4 pero falla.. 
            //estaria bueno poder VER los atuendos así sabemos cómo está fallando
            //Assert.AreEqual(4, this.usr.Guardarropas[0].ObtenerAtuendosTemperatura(14).Count);

        }

    }
}
