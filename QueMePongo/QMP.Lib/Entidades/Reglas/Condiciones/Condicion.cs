using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    [Table("Condiciones")]
    public abstract class Condicion
    {
        public int CondicionId { get; set; }
        public ICollection<Caracteristica> Caracteristicas { get; set; }
        public abstract bool Validar(Atuendo atuendo);
    }
}
