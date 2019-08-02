using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionComparacion : Condicion
    {
        public Operador Operador { get; set; }
        public List<Caracteristica> Caracteristicas { get; set; }

        public CondicionComparacion(Operador operador, List<Caracteristica> caracteristicas)
        {
            this.Operador = operador;
            this.Caracteristicas = caracteristicas;
        }

        public bool Validar(Atuendo atuendo)
        {
            int cantidad = 0;
            bool match = false;

            foreach(Prenda prenda in atuendo.Prendas)
            {
                foreach(Caracteristica car in this.Caracteristicas)
                {
                    if (prenda.TieneCaracteristica(car))
                    {
                        match = true;
                    }
                    else
                    {
                        match = false;
                        break;
                    }

                }

                if (match)
                    cantidad++;
            }

            return this.Operador.Resolver(cantidad);
        }
    }
}
