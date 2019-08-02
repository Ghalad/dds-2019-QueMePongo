using System;
using System.Collections.Generic;
using System.Linq;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;

namespace Ar.UTN.QMP.Lib.Entidades.Eventos
{
    public class Evento
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        internal List<Atuendo> ObtenerAtuendos(List<Guardarropa> guardarropas)
        {
            WeatherService clima = new WeatherService("AR", "Bu2enos Aires");
            decimal temperatura = clima.ObtenerTemperatura();

            List<Atuendo> atuendoAux = new List<Atuendo>();
            foreach (Guardarropa guardarropa in guardarropas)
            {
                atuendoAux = atuendoAux.Concat(guardarropa.ObtenerAtuendosTemperatura(temperatura)).ToList();
            }

            return atuendoAux;
        }
    }
}
