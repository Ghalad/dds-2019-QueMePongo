using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class ApiXuService : WeatherServiceAdapter
    {
        private ApiUxInfo Data { get; set; }
        private string AppId { get; set; }  //"745e46f80f49463d88422016192806";
        private string Ciudad { get; set; } //"Buenos Aires";
        private string CiudadAnterior { get; set; }
        public string Pais { get; set; }
        private string @Url { get; set; }
        private const int TIEMPO_DE_OBSOLENCIA = 1;


        #region CONSTRUCTOR
        public ApiXuService(string pais, string ciudad)
        {
            if (pais != null && ciudad != null)
            {
                this.AppId = "745e46f80f49463d88422016192806";
                this.Ciudad = ciudad;
                this.CiudadAnterior = this.Ciudad;
                this.Pais = pais;
                this.Url = string.Format("http://api.apixu.com/v1/current.json?key={0}&q={1},{2}", this.AppId, this.Ciudad, this.Pais);
            }
            else
            {
                throw new Exception();
            }
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
                throw new Exception();
            }
        }

        public decimal ObtenerHumedad()
        {
            this.RefrescarSiDatosObsoletos();
            try
            {
                return Decimal.Parse(this.Data.Current.Humidity);
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
                return Decimal.Parse(this.Data.Current.Pressure_mb);
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
                return Decimal.Parse(this.Data.Current.Temp_c);
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
