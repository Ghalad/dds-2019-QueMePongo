using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionComparacion : Condicion
    {
        public Operador Operador { get; set; }
        public Caracteristica Caracteristica { get; set; }

        public CondicionComparacion(Operador operador, Caracteristica caracteristica)
        {
            this.Operador = operador;
            this.Caracteristica = caracteristica;
        }

        public bool Validar(Atuendo atuendo)
        {
            int cantidad = 0;

            foreach(Prenda prenda in atuendo.Prendas)
                if (prenda.TieneCaracteristica(this.Caracteristica))
                    cantidad++;

            return this.Operador.Resolver(cantidad);
        }
    }
}
