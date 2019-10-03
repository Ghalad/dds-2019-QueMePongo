using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    [Table("Operadores")]
    public class Operador
    {
        public int OperadorId { get; set;}
        public int ValorReferencia { get; set; }
        public virtual bool Resolver(int valor) { return true; } 
    }
}
