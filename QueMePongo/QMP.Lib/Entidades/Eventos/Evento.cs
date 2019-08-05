using System;
using System.Collections.Generic;
using System.Linq;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;

namespace Ar.UTN.QMP.Lib.Entidades.Eventos
{
    public class Evento
    {
        public string Descripcion { get; set; }
        public string Ciudad { get; set }
        public DateTime Fecha { get; set; }
        public Caracteristica Estilo { get; set; }

        public Evento (string estilo)
        {
            string clave = "EVENTO";
            if (Tipos.GetInstance().ExisteCaracteristica(clave, estilo.ToUpper()))
            {
                this.Estilo = new Caracteristica(clave, estilo);
            }

        }
        public Caracteristica GetEstilo()
        {
            return Estilo;
        }

    }
}
