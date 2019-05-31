using Ar.UTN.QMP.Lib.Entidades.Atuendos.Caracteristicas;
using System.Collections.Generic;
using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Prenda
    {
        private List<Caracteristica> Caracteristicas { get; set; }

        public Prenda()
        {
            this.Caracteristicas = new List<Caracteristica>();
        }

        public void AgregarCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(caracteristica))
                    return;
            this.Caracteristicas.Add(caracteristica);
        }

        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if(c.EsLaMisma(caracteristica))
                    return true;
            return false;
        }

        public bool TieneCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                    return true;
            return false;
        }

        public bool TieneCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsMismaClave(clave.ToUpper()))
                    return true;
            return false;
        }

        public bool TieneColorPrimario(string color)
        {
            try
            {
                this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", color));
                return true;
            }
            catch { return false; }
        }

        public bool EsLaMisma(Prenda prenda)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (!prenda.TieneCaracteristica(c))
                    return false;
            return true;
        }

        public int CantidadDeCaracteristicas()
        {
            return this.Caracteristicas.Count;
        }
    }
}
