using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass()]
    public class PrendaBuilderTests
    {
        [TestMethod()]
        public void AgregaCuatroCaracteristicas()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("tipo", "remera_manga_larga")
              .AgregarCaracteristica("material", "hilo")
              .AgregarCaracteristica("color", "blanco");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 4);
        }

        [TestMethod()]
        public void AgregaCuatroCaracteristicasSinRepetidos()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("categoria", "inferior")
              .AgregarCaracteristica("tipo", "remera_manga_larga")
              .AgregarCaracteristica("material", "hilo")
              .AgregarCaracteristica("color", "blanco");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 4);
        }

        [TestMethod()]
        public void AgregaCuatroCaracteristicasConColorSecundario()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("tipo", "remera_manga_larga")
              .AgregarCaracteristica("material", "hilo")
              .AgregarCaracteristica("color", "blanco")
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("tipo", "remera_manga_larga")
              .AgregarCaracteristica("material", "hilo")
              .AgregarCaracteristica("color", "blanco")
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("tipo", "remera_manga_larga")
              .AgregarCaracteristica("material", "hilo")
              .AgregarCaracteristica("color", "azul");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 5);
        }

        [TestMethod()]
        public void NoPermiteAgregarCaracteristicasInvalidas1()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .AgregarCaracteristica("categoria", "negro")
              .AgregarCaracteristica("tipo", "azul")
              .AgregarCaracteristica("material", "remera_manga_larga")
              .AgregarCaracteristica("color", "superior");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 0);
        }

        [TestMethod()]
        public void NoPermiteAgregarCaracteristicasInvalidas2()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .AgregarCaracteristica("categoria", "superior")
              .AgregarCaracteristica("tipo", "ojotas");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 1);
        }
    }
}