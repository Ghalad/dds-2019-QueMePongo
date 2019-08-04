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

        public void AgregarPrenda(Prenda prenda)
        {
            if (prenda != null)
            {
                this.Prendas.Add(prenda);
            }
        }


        public int CantidadDePrendas()
        {
            return this.Prendas.Count;
        }

        /*public bool TienePrenda(Prenda prenda)
        {
            foreach(Prenda p in this.Prendas)
                if (p.EsLaMisma(prenda))
                    return true;
            return false;
        }

        public bool EsElMismo(Atuendo atuendo)
        {
            foreach (Prenda prenda in this.Prendas)
                if (!atuendo.TienePrenda(prenda))
                    return false;
            return true;
        }*/
    }
}
