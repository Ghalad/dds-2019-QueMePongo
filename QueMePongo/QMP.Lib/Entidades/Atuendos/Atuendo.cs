using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Atuendo
    {
        public List<Prenda> Prendas { get; set; }

        public bool EsUsado { get; set; }        

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
            this.EsUsado = false;
        }

        public void AgregarPrenda(Prenda unaPrenda)
        {
            this.Prendas.Add(unaPrenda);
        }

        public void mostrar() //muestra por pantalla el atuendo (cada prenda que lo compone)
        {
            foreach(Prenda p in Prendas)
            {
                p.mostrar();
            }
            return;
        }
    }
}
