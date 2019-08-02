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
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConMaterial("hilo")
              .ConColor("blanco");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 4+1);
        }

        [TestMethod()]
        public void AgregaCuatroCaracteristicasSinRepetidos()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConCategoria("inferior")
              .ConTipo("remera_manga_larga")
              .ConMaterial("hilo")
              .ConColor("blanco");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 4+1);
        }

        [TestMethod()]
        public void AgregaColorSecundario()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConMaterial("hilo")
              .ConColor("blanco")
              .ConColor("azul");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 5+1);
        }

        [TestMethod()]
        public void NoPermiteAgregarCaracteristicasInvalidas()
        {
            PrendaBuilder pb = new PrendaBuilder();

            pb.CrearPrenda()
              .ConCategoria("negro")
              .ConTipo("azul")
              .ConMaterial("remera_manga_larga")
              .ConColor("superior");

            Assert.IsTrue(pb.ObtenerPrenda().CantidadDeCaracteristicas() == 0);
        }
    }
}