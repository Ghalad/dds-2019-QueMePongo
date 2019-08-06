using System;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Eventos
{
    public class Evento
    {
        public string Descripcion { get; set; }
        public string CiudadEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public Caracteristica TipoEvento { get; set; }

        public Evento(string tipoEvento, DateTime fecha, string cuidad, string descripcion)
        {
            string clave = "EVENTO";

            if (!string.IsNullOrWhiteSpace(tipoEvento))
            {
                if (!string.IsNullOrWhiteSpace(cuidad))
                {
                    if (Tipos.GetInstance().ExisteCaracteristica(clave, tipoEvento.ToUpper()))
                    {
                        this.FechaEvento = fecha;
                        this.Descripcion = descripcion;
                        this.CiudadEvento = cuidad;
                        this.TipoEvento = new Caracteristica(clave, tipoEvento);
                    }
                    else
                        throw new Exception(string.Format("No existe el evento [{0}]", tipoEvento));
                }
                else
                    throw new Exception("Debe informar la ciudad donde ocurrira el evneto");
            }
            else
                throw new Exception("Debe informar el tipo de evento");
        }
    }
}
