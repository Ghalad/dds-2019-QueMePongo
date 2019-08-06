using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass()]
    public class PrendaBuilderTests
    {
        [TestMethod()]
        public void AgregarCaracteristicas_1()
        {
            PrendaBuilder pb = new PrendaBuilder();

            try
            {
                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("remera_manga_larga")
                  .ConMaterial("hilo")
                  .ConColor("blanco");
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AgregarCaracteristicas_2()
        {
            PrendaBuilder pb = new PrendaBuilder();

            try
            {
                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConCategoria("inferior")
                  .ConTipo("remera_manga_larga")
                  .ConMaterial("hilo")
                  .ConColor("blanco");

                Assert.Fail(); // Si llega a este punto, fallo el test porque se deberia haber generado una excepcion
            }
            catch
            {
                // Si catche la excepcion esta OK el caso
            }
            
        }

        [TestMethod()]
        public void AgregarCaracteristicas_3()
        {
            PrendaBuilder pb = new PrendaBuilder();

            try
            {
                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("remera_manga_larga")
                  .ConMaterial("hilo")
                  .ConColor("blanco")
                  .ConColor("azul");
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void NoPermiteAgregarCaracteristicasInvalidas()
        {
            PrendaBuilder pb = new PrendaBuilder();

            try
            {
                pb.CrearPrenda()
                  .ConCategoria("negro")
                  .ConTipo("azul")
                  .ConMaterial("remera_manga_larga")
                  .ConColor("superior");

                Assert.Fail(); // Si llega a este punto, fallo el test porque se deberia haber generado una excepcion
            }
            catch
            {
                // Si catche la excepcion esta OK el caso
            }
        }

        [TestMethod]
        public void ImagenesTest()
        {
            string rutaOrigen = @"Entidades\Atuendos\imagenOriginal.jpg";
            string rutaDestino = @"imagenNormalizada_" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";

            Image imagenOriginal = Image.FromFile(rutaOrigen);

            PrendaBuilder pb = new PrendaBuilder();

            try
            {
                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("remera_manga_larga")
                  .ConMaterial("hilo")
                  .ConColor("blanco")
                  .ConImagen(imagenOriginal);

                pb.ObtenerPrenda().Imagen.Save(rutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                Assert.Fail(); // Si llega a este punto fallo el test
            }

        }
    }
}