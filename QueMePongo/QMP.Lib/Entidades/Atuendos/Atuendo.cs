using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Atuendo
    {
        public List<Prenda> Prendas { get; set; }

        public bool Usado { get; set; }        

        public Atuendo()
        {
            this.Prendas = new List<Prenda>();
            this.Usado = false;
        }

        public void AgregarPrenda(Prenda unaPrenda)
        {
            //TODO Faltaria agregar limitaciones a la insercion de prendas para evitar duplicidad
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
