using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class CondicionAfirmativa : Condicion
    {
        private Caracteristica Caracteristica { get; set; }

        public CondicionAfirmativa(Caracteristica caracteristica)
        {
            this.Caracteristica = caracteristica;
        }

        public bool Validar(Prenda prenda)
        {
            if (prenda.TieneCaracteristica(this.Caracteristica))
                return true;
            return false;
        }
    }
}
