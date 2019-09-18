using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.DBTables
{
    [Table("GuardarropasUsuarios")]
    public class GuardarropaUsuario
    {
        [Key, ForeignKey("Usuario"), Column(Order = 0)]
        public int UsuarioId { get; set; }
        [Key, ForeignKey("Guardarropa"), Column(Order = 1)]
        public int GuardarropaId { get; set; }
        public Usuario Usuario { get; set; }
        public Guardarropa Guardarropa { get; set; }

    }
}
