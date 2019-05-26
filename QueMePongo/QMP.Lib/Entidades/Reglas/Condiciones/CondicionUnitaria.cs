using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionUnitaria : Condicion
    {
        public Caracteristica Caracteristica { get; set; }

        public CondicionUnitaria(Caracteristica caracteristica)
        {
            this.Caracteristica = caracteristica;
        }

        /// <summary>
        /// Valida que se cumpla una UNICA caracteristica por prenda.
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool Validar(Atuendo atuendo)
        {
            foreach(Prenda prenda in atuendo.Prendas)
                if (prenda.TieneCaracteristica(this.Caracteristica))
                    return true; // Atuendo INVALIDO

            return false;
        }
    }
}
