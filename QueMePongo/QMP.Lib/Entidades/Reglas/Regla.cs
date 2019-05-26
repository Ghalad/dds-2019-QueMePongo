using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        private List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            this.Condiciones = new List<Condicion>(); 
        }

        public void AgregarCondicion(Condicion unaCondicion)
        {
            Condiciones.Add(unaCondicion);
        }

        public void QuitarCondicion(Condicion unaCondicion)
        {
            Condiciones.Remove(unaCondicion);
        }

        public bool Validar(Atuendo atuendo)
        {
            foreach(Condicion condicion in this.Condiciones)
            {
                if (condicion.Validar(atuendo))
                {
                    return false; // ATUENDO INVALIDO
                }
            }

            return true; // ATUENDO VALIDO
        }
    }
}
