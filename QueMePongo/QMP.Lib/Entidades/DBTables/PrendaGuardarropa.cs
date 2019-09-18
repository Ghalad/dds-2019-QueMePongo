using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.DBTables
{
    [Table("PrendasGuardarropas")]
    public class PrendaGuardarropa
    {
        [Key, ForeignKey("Prenda"), Column(Order = 0)]
        public int PrendaId { get; set; }
        [Key, ForeignKey("Guardarropa"), Column(Order = 1)]
        public int GuardarropaId { get; set; }
        public Prenda Prenda { get; set; }
        public Guardarropa Guardarropa { get; set; }

    }
}
