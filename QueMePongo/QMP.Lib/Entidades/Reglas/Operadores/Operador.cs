using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    [Table("Operadores")]
    public abstract class Operador
    {
        public int OperadorId { get; set;}
        public int ValorReferencia { get; set; }
        public abstract bool Resolver(int valor);
    }
}
