using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Atuendo
    {
        public List<Prenda> Prendas { get; set; }

        public bool Usada { get; set; }        

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
            this.Usada = false;
        }

        public void agregarPrenda(Prenda unaPrenda)
        {
            this.Prendas.Add(unaPrenda);
            return;
        }

        public void quitarPrenda(Prenda unaPrenda)
        {
            this.Prendas.Remove(unaPrenda);
            return;
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
