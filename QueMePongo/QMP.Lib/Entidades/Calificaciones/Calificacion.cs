using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Calificaciones
{
    public class Calificacion
    {

        public int puntajeHistorico { get; set; }
        public DateTime tiempoCalificacion { get; set; }
        // ^ para saber el momento en que acepta y se coloca el atuendo/prenda
        public Calificacion(int puntaje)
        {
            this.puntajeHistorico = puntaje;
            this.tiempoCalificacion = DateTime.Now;
        }

        public int ObtenerPuntaje()
        {
            return puntajeHistorico;
        }

        public void Calificar(int puntaje)
        {
            this.puntajeHistorico += puntaje;
            this.tiempoCalificacion = DateTime.Now;
        }
    }
}
