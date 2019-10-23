using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Calificaciones
{
    [Table("Calificaciones")]
    public class Calificacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int CalificacionId { get; set; }
        public int Puntaje { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Usuario Usuario { get; set; }
        

        public Calificacion() { }

        public Calificacion(Usuario usuario, int puntaje)
        {
            this.Puntaje = puntaje;
            this.FechaCreacion = DateTime.Now;
            this.Usuario = usuario;
        }
    }
}
