namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores
{
    public class OperadorMenorIgual : Operador
    {
        public int ValorReferencia { get; set; }

        public OperadorMenorIgual(int valorReferencia)
        {
            this.ValorReferencia = valorReferencia;
        }

        public bool Resolver(int valor)
        {
            if (valor <= this.ValorReferencia)
                return true; // Atuendo INVALIDO
            else
                return false; // Atuendo VALIDO
        }
    }
}
