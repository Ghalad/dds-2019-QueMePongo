﻿namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores
{
    public class OperadorIgual : Operador
    {
        private int ValorReferencia { get; set; }

        public OperadorIgual(int valorReferencia)
        {
            this.ValorReferencia = valorReferencia;
        }

        public override bool Resolver(int valor)
        {
            if (valor == this.ValorReferencia)
                return true; // atuendo INVALIDO
            else
                return false; // atuendo VALIDO
        }
    }
}
