using System;
using System.Collections.Generic;

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
            {
                if (c.Nombre.Equals(caracteristica.Nombre))
                    return;
            }
            this.Caracteristicas.Add(caracteristica);
        }

        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if(c.Nombre.Equals(caracteristica.Nombre) && c.Valor.Equals(caracteristica.Valor))
                    return true;
            return false;
        }

        public void mostrar() //muestra por pantalla la prenda
        {
            this.mostrarCaracteristicaDetalle();
        }

        public void mostrarCaracteristicaDetalle()
        {
            foreach(Caracteristica c in Caracteristicas)
            {
                if( c.Nombre == "Detalle") //tiene que tener una característica detalle para que sea mostrado
                {
                    Console.WriteLine(c.Valor);
                }
            }
        }
    }
}
