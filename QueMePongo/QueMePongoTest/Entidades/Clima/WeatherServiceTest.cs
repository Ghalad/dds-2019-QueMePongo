using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Clima.Tests
{
    [TestClass()]
    public class WeatherServiceTest
    {
        [TestMethod()]
        public void ObtenerTemperaturaOpenWeatherTest()
        {
            WeatherService srvClima = new WeatherService("AR", "Buenos Aires");
            decimal temperatura = srvClima.ObtenerTemperatura();


            Assert.IsTrue(temperatura > 5 && temperatura < 20);
        }
    }
}