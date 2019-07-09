using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Clima.Tests
{
    [TestClass()]
    public class WeatherServiceTest
    {
        [TestMethod()]
        public void ObtenerTemperatura1Test()
        {
            WeatherServiceAdapter clima = new OpenWeatherService("AR", "Bu123enos Aires");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }
        [TestMethod()]
        public void ObtenerTemperatura2Test()
        {
            WeatherServiceAdapter clima = new ApiXuService("AR", "Buenos Aires");
            decimal temperatura = clima.ObtenerTemperatura();
            Assert.IsTrue(temperatura < 15);
        }
    }
}