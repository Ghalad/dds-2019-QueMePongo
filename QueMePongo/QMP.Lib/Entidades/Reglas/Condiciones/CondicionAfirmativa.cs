using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionAfirmativa : Condicion
    {
        public CondicionAfirmativa()
        {
            this.Caracteristicas = new List<Caracteristica>();
        }

        /// <summary>
        /// Verifica que TODAS las prendas del atuendo tengan TODAS las caracteristicas, para ser VALIDO. De lo contrario el atuendo es INVALIDO
        /// </summary>
        /// <param name="caracteristicas"></param>
        public CondicionAfirmativa(List<Caracteristica> caracteristicas)
        {
            this.Caracteristicas = caracteristicas;
        }

        /// <summary>
        /// Valida el atuendo contra las reglas
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public override bool Validar(Atuendo atuendo)
        {
            bool match = false;

            foreach (Caracteristica caracteristica in this.Caracteristicas)
            {
                match = false;

                foreach (Prenda prenda in atuendo.Prendas)
                {
                    if (prenda.TieneCaracteristica(caracteristica))
                    {
                        match = true;
                        break;
                    }
                }

                if (!match) return false; // atuendo VALIDO
            }

            return true;  // atuendo INVALIDO
        }
    }
}
