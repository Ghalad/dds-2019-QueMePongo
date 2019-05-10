using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Condicion
    {
        public Caracteristica Caracteristica { get; private set; }

        public Condicion(Caracteristica caracteristica)
        {
            this.Caracteristica = caracteristica;
        }

        public bool EsLaMisma(Condicion condicion)
        {
            if (this.Caracteristica.EsLaMisma(condicion.Caracteristica))
                return true;
            return false;
        }

        public bool Validar(Prenda prenda)
        {
            if (prenda.TieneCaracteristica(this.Caracteristica))
                return true;
            return false;
        }
    }
}
