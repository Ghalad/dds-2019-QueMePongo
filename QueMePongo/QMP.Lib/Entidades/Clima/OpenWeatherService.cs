using Newtonsoft.Json;
using System;
using System.Net;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class OpenWeatherService
    {
        private WeatherInfo WeatherInfo { get; set; }
        private string AppId { get; set; }  //"8ed5caa2f1d3f297ff245132e0235d16";
        private string Ciudad { get; set; } //"Buenos Aires";
        private string @Url { get; set; }
        private const int TIEMPO_DE_OBSOLENCIA = 1;


        #region CONSTRUCTOR
        public OpenWeatherService(string appid, string ciudad)
        {
            this.AppId = appid;
            this.Ciudad = ciudad;
            this.Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&mode=json&units=metric&APPID={1}", this.Ciudad, this.AppId);
        }
        #endregion CONSTRUCTOR

        #region PUBLICO
        public decimal ObtenerHumedad()
        {
            this.RefrescarSiDatosObsoletos();
            try
            {
                return Decimal.Parse(this.WeatherInfo.Main.Humidity);
            }
            catch
            {
                //TODO MANEJO DE EXCEPCIONES
                throw new InvalidCastException();
            }
        }

        public decimal ObtenerPresion()
        {
            this.RefrescarSiDatosObsoletos();
            try
            {
                return Decimal.Parse(this.WeatherInfo.Main.Pressure);
            }
            catch
            {
                //TODO MANEJO DE EXCEPCIONES
                throw new InvalidCastException();
            }
        }

        public decimal ObtenerTemperatura()
        {
            this.RefrescarSiDatosObsoletos();
            try
            {
                return Decimal.Parse(this.WeatherInfo.Main.Temp.Replace('.',','));
            }
            catch
            {
                //TODO MANEJO DE EXCEPCIONES
                throw new InvalidCastException();
            }
        }
        #endregion PUBLICO


        #region PRIVADO
        /// <summary>
        /// Llama al servicio de Open Weather API y obtiene internamente la informacion del clima
        /// </summary>
        private void Refrescar()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(this.Url);
                this.WeatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);
            }
        }

        /// <summary>
        /// Evalua si es necesario llama al servicio de Open Weather API para actualizar los datos del clima
        /// </summary>
        private void RefrescarSiDatosObsoletos()
        {
            if (this.WeatherInfo == null)
                this.Refrescar();
            else
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dt = dt.AddSeconds(Int32.Parse(this.WeatherInfo.dt)).ToLocalTime(); // fecha de ultima obtencion de datos
                dt = dt.AddMinutes(TIEMPO_DE_OBSOLENCIA);

                if (dt.CompareTo(DateTime.Now) > 0)
                    this.Refrescar();
            }
        }
        #endregion PRIVADO

    }
}
