using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        public List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            this.Condiciones = new List<Condicion>();
        }

        public bool Validar(Prenda prenda)
        {
            foreach (Condicion c in this.Condiciones)
                if (!c.Validar(prenda))
                    return false;
            return true;
        }


        public bool Validar(Atuendo atuendo)
        {
            foreach (Prenda p in atuendo.Prendas)
                if (this.Validar(p))
                    return false;
            return true;
        }
    }
}
