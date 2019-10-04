using Ar.UTN.QMP.Lib.Entidades._0._Para_DB;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionCantidad : Condicion
    {
        public Operador Operador { get; set; }
        public ICollection<CaracteristicaCondicion> Caracteristicas { get; set; }

        /// <summary>
        /// Valida la cantidad de prendas que poseen TODAS las caracteristicas contra el operador, para ser VALIDO. De lo contrario el atuendo es INVALIDO
        /// </summary>
        /// <param name="operador"></param>
        /// <param name="caracteristicas"></param>
        public CondicionCantidad(Operador operador, List<Caracteristica> caracteristicas)
        {
            this.Operador = operador;
            this.Caracteristicas = new List<CaracteristicaCondicion>();
            foreach (Caracteristica c in caracteristicas)
            {
                Caracteristicas.Add(new CaracteristicaCondicion(c.Clave, c.Valor, this));
            }
        }

        /// <summary>
        /// Valida el atuendo contra las reglas y el operador
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public override bool Validar(Atuendo atuendo)
        {
            int cantidad = 0;
            bool match = false;

            foreach(Prenda prenda in atuendo.Prendas)
            {
                foreach(Caracteristica car in this.Caracteristicas)
                {
                    if (prenda.TieneCaracteristica(car))
                    {
                        match = true;
                    }
                    else
                    {
                        match = false;
                        break;
                    }

                }

                if (match)
                    cantidad++;
            }

            return this.Operador.Resolver(cantidad);
        }
    }
}
