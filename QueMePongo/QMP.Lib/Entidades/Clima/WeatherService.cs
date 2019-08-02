using System;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class WeatherService
    {
        private WeatherServiceAdapter srv { get; set; }
        private string Pais { get; set; }
        private string Ciudad { get; set; }


        public WeatherService(string pais, string ciudad)
        {
            this.Pais = pais.ToUpper();
            this.Ciudad = ciudad.ToUpper();
        }

        private void OpenWeather()
        {
            this.srv = OpenWeatherService.GetInstance();
        }

        private void ApiUx()
        {
            this.srv = ApiUxService.GetInstance();
        }

        public void SetCiudad(string pais, string ciudad)
        {
            this.Pais = pais.ToUpper();
            this.Ciudad = ciudad.ToUpper();
            this.srv.SetCiudad(this.Pais, this.Ciudad);
        }

        public decimal ObtenerTemperatura()
        {
            decimal temp;
            try
            {
                this.OpenWeather();
                temp = this.srv.ObtenerTemperatura();
            }
            catch
            {
                try
                {
                    this.ApiUx();
                    temp = this.srv.ObtenerTemperatura();
                }
                catch
                {
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
    }
}
