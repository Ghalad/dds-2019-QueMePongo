using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class ReglaExistencia : Regla
    {
        private List<Condicion> Condiciones { get; set; }

        public ReglaExistencia()
        {
            this.Condiciones = new List<Condicion>();
        }

        public void AgregarCondicion(Condicion condicion)
        {
            foreach(Condicion c in this.Condiciones)
                if (!c.EsLaMisma(condicion))
                    this.Condiciones.Add(condicion);
        }

        private bool Validar(Prenda prenda)
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
