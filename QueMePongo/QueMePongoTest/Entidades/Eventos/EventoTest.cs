using System;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Test.Entidades.Eventos
{
    [TestClass]
    public class EventoTest
    {
        Evento evento;
        PrendaBuilder pb;
        Usuario usr;

        [TestInitialize]
        public void Initialize()
        {
            this.evento = new Evento("trabajo", "Buenos Aires", "lalalala lelelele");
            this.pb = new PrendaBuilder();
            this.usr = new UsrPremium();
        }

        [TestMethod]
        public void GeneracionAtuendosEvento()
        {
            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("cuero")
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
                   .ConEvento("salida_amigos");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());

            this.usr.Guardarropas[0].CombinarPrendasVersion2(3);
            Assert.AreEqual(7, this.usr.Guardarropas[0].Atuendos.Count);

            //FALLA AL CONTACTARSE CON EL SERVICIO DEL CLIMA
            //Assert.AreEqual(3, this.usr.ObtenerAtuendosEvento(evento).Count);
        }

    }
}
