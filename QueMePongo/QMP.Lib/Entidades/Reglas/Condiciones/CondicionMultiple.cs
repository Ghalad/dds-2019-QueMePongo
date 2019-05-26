using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionMultiple : Condicion
    {
        public List<Caracteristica> Caracteristicas { get; set; }

        public CondicionMultiple(List<Caracteristica> caracteristicas)
        {
            this.Caracteristicas = caracteristicas;
        }

        /// <summary>
        /// Si se cumplen TODAS las caracteristicas sobre una misma prenda, esta no es valida.
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool Validar(Atuendo atuendo)
        {
            bool match = false;

            foreach(Prenda prenda in atuendo.Prendas)
            {
                foreach(Caracteristica caracteristica in this.Caracteristicas)
                {
                    if (prenda.TieneCaracteristica(caracteristica))
                        match = true;
                    else
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return true; // Atuendo INVALIDO
            }

            return false;
        }
    }
}
