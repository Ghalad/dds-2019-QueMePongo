using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Calificaciones
{
    [Table("Calificaciones")]
    public class Calificacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int CalificacionId { get; set; }
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
