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

        public bool TieneColorPrimario(TColores color)
        {
            try
            {
                switch (color)
                {
                    case TColores.NEGRO:
                            this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", "NEGRO")); return true;
                    case TColores.BLANCO:
                            this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", "NEGRO")); return true;
                    case TColores.AZUL:
                            this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", "NEGRO")); return true;
                    case TColores.VERDE:
                            this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", "NEGRO")); return true;
                    case TColores.ROJO:
                            this.Caracteristicas.Find(c => c.EsLaMisma("COLOR_PRIMARIO", "NEGRO")); return true;
                    default: return false;
                }
            }
            catch { return false; }
        }
    }
}
