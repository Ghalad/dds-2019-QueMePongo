using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class OpenWeatherService : WeatherServiceAdapter
    {
        private static OpenWeatherService Instance { get; set; }
        private OpenWeatherInfo Data { get; set; }
        private string AppId { get; set; }  //"8ed5caa2f1d3f297ff245132e0235d16";
        private string Ciudad { get; set; } //"Buenos Aires";
        private string CiudadAnterior { get; set; }
        private string Pais { get; set; }
        private string @Url { get; set; }
        private const int TIEMPO_DE_OBSOLENCIA = 1;


        #region CONSTRUCTOR
        public static OpenWeatherService GetInstance()
        {
            if (Instance == null) Instance = new OpenWeatherService();
            return Instance;
        }

        private OpenWeatherService()
        {
            this.AppId = "8ed5caa2f1d3f297ff245132e0235d16";
        }
        #endregion CONSTRUCTOR


        #region PUBLICO
        public void SetCiudad(string pais, string ciudad)
        {
            if (pais != null && ciudad != null)
            {
                this.Pais = pais;
                this.CiudadAnterior = this.Ciudad;
                this.Ciudad = ciudad;
                this.Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},{1}&mode=json&units=metric&APPID={2}", this.Ciudad, this.Pais, this.AppId);
            }
            else
            {
                throw new Exception("Pais o ciudad invalidos");
            }
        }


        public decimal ObtenerHumedad()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Main.Humidity);
        }

        public decimal ObtenerPresion()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Main.Pressure);
        }

        public decimal ObtenerTemperatura()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Main.Temp);
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
                string json = string.Empty;
                try
                {
                    json = client.DownloadString(this.Url);
                }
                catch(WebException wex)
                {
                    json = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                }

                this.Data = JsonConvert.DeserializeObject<OpenWeatherInfo>(json);
                if (this.Data.Cod != "200")
                {
                    throw new Exception(this.Data.Message);
                }
            }
        }

        /// <summary>
        /// Evalua si es necesario llama al servicio de Open Weather API para actualizar los datos del clima
        /// </summary>
        private void RefrescarSiDatosObsoletos()
        {
            if (this.Data == null || this.Ciudad != this.CiudadAnterior)
                this.Refrescar();
            else
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dt = dt.AddSeconds(Int32.Parse(this.Data.dt)).ToLocalTime(); // fecha de ultima obtencion de datos
                dt = dt.AddMinutes(TIEMPO_DE_OBSOLENCIA);

                if (dt.CompareTo(DateTime.Now) > 0)
                    this.Refrescar();
            }
        }
        #endregion PRIVADO

    }
}
