using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;

namespace Ar.UTN.QMP.Test.Entidades.Atuendos
{
    [TestClass]
    public class SuperposicionTest
    {
        Atuendo a1;
        Regla r1;
        Prenda p1, p2;
        PrendaBuilder pb;

        [TestInitialize]
        public void Initialize()
        {
            this.pb = new PrendaBuilder();
            this.a1 = new Atuendo();
            this.r1 = new Regla("R1");
        }

        [TestMethod]
        public void NumeroSuperposicion()
        {
            this.pb.CrearPrenda()
                .ConCategoria("superior")
                .ConTipo("remera_manga_corta")
                .ConMaterial("algodon");
            this.p1 = pb.ObtenerPrenda();

            Assert.AreEqual(1, p1.NumeroSuperposicion());
        }

        [TestMethod]
        public void DistintaSuperposicion()
        {
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("algodon");
            a1.AgregarPrenda(pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("camisa_manga_larga")
                   .ConMaterial("algodon");
            a1.AgregarPrenda(pb.ObtenerPrenda());

            CondicionSuperpuesto c = new CondicionSuperpuesto();

            r1.AgregarCondicion(c);

            Assert.IsTrue(r1.Validar(a1));
        }

        [TestMethod]
        public void MismaSuperposicion()
        {
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("algodon");
            a1.AgregarPrenda(pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_larga")
                   .ConMaterial("hilo");
            a1.AgregarPrenda(pb.ObtenerPrenda());

            CondicionSuperpuesto c = new CondicionSuperpuesto();

            r1.AgregarCondicion(c);

            Assert.IsFalse(r1.Validar(a1));
        }
    }
}
