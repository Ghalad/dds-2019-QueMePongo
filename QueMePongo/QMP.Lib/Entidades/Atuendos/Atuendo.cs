using System.Collections.Generic;
using System.Linq;

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
            if (this.Prendas.Count == 0)
                this.Prendas.Add(prenda);
            else
                if (!this.Prendas.Any<Prenda>(p => p.EsLaMisma(prenda)))
                 this.Prendas.Add(prenda);
        }
    }
}
