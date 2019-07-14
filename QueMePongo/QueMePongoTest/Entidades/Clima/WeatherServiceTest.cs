using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Clima.Tests
{
    [TestClass()]
    public class WeatherServiceTest
    {
        [TestMethod()]
        public void ObtenerTemperaturaOpenWeatherTest()
        {
            WeatherServiceAdapter clima = new OpenWeatherService("AR", "Bu2enos Aires");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }

        [TestMethod()]
        public void ObtenerTemperaturaApiUxTest()
        {
            WeatherServiceAdapter clima = new ApiXuService("AR", "mer1lo");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }
    }
}