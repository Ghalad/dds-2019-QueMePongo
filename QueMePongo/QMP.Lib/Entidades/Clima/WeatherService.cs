using System;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class WeatherService
    {
        private WeatherServiceAdapter srv { get; set; }
        private string Pais { get; set; }
        private string Ciudad { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(WeatherService));

        public WeatherService(string pais, string ciudad)
        {
            this.Pais = pais.ToUpper();
            this.Ciudad = ciudad.ToUpper();
        }

        #region PUBLICO
        public void SetCiudad(string pais, string ciudad)
        {
            this.Pais = pais.ToUpper();
            this.Ciudad = ciudad.ToUpper();
        }

        public decimal ObtenerTemperatura()
        {
            decimal temp;
            try
            {
                this.OpenWeather();
                temp = this.srv.ObtenerTemperatura();
            }
            catch(Exception ex)
            {
                log.Error("Error Servicio Clima 1:" + ex.Message);
                try
                {
                    this.ApiUx();
                    temp = this.srv.ObtenerTemperatura();
                }
                catch(Exception ex2)
                {
                    log.Error("Error Servicio Clima 2:" + ex2.Message);
                    throw new Exception("Servicio de clima no disponible");
                }
            }
            return temp;
        }

        public decimal ObtenerHumedad()
        {
            decimal humedad;
            try
            {
                this.OpenWeather();
                humedad = this.srv.ObtenerHumedad();
            }
            catch
            {
                try
                {
                    this.ApiUx();
                    humedad = this.srv.ObtenerHumedad();
                }
                catch
                {
                    throw new Exception("Servicio de clima no disponible");
                }
            }
            return humedad;
        }

        public decimal ObtenerPresion()
        {
            decimal presion;
            try
            {
                this.OpenWeather();
                presion = this.srv.ObtenerPresion();
            }
            catch
            {
                try
                {
                    this.ApiUx();
                    presion = this.srv.ObtenerPresion();
                }
                catch
                {
                    throw new Exception("Servicio de clima no disponible");
                }
            }
            return presion;
        }
        #endregion PUBLICO

        #region PRIVADO
        private void OpenWeather()
        {
            this.srv = OpenWeatherService.GetInstance();
            this.srv.SetCiudad(this.Pais, this.Ciudad);
        }

        private void ApiUx()
        {
            this.srv = ApiUxService.GetInstance();
            this.srv.SetCiudad(this.Pais, this.Ciudad);
        }
        #endregion PRIVADO
    }
}
