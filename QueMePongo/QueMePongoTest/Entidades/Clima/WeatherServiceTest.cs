using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Clima.Tests
{
    [TestClass()]
    public class WeatherServiceTest
    {
        [TestMethod()]
        public void ObtenerTemperaturaOpenWeatherTest()
        {
            WeatherServiceAdapter clima = OpenWeatherService.GetInstance();
            clima.SetCiudad("AR", "Buenos Aires");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }

        [TestMethod()]
        public void ObtenerTemperaturaApiUxTest()
        {
            WeatherServiceAdapter clima = ApiUxService.GetInstance();
            clima.SetCiudad("AR", "merlo");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }
    }
}