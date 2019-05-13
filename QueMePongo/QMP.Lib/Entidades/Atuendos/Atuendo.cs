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
    }
}
