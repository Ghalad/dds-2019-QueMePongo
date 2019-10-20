using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionAfirmativa : Condicion
    {
        public ICollection<Caracteristica> Caracteristicas { get; set; }

        /// <summary>
        /// Verifica que TODAS las prendas del atuendo tengan TODAS las caracteristicas, para ser VALIDO. De lo contrario el atuendo es INVALIDO
        /// </summary>
        /// <param name="caracteristicas"></param>
        public CondicionAfirmativa(List<Caracteristica> caracteristicas)
        {
            this.Caracteristicas = new List<Caracteristica>();
            foreach (Caracteristica c in caracteristicas)
            {
                Caracteristicas.Add(new Caracteristica(c.Clave, c.Valor));
            }

        }

        /// <summary>
        /// Valida el atuendo contra las reglas
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public override bool Validar(Atuendo atuendo)
        {
            bool match = false;

            foreach (Prenda prenda in atuendo.Prendas)
            {
                foreach (Caracteristica caracteristica in this.Caracteristicas)
                {
                    if (prenda.TieneCaracteristica(caracteristica))
                    {
                        match = false;
                    }
                    else
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                    return true; // atuendo INVALIDO
            }

            return false;  // atuendo VALIDO
        }
    }
}
