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
        Atuendo atuendo1;
        Regla regla1;
        Prenda prenda1, prenda2;
        PrendaBuilder pb;

        [TestInitialize]
        public void Initialize()
        {
            this.pb = new PrendaBuilder();
            this.atuendo1 = new Atuendo();
            this.regla1 = new Regla();
        }

        [TestMethod]
        public void NumeroSuperposicion()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "algodon")
                   .AgregarCaracteristica("superposicion", "1");
            prenda1 = pb.ObtenerPrenda();

            Assert.AreEqual(1, prenda1.NumeroSuperposicion());
        }

        [TestMethod]
        public void DistintaSuperposicion()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "algodon")
                   .AgregarCaracteristica("superposicion", "1");
            prenda1 = pb.ObtenerPrenda();

            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "camisa_manga_larga")
                   .AgregarCaracteristica("material", "algodon")
                   .AgregarCaracteristica("superposicion", "2");
            prenda2 = pb.ObtenerPrenda();

            atuendo1.AgregarPrenda(prenda1);
            atuendo1.AgregarPrenda(prenda2);

            CondicionSuperpuesto c = new CondicionSuperpuesto();

            regla1.AgregarCondicion(c);

            Assert.IsTrue(regla1.Validar(atuendo1));
        }

        [TestMethod]
        public void MismaSuperposicion()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "algodon")
                   .AgregarCaracteristica("superposicion", "1");
            prenda1 = pb.ObtenerPrenda();

            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_larga")
                   .AgregarCaracteristica("material", "hilo")
                   .AgregarCaracteristica("superposicion", "1");
            prenda2 = pb.ObtenerPrenda();

            atuendo1.AgregarPrenda(prenda1);
            atuendo1.AgregarPrenda(prenda2);

            CondicionSuperpuesto c = new CondicionSuperpuesto();

            regla1.AgregarCondicion(c);

            Assert.IsFalse(regla1.Validar(atuendo1));
        }
    }
}
