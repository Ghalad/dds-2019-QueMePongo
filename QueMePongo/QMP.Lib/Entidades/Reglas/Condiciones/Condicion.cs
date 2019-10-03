using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    [Table("Condiciones")]
    public class Condicion
    {
        public int CondicionId { get; set; }
        public bool Validar(Atuendo atuendo) { return true; }
    }
}
