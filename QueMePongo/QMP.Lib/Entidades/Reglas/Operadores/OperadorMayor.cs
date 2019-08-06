namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores
{
    public class OperadorMayor : Operador
    {
        private int ValorReferencia { get; set; }

        public OperadorMayor(int valorReferencia)
        {
            this.ValorReferencia = valorReferencia;
        }

        public bool Resolver(int valor)
        {
            if (valor > this.ValorReferencia)
                return true; // atuendo INVALIDO
            else
                return false; // atuendo VALIDO
        }
    }
}
