using System;
using System.Collections.Generic;
using System.Linq;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;

namespace Ar.UTN.QMP.Lib.Entidades.Eventos
{
    public class Evento
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; }
        public Caracteristica Estilo { get; set; }

        public Evento (string estilo, string ciudad, string descripcion)
        {
            string clave = "EVENTO";
            if (!string.IsNullOrWhiteSpace(estilo) && Tipos.GetInstance().ExisteCaracteristica(clave, estilo.ToUpper()))
            {
                this.Estilo = new Caracteristica(clave, estilo);
                this.Fecha = DateTime.Now;
                this.Ciudad = ciudad.ToUpper();
                this.Descripcion = descripcion;
            }
            else
            {
                //TODO definir manejo excepciones
                throw new Exception("No es posble crear el evento solicitado");
            }

        }

        internal List<Atuendo> ObtenerAtuendos(List<Guardarropa> guardarropas)
        {
            WeatherService clima = new WeatherService("AR", "Bu2enos Aires");
            decimal temperatura = clima.ObtenerTemperatura();

            List<Atuendo> atuendoList = new List<Atuendo>();
            foreach (Guardarropa guardarropa in guardarropas)
            {
                atuendoList = atuendoList.Concat(guardarropa.ObtenerAtuendosTemperatura(temperatura)).ToList();
            }

        #region FILTRAR ATUENDOS QUE NO COINCIDEN EL EVENTO
            Regla unaRegla = new Regla();
            List<Caracteristica> listaCar = new List<Caracteristica>();
            listaCar.Add(Estilo);
            unaRegla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            
            foreach(Atuendo atuendo in atuendoList)
            {
                if (!unaRegla.Validar(atuendo))
                    atuendoList.Remove(atuendo);
            }

        #endregion

            return atuendoList;
        }
    }
}
