using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class ApiUxService : WeatherServiceAdapter
    {
        private static ApiUxService Instance { get; set; }
        private ApiUxInfo Data { get; set; }
        private string AppId { get; set; }  //"745e46f80f49463d88422016192806";
        private string Ciudad { get; set; } //"Buenos Aires";
        private string CiudadAnterior { get; set; }
        public string Pais { get; set; }
        private string @Url { get; set; }
        private const int TIEMPO_DE_OBSOLENCIA = 1;


        #region CONSTRUCTOR
        public static ApiUxService GetInstance()
        {
            if (Instance == null) Instance = new ApiUxService();
            return Instance;
        }

        private ApiUxService()
        {
            this.AppId = "745e46f80f49463d88422016192806";
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
                this.Url = string.Format("http://api.apixu.com/v1/current.json?key={0}&q={1},{2}", this.AppId, this.Ciudad, this.Pais);
            }
            else
            {
                throw new Exception("Pais o ciudad invalidos");
            }
        }

        public decimal ObtenerHumedad()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Current.Humidity);
        }

        public decimal ObtenerPresion()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Current.Pressure_mb);
        }

        public decimal ObtenerTemperatura()
        {
            this.RefrescarSiDatosObsoletos();
            return Decimal.Parse(this.Data.Current.Temp_c);
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
                catch (WebException wex)
                {
                    json = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                }

                this.Data = JsonConvert.DeserializeObject<ApiUxInfo>(json);
                if (this.Data.Error!= null && this.Data.Error.Code != "200")
                {
                    throw new Exception(this.Data.Error.Message);
                }
                if (this.Data.Location.Country.ToUpper() != "ARGENTINA" || this.Data.Location.Name.ToUpper() != this.Ciudad.ToUpper())
                {
                    throw new Exception("Ciudad no encontrada");
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
                dt = dt.AddSeconds(Int32.Parse(this.Data.Current.Last_updated_epoch)).ToLocalTime(); // fecha de ultima obtencion de datos
                dt = dt.AddMinutes(TIEMPO_DE_OBSOLENCIA);

                if (dt.CompareTo(DateTime.Now) > 0)
                    this.Refrescar();
            }
        }
        #endregion PRIVADO

    }
}
