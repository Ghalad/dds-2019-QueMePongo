using System;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class ReglaIgualA : Regla
    {
        private Condicion Condicion { get; set; }
        private int Valor { get; set; }

        public ReglaIgualA(Condicion condicion, int valor)
        {
            this.Condicion = condicion;
            this.Valor = valor;

        }

        public bool Validar(Atuendo atuendo)
        {
            int i = 0;

            foreach(Prenda p in atuendo.Prendas)
                if (this.Condicion.Validar(p))
                    i++;

            if (i == this.Valor)
                return true;
            else
                return false;

        }
    }
}
