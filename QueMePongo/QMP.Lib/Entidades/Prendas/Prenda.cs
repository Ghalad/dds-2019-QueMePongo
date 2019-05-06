using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class Prenda
    {

        private List<Caracteristica> caracteristicas { get; set; }

        public Prenda()
        {
            this.caracteristicas = new List<Caracteristica>();
        }

        public void AgregarCaracteristicas(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.caracteristicas)
                if (c.Valor.Equals(caracteristica.Valor))
                    return;

            this.caracteristicas.Add(caracteristica);
        }

        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach (Caracteristica c in this.caracteristicas)
                if (c.Valor.Equals(caracteristica.Valor))
                    return true;
            return false;
        }
    }
}
